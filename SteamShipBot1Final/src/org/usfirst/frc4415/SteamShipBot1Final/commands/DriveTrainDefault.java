// RobotBuilder Version: 2.0
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// Java from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in the future.


package org.usfirst.frc4415.SteamShipBot1Final.commands;
import edu.wpi.first.wpilibj.command.Command;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;

import org.usfirst.frc4415.SteamShipBot1Final.Robot;

/**
 *
 */
public class DriveTrainDefault extends Command {

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS
 
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
    public DriveTrainDefault() {

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING

        // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
        requires(Robot.driveTrain);

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
    }

    // Called just before this Command runs the first time
    protected void initialize() {

    }

    // Called repeatedly when this Command is scheduled to run
    protected void execute() {
    	
    	System.out.println("LED: " + Robot.cameraSystem.getLED());
    	
    	if ( Robot.oi.getDriverJoystick().getRawButton(8)) {
			Robot.navX.reset();
		}

		if (Robot.driveTrain.getChangeDrive() == true) {
			Robot.driveTrain.invertMotorsMecanum();
			Robot.driveTrain.setMecanum();
			Robot.driveTrain.gyroMecanumDrive();

		} else {
			Robot.driveTrain.gyroEnable = 1;
			Robot.driveTrain.invertMotorsArcade();
			Robot.driveTrain.setArcade();
			Robot.driveTrain.arcadeDrive();
		}

		SmartDashboard.putNumber("Invert Drive?", Robot.driveTrain.getInvertDrive());
		SmartDashboard.putNumber("X Value", Robot.oi.getDriverJoystick().getRawAxis(0));
		SmartDashboard.putNumber("Y Value", Robot.oi.getDriverJoystick().getRawAxis(1));
		SmartDashboard.putNumber("Z Value", Robot.oi.getDriverJoystick().getRawAxis(2));
		SmartDashboard.putNumber("Turret Value", Robot.oi.getShooterJoystick().getRawAxis(4));
		SmartDashboard.putNumber("Gyro On ? ", Robot.driveTrain.getGyro0());
		SmartDashboard.putBoolean("Mecanum", Robot.driveTrain.getChangeDrive());
		SmartDashboard.putNumber("Gyro Angle: ", Robot.navX.getAngle());
		SmartDashboard.putNumber("Drive Encoder", Robot.driveTrain.getEncoder());
		//SmartDashboard.putNumber("Drive RangeFinder", Robot.driveTrain.getRangeFinder());
		
	}

    // Make this return true when this Command no longer needs to run execute()
    protected boolean isFinished() {
        return false;
    }

    // Called once after isFinished returns true
    protected void end() {
    }

    // Called when another command which requires one or more of the same
    // subsystems is scheduled to run
    protected void interrupted() {
    }
}
