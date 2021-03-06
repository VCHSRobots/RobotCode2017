# ---------------------------------------------------------------------
# targetserver.py -- Independant program to run Target System
#
# Created 3/15/17 DLB
# ---------------------------------------------------------------------

# This program is responsible for the following:
# 1. Launched at Startup and remain running no matter what.
# 2. Communicate with the laptop (driver station or "ds"), and send
#    a pic every 1 or 2 seconds that shows the status of the targeting system.
# 3. Receive adjustment commands for the driver station -- Save these to disk.
# 4. Produce pointing info and publish that via MQTT.
# 5. Decide on target to process based on messages from MQTT.

import sys
import paho.mqtt.client as mqtt 
import os.path
import threading
import time
import pickle
import evsslogger
import findtarget
import mqttcomm
import targetproc
import cv2
import base64

logger = evsslogger.getLogger()
lasttargetmode = -1
paramfile = "/home/ubuntu/RobotCode2017/targetparams.pkl"
framedecimation = 0  # 0=don't send, >0 send every N
targetparams = {}


# Saves the target parameters to the disk.
def save_params():
	global targetparams
	try:
		with open(paramfile, 'wb') as f:
			pickle.dump(targetparams, f, pickle.HIGHEST_PROTOCOL)
	except:
		logger.warn("Unable to save parameters to disk.")

# Loads our target parameters with data that has been previously
# saved to disk.  But makes sure that all parameters are in the
# final dictionary.
def load_params():
	global targetparams
	diskparams = {}
	if os.path.isfile(paramfile):
		try:
			with open(paramfile, 'rb') as f:
				diskparams = pickle.load(f)
			if type(diskparams) is not dict:
				diskparams = {} 
				logger.info("Param file contained invalid data. Using built-in defaults.")
			else:
				logger.info("Param file loaded from disk.  Number of params found=%d" % len(diskparams))
		except:
			emsg = sys.exc_info()[0]
			logger.warn("Failed to load parameters from disk (%s). Using built-in defaults.", emsg)
			diskparams = {}
	else:
		logger.warn("No param file found at " + paramfile + ". Using built-in defaults.")
	defaultparams = findtarget.GetDefaultParams()
	for p in defaultparams:
		if p in diskparams:
			targetparams[p] = diskparams[p]
		else:
			targetparams[p] = defaultparams[p]

# Checks for new parameters delivered via mqtt.  If new ones are found, replaces existing ones
# and saves them all to disk.  Assumes that the current params have the entire default set
# of keys.
lastparamseq = -1
def checkNewParams():
	global lastparamseq
	global targetparams
	txt, seq, ts = mqttcomm.getMessage("robot/ds/targetparams")
	if txt is None or seq <= lastparamseq:
		return
	lastparamseq = seq
	# the parameters are encoded like this:  key1=value1;key2=value2;key3=value3...	
	paramlines = txt.split(";")
	print(paramlines)
	for p in paramlines:
		indx = p.find("=")
		if indx > 0:
			key = p[0:indx]
			sval = p[indx+1:].strip()
			okay = False
			try:
				val = float(sval)
				okay = True
			except ValueError:
				okay = False
			if okay:
				targetparams[key]=val
	save_params()
	logger.info("New target parameters received")

# Check for a request to send the parameters back to the driver station 
lastparamsendseq = -1
def checkReqToSendParams():
	global lastparamsendseq
	txt, seq, ts = mqttcomm.getMessage("robot/ds/sendparams")
	if txt is None or seq <= lastparamsendseq:
		return
	lastparamsendseq = seq
	# Format the parameters like this: key1=val1;key2=val2;key3=val3...
	mm = ""
	for p in targetparams:
		key = p
		s = "%s=%f;" % (p, targetparams[p])
		mm += s
	mqttcomm.send("robot/jetson/targetparams", mm)
	logger.info("Target parameters sent to drive station.")

# Check for a request to load default parameters and use them.
lastdefaultseq = -1
def checkReqToUseDefaults():
	global lastdefaultseq
	global targetparams
	txt, seq, ts = mqttcomm.getMessage("robot/ds/usedefaultparams")
	if txt is None or seq <= lastdefaultseq:
		return
	lastdefaultseq = seq
	targetparams = findtarget.GetDefaultParams()
	logger.info("Default target parameters loaded.")
	
# Check for a request for frame decimation
lastframedecimationtseq = -1
def checkReqForFrameDecimation():
	global lastframedecimationtseq
	global framedecimation
	txt, seq, ts = mqttcomm.getMessage("robot/ds/framedecimation")
	if txt is None or seq <= lastframedecimationtseq:
		return
	lastframedecimationtseq = seq
	try:
		framedecimation = int(txt)
	except ValueError:
		framedecimation = 0
	logger.info("New Frame Decimation Value Received: %d." % framedecimation)
		
# Check for a switch in target mode.
lasttargetmode = -1
def checkTargetMode():
	global lasttargetmode
	mode = 0
	txt = "0"
	chooser = ""
	txt1, seq1, ts1 = mqttcomm.getMessage("robot/roborio/targetmode")
	txt2, seq2, ts2 = mqttcomm.getMessage("robot/ds/targetmode")
	if (txt1 is not None) and (txt2 is not None):
		if ts1 > ts2:
			txt = txt1
			chooser = "roborio"
		else:
			txt = txt2
			chooser = "ds"
	elif txt1 is not None:
		txt = txt1
		chooser = "roborio"
	else:
		txt = txt2
		chooser = "ds"
	if txt == "0" or txt == "none":
		mode = 0
	elif txt == "1" or txt == "boiler":
		mode = 1
	elif txt == "2" or txt == "peg":
		mode = 2
	if mode != lasttargetmode:
		lasttargetmode = mode
		logger.info("Mode switched to %d due to message from %s." % (mode, chooser))
	return mode

framecount = 0
def SendFrame(Frame):
	global framecount
	framecount += 1
	if framedecimation == 0:
		return
	if framecount % framedecimation != 0:
		return	

	FrameAsPng = cv2.imencode(".png", Frame)[1]
	bytes_as_string = base64.b64encode(FrameAsPng)
	mqttcomm.send("pic/ts", bytes_as_string)

def SendTargetInfo(report):
	mqttcomm.send("robot/jetson/targetreport", report.ToReport())

def mainapp():
	evsslogger.initLogging("TargetSystem.log")
	logger.info("Starting Target System Server")
	mqttcomm.start("JetsonTS")
	targproc = targetproc.TargetProc()
	load_params()

	loopcount = 0
	NumberOfReports = 0

	while True:
		checkNewParams()
		checkReqToSendParams()
		checkReqToUseDefaults()
		checkReqForFrameDecimation()
		targetmode = checkTargetMode()
		targproc.SetParams(targetparams)
		targproc.SetTargetMode(targetmode)
		report = targproc.Process()
		SendFrame(report.Frame)
		SendTargetInfo(report)
		NumberOfReports += 1
		if NumberOfReports % 40 == 0:
			logger.info("Report=" + report.ToString())
		time.sleep(0.020)  # run Loop every 20 milliseconds
		loopcount += 1
		if loopcount % 200 == 0:
			logger.info("Main Target System Loop Count: %d" % loopcount)

if __name__ == "__main__":
	mainapp()
