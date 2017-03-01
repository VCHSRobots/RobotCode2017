// RobotBuilder Version: 2.0
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// Java from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in the future.


package org.usfirst.frc4415.SteamShipBot2.subsystems;

import org.usfirst.frc4415.SteamShipBot2.Robot;
import org.usfirst.frc4415.SteamShipBot2.RobotMap;
import org.usfirst.frc4415.SteamShipBot2.commands.*;
import com.ctre.CANTalon;
import com.kauailabs.navx.frc.AHRS;

import edu.wpi.first.wpilibj.DoubleSolenoid;
import edu.wpi.first.wpilibj.DriverStation;
import edu.wpi.first.wpilibj.RobotDrive;
import edu.wpi.first.wpilibj.SPI;
import edu.wpi.first.wpilibj.Timer;
import edu.wpi.first.wpilibj.command.Subsystem;


/**
 *
 */
public class DriveTrain extends Subsystem {

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS
	
	public boolean changeDrive = true;
	public int invertDrive = 1;
    public int gyro0 = 1;
    AHRS ahrs;

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    private final CANTalon frontLeft = RobotMap.driveTrainfrontLeft;
    private final CANTalon frontRight = RobotMap.driveTrainfrontRight;
    private final CANTalon rearLeft = RobotMap.driveTrainrearLeft;
    private final CANTalon rearRight = RobotMap.driveTrainrearRight;
    private final RobotDrive robotDrive4 = RobotMap.driveTrainRobotDrive4;
    private final DoubleSolenoid changeSolenoid = RobotMap.driveTrainchangeSolenoid;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS


    // Put methods for controlling this subsystem
    // here. Call these from Commands.

    public void initDefaultCommand() {
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND

        setDefaultCommand(new DriveTrainDefault());

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND

        // Set the default command for a subsystem here.
        // setDefaultCommand(new MySpecialCommand());
    }
    
    public void initGryo(){
    	try {
			/***********************************************************************
			 * navX-MXP:
			 * 
			 * - Communication via RoboRIO MXP (SPI, I2C, TTL UART) and USB.            
			 * - See http://navx-mxp.kauailabs.com/guidance/selecting-an-interface.
			 * 
			 * navX-Micro:
			 * - Communication via I2C (RoboRIO MXP or Onboard) and USB.
			 * - See http://navx-micro.kauailabs.com/guidance/selecting-an-interface.
			 * 
			 * Multiple navX-model devices on a single robot are supported.
			 ************************************************************************/
            ahrs = new AHRS(SPI.Port.kMXP); 
        } catch (RuntimeException ex ) {
            DriverStation.reportError("Error instantiating navX MXP:  " + ex.getMessage(), true);
        }
    	
    }
    	
    public void changeGyro0() {
    	if ( gyro0 == 0) {
    		gyro0 = 1;
    	} else {
    		gyro0 = 0;
    	}
    }
    	
    public int getGyro0() {
    	return gyro0;
    }
    
	public void gyroMecanumDrive() {
        
        try {
            /* Use the joystick X axis for lateral movement,            */
            /* Y axis for forward movement, and Z axis for rotation.    */
            /* Use navX MXP yaw angle to define Field-centric transform */
            robotDrive4.mecanumDrive_Cartesian(Robot.oi.getDriverJoystick().getRawAxis(0) * invertDrive, Robot.oi.getDriverJoystick().getRawAxis(1) * invertDrive, 
            		Robot.oi.getDriverJoystick().getRawAxis(2), ahrs.getAngle() * gyro0);
            //ahrs.getAngle()
        } catch( RuntimeException ex ) {
            DriverStation.reportError("Error communicating with drive system:  " + ex.getMessage(), true);
        }
        Timer.delay(0.005);		// wait for a motor update time
        
    }	
	
	public void invertMotorsMecanum(){
    	RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontLeft, true);
        RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearLeft, true);
        RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontRight, false);
        RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearRight, false);
    }
	
	public void steamArcadeDrive(){
    	robotDrive4.arcadeDrive(Robot.oi.getDriverJoystick().getRawAxis(1) * invertDrive, 
    			Robot.oi.getDriverJoystick().getRawAxis(2));
    			
	}	
	
	//Math.max(Robot.oi.getSteam1Joystick().getRawAxis(2), Robot.oi.getSteam1Joystick().getRawAxis(0)));
    public void invertMotorsArcade(){
    	RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontLeft, false);
    	RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearLeft, false);
    	RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kFrontRight, false);
    	RobotMap.driveTrainRobotDrive4.setInvertedMotor(RobotDrive.MotorType.kRearRight, false);
    }
	
	public void setMecanum(){
		changeDrive = true;
    	changeSolenoid.set(DoubleSolenoid.Value.kForward);
    }
    
    public void setArcade(){
    	changeDrive = false;
    	changeSolenoid.set(DoubleSolenoid.Value.kReverse);
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
    
    public AHRS getNavX() {
    	return ahrs;
    }
    
    public void strafeLeft() {
    	frontLeft.set(.9 * invertDrive);
    	frontRight.set(-9 * invertDrive);
    	rearLeft.set(-.9 * invertDrive);
    	rearRight.set(.9 * invertDrive);
    }
    
    public void strafeRight() {
    	frontLeft.set(-.9 * invertDrive);
    	frontRight.set(.9 * invertDrive);
    	rearLeft.set(.9 * invertDrive);
    	rearRight.set(-.9 * invertDrive);
    }
    
    public void motorsOff() {
    	frontLeft.set(0);
    	frontRight.set(0);
    	rearLeft.set(0);
    	rearRight.set(0);
    	
    }
    
}

