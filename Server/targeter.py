# ---------------------------------------------------------------------
# targeter.py -- Main targeting system for targeting for Jeston on 2017 EPIC Robot
#
# Created by: TastyDucks, DLB 02/17
# ---------------------------------------------------------------------

import cv2, socket, threading, time, traceback
from subprocess import call
import numpy as np
import evsslogger

logger = evsslogger.getLogger()

#Demonstation variable

Demo = False



class Targeter(threading.Thread):
	def __init__(self):
		threading.Thread.__init__(self)
		self.Cam = None
		self.TargetIndex = -1
		self.TargetNewIndex = 0
		self.TargetSwitchLock = threading.Lock()
		self.AnswerLock = threading.Lock()
		self.Answer = None

	# setTarget(indx) -- Switch targets.
	# 0=none, 1=boiler, 2=peg
	def setTarget(self, targetindex):
		self.TargetSwitchLock.acquire()
		self.TargetNewIndex = targetindex
		self.TargetSwitchLock.release()

	def killTarget(self):
		if self.Cam is not None:
			try:
				self.Cam.release()
			except:
				logger.info("Unable to release Cam %d" % self.TargetIndex)
		self.Cam = None
		self.TargetIndex = -1

	def setTargetForReal(self, targetindex):
		logger.info("Target %d Selected" % targetindex)
		self.killTarget()
		self.TargetIndex = targetindex
		if self.TargetIndex >= 0:
			try:
				self.Cam = cv2.VideoCapture(self.TargetIndex)
			except:
				logger.warn("Unable to setup Cam %d for capture" % self.TargetIndex)
				self.Cam = None
			if self.TargetIndex == 0:
#				call(["v4l2-ctl", "-c", "exposure_auto=1"])
#				call(["v4l2-ctl", "-c", "exposure_absolute=5"])
#				call(["v4l2-ctl", "-c", "brightness=30"])
				pass
			#TODO: Set up exposure for second camera!

	def getAnswer(self):
		self.AnswerLock.acquire()
		Ans = self.Answer
		self.AnswerLock.release()
		if Ans is None:
			Ans = (False, None, 0, 0)
		frame, flag, px, py = Ans
		try:
			cv2.imshow("Image", frame)
			cv2.waitKey(10)
		except:
			logger.error("Unable to display image!!!")
		return Ans

	#This function finds the target given a camera and a type of target to look for.
	#Type is defined as follows: 0 = High Boiler Target; 1 = Gear Delivery Target.
	#Returns a tuple with the following objects: Image containing the view of the target,
	# a boolean flag indicating wheather a target was detected, and the X and Y offset
	# of the target from the center of the image.
	def FindTarget(self, Cam, Type):
		try:
			ret, Frame = Cam.read()
		except Exception as e:
			ret = None
			Frame = None
			logger.error("Unable to take image from cam %d (%s): " % (self.TargetIndex, str(e)))
		if not ret or (Frame is None):
			Frame = np.zeros((480,640,3), np.uint8)
			# ToDo: Write something on the frame to indicate the frame was not from the camera.
			return (Frame, False, 0, 0)
		return findtarget.FindTarget(Frame, Type)

		return (Frame, True, 10, 15)

	def FindTarget(self, Cam, Type):
		haveErr = False
		FramesGrabbed = 0
		FPS = 0
		BenchmarkTimes = [] #StartGrabTime, StartColorTime, StartEncodeTime, StartSendTime, EndTime
		AverageTimes = [] #Array containing several copies of BenchmarkTime (s)
		StartTime = time.time()
		err = ""
		BenchmarkTimes.append(time.time())
		self.TargetSwitchLock.acquire()
		newindex = self.TargetNewIndex
		self.TargetSwitchLock.release()
		if newindex != self.TargetIndex:
			self.setTargetForReal(newindex)
		haveFrame = False
		if Cam is not None:
			try:
				ret, Frame = Cam.read()
				haveFrame = True
				haveErr = False
			except Exception as e:
				if not haveErr:
					logger.error("Unable to take image from Cam %d: " % self.TargetIndex + str(e))
					err = "Cam Error at Jetson"
				haveErr = True
				haveFrame = False
		if not haveFrame:
			Frame = np.zeros((480,640,3), np.uint8)
		try:
			ImHLS = cv2.cvtColor(Frame, cv2.COLOR_BGR2HLS)
			if Type == 0:
				Out = cv2.inRange(ImHLS, (Hue[0], Luminance[0], Saturation[0]), (Hue[1], Luminance[1], Saturation[1]))
				_, OkContours, _ = cv2.findContours(Out, mode=cv2.RETR_LIST, method=cv2.CHAIN_APPROX_SIMPLE)
				BetterContours = []
				for Contour in OkContours:
					x, y, w, h = cv2.boundingRect(Contour)
					if w > MinWidth and w < MaxWidth:
						if h > MinHeight and h < MaxHeight:
							Area = cv2.contourArea(Contour)
							if Area > MinArea:
								if cv2.arcLength(Contour, True) > MinPerimeter:
									Hull = cv2.convexHull(Contour)
									Solid = 100 * Area / cv2.contourArea(Hull)
									if Solid > Solidity[0] and Solid < Solidity[1]:
										if len(Contour) > MinVertices and len(Contour) < MaxVertices:
											Ratio = (float)(w) / h
											if Ratio > MinRatio and Ratio < MaxRatio:
												BetterContours.append(Contour)
				BetterContours = sorted(BetterContours, key=cv2.contourArea, reverse=True)[:2] #Keep 2 largest
				cv2.drawContours(Frame, BetterContours, -1, (0, 200, 0), 2)
				Centers = []
				Height, Width, Channels = Frame.shape
				cv2.line(Frame, (Width / 2, (Height / 2) - 10), (Width / 2, (Height / 2) + 10), (255, 255, 255), 1) #Crosshair Y
				cv2.line(Frame, ((Width / 2) - 10, Height / 2), ((Width / 2) + 10, Height / 2), (255, 255, 255), 1) #Crosshair X
				CenterImage = ((Width / 2, Height / 2))
				if len(BetterContours) == 2:
					for Contour in BetterContours:
						M = cv2.moments(Contour)
						cX = int(M["m10"] / M["m00"])
						cY = int(M["m01"] / M["m00"])
						Centers.append((cX, cY))
					XDistance = abs(Centers[0][0] - Centers[1][0])
					YDistance = abs(Centers[0][1] - Centers[1][1])
					if XDistance < MaxHorizontalOffset and XDistance > MinHorizontalOffset and YDistance < MaxVerticalOffset and YDistance > MinVerticalOffset:
						LinePoints = [(Centers[0][0], 0), (Centers[1][0], Height)]
						cv2.line(Frame, (Centers[0][0], 0), (Centers[1][0], Height), (255, 255, 255), 1) #Line through center of target Y
						cv2.line(Frame, (0, (Centers[0][1] + Centers[1][1]) / 2), (Width, (Centers[0][1] + Centers[1][1]) / 2), (255, 255, 255), 1) #Line through center of target X
						CenterTarget = (((Centers[0][0] + Centers[1][0]) / 2), (Centers[0][1] + Centers[1][1]) / 2)
						cv2.line(Frame, CenterTarget, (255, 255, 255), 1) #Line connecting center of target and center of image
						cv2.line(Frame, CenterTarget, ((Width / 2), (Height / 2)), (255, 255, 255), 1) #Line connecting center of target and center of image
						OffsetX = CenterTarget[0] - (Width / 2)
						OffsetY = CenterTarget[1] - (Height / 2)
						Offset = str(OffsetX) + "," + str(OffsetY)
						Value = True
					else:
						Offset = "0, 0"
						Value = False
						return Frame, Value, Offset
				else:
					Offset = "0, 0"
					Value = False
					return Frame, Value, Offset
				cv2.putText(Frame, Offset, (30, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 255, 255), 2, cv2.LINE_AA)
				if Demo == True:
					cv2.imshow("Processed image output:", Frame)
					cv2.waitKey(1)
				return Frame, Value, Offset
			elif Type == 1:
				pass #WORK IN PROGRESS FOR PEG DELIVERY AUTOAIM TARGETING
		except Exception as e:
			logger.error("Error autoaiming! " + str(e))
			traceback.print_exc()

	def run(self):
		logger.info("TargetingThread started!")
		while True:
			self.TargetSwitchLock.acquire()
			targetindex = self.TargetNewIndex
			self.TargetSwitchLock.release()
			if targetindex != self.TargetIndex:
				self.setTargetForReal(targetindex)
			try:
				Ans = self.FindTargetSim(self.Cam, targetindex)
			except Exception as e:
				logger.error("Unable to send offset to client: " + str(e))
				Ans = (targetindex, False, 0, 0)
			self.AnswerLock.acquire()
			self.Answer = Ans
			self.AnswerLock.release()
