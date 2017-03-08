// RobotBuilder Version: 2.0
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// Java from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in the future.


package org.usfirst.frc4415.SteamShipBot1Final.subsystems;

import org.usfirst.frc4415.SteamShipBot1Final.RobotMap;
import org.usfirst.frc4415.SteamShipBot1Final.commands.*;
import org.usfirst.frc4415.SteamShipBot1Final.Robot;

import com.ctre.CANTalon;
import com.kauailabs.navx.frc.AHRS;

import edu.wpi.first.wpilibj.DoubleSolenoid;
import edu.wpi.first.wpilibj.DriverStation;
import edu.wpi.first.wpilibj.Encoder;
import edu.wpi.first.wpilibj.RobotDrive;
import edu.wpi.first.wpilibj.SPI;
import edu.wpi.first.wpilibj.Timer;
import edu.wpi.first.wpilibj.command.Subsystem;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;


/**
 *
 */
public class DriveTrain extends Subsystem {

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS
	
	public boolean changeDrive = true;		// TRUE = MECANUM, FALSE = ARCADE
	public int invertDrive = 1;
	double strafe = .75;
	public int gyroEnable = 1;
	//public AHRS ahrs;
	

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    private final CANTalon frontLeft = RobotMap.driveTrainfrontLeft;
    private final CANTalon frontRight = RobotMap.driveTrainfrontRight;
    private final CANTalon rearLeft = RobotMap.driveTrainrearLeft;
    private final CANTalon rearRight = RobotMap.driveTrainrearRight;
    private final RobotDrive robotDrive4 = RobotMap.driveTrainRobotDrive4;
    private final DoubleSolenoid changeSolenoid = RobotMap.driveTrainchangeSolenoid;
    private final Encoder quadratureEncoder1 = RobotMap.driveTrainQuadratureEncoder1;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS


    // Put methods for controlling this subsystem
    // here. Call these from Commands.

    public void initDefaultCommand() {
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND

        setDefaultCommand(new DriveTrainDefault());

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
    }
    
	public void changeGyro0() {
		if ( gyroEnable == 0) {
			gyroEnable = 1;
		} else {
			gyroEnable = 0;
		}
	}

	public int getGyro0() {
		return gyroEnable;
	}

	public void gyroMecanumDrive() {
		try {
			robotDrive4.mecanumDrive_Cartesian(Robot.oi.getDriverJoystick().getRawAxis(0) * invertDrive, 
					Robot.oi.getDriverJoystick().getRawAxis(1) * invertDrive, 
					Robot.oi.getDriverJoystick().getRawAxis(4), 
					Robot.navX.getAngle() * gyroEnable);
		} catch( RuntimeException ex ) {
			DriverStation.reportError("Error communicating with drive system:  " + ex.getMessage(), true);
		}
		Timer.delay(0.005);		// wait for a motor update time

	}	

	// is this really needed? if the motors are mapped correctly, shouldn't the motors be the same for both drive modes?
	public void invertMotorsMecanum(){
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontLeft, true);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearLeft, true);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontRight, false);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearRight, false);
	}
	
	public void arcadeDrive(){
		robotDrive4.arcadeDrive(Robot.oi.getDriverJoystick().getRawAxis(1) * invertDrive, 
				Robot.oi.getDriverJoystick().getRawAxis(4));
	}	
	
	public void arcadeDrive(double yValue, double xValue){
		robotDrive4.arcadeDrive(yValue, xValue);
	}

	//Math.max(Robot.oi.getSteam1Joystick().getRawAxis(2), Robot.oi.getSteam1Joystick().getRawAxis(0)));
	
	// is this really needed? if the motors are mapped correctly, the inverts should be the same for both drive modes?
	public void invertMotorsArcade(){
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontLeft, false);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearLeft, false);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontRight, false);
		RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearRight, false);
	}

	public void setMecanum(){
		changeDrive = true;
		changeSolenoid.set(DoubleSolenoid.Value.kReverse);
	}

	public void setArcade(){
		changeDrive = false;
		changeSolenoid.set(DoubleSolenoid.Value.kForward);
	}

	public void toggleChangeDrive() {
		changeDrive = !changeDrive;
	}

	public boolean getChangeDrive() {
		return changeDrive;
	}

	public void setInvertDrive() {
		invertDrive = invertDrive * -1;
	}

	public int getInvertDrive() {
		return invertDrive;
	}

	public void strafeLeft() {
		frontLeft.set(-1 * strafe * invertDrive);
		frontRight.set(strafe * invertDrive);
		rearLeft.set(strafe * invertDrive);
		rearRight.set(-1 * strafe * invertDrive);
	}

	public void strafeRight() {
		frontLeft.set(strafe * invertDrive);
		frontRight.set(-1 * strafe * invertDrive);
		rearLeft.set(-1 * strafe * invertDrive);
		rearRight.set(strafe * invertDrive);
	}

	public void motorsOff() {
		frontLeft.set(0);
		frontRight.set(0);
		rearLeft.set(0);
		rearRight.set(0);

	}
	
	public int getEncoder(){
		return quadratureEncoder1.get();
	}
	
	// yValue positive = encoder value increase = drive toward shooter = "Backwards" = "negative setpoint"
	public void arcadePIDMove(double distance) {
		
		// gear forward 'equivalent' wheel size = 4.35", or 13.66666" per rev
		// shooter fwd 'equivalent' wheel size = 4.19108", or 13.16666" per rev
		
		quadratureEncoder1.reset(); // REMOVE THIS LINE AFTER DEBUGGING
		
		long timeoutStart = System.currentTimeMillis();
		int pIDTimeout = 10000;
		
		invertMotorsArcade();
		setArcade();
		
		double inchToTicksLoadingStation = 9.36585;
		double ticksToInchLoadingStation = 0.10677;
		double inchToTicksBoiler = 9.75238;
		double ticksToInchBoiler = 0.10254;
		double inchToTicksHopper = 9.60000;
		double ticksToInchHopper = 0.10417;
		double inchToTicksComputers = 9.45231;
		double ticksToInchComputers = 0.10579;
		double pGain = -0.03;
		double iGain = -0.01;
		double pIDClipping = 0.5;
		double threshold = 0.5;

		int encoderStart = quadratureEncoder1.get();
		int encoderCurrent = encoderStart;
		int encoderLast = encoderStart;
		double currentPosition = 0;
		double setpoint = Robot.tableReader.get("pidmove", 12.0);
		
		boolean done = false;
		int loopCounter = 0;
		int thresholdCounter = 20;
		boolean accumulatorEnable = false;
		double accumulator = 0;
		boolean movingForward = false;
		if(setpoint>0){
			movingForward = true;
		}
		
		while(!done){
			encoderLast = encoderCurrent;
			encoderCurrent = quadratureEncoder1.get();
			
			if(encoderCurrent>encoderLast){
				currentPosition -= (encoderCurrent - encoderLast) * ticksToInchBoiler;
				
			} else {
				currentPosition -= (encoderCurrent - encoderLast) * ticksToInchLoadingStation;
			}
			
			// pTerm is negative when driving "forward" or towards gear
			double pTerm = Robot.tableReader.get("pgain", pGain) * (setpoint - currentPosition);
			
			double iTerm = 0;
			if((movingForward && currentPosition >= setpoint) 
					|| (!movingForward && currentPosition <= setpoint)){
				accumulatorEnable = true;				
			}
			if(accumulatorEnable){
				accumulator += setpoint - currentPosition;
				// iTerm is negative when driving "forward" or towards gear
				iTerm = Robot.tableReader.get("igain", iGain)* accumulator;
			}
			
			double yValue = Math.max(Robot.tableReader.get("pidclipping", pIDClipping) * -1,  
					Math.min(Robot.tableReader.get("pidclipping", pIDClipping), pTerm+iTerm));
			robotDrive4.arcadeDrive(yValue, 0);
			
			if(Math.abs(setpoint - currentPosition) < Robot.tableReader.get("threshold", threshold)) {
				loopCounter++;
			} else {
				loopCounter = 0;
			}
			
			if(loopCounter > Robot.tableReader.get("thresholdcounter", thresholdCounter) || (System.currentTimeMillis()-timeoutStart>Robot.tableReader.get("pidtimeout", pIDTimeout))) {
				done = true;
			}
			
			try {
				Thread.sleep(10);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			System.out.print("Set: " + setpoint);
			System.out.printf("  Pos: %4.3f", currentPosition);
			System.out.print("  Dir: ");
			if(currentPosition<setpoint) System.out.print("Gear");
			else System.out.print("Shooter");
			System.out.printf("  pTerm: %3.3f  iTerm: %3.3f", pTerm, iTerm);
			System.out.println("  Done: " + done);
			
		}
	}
	
}

