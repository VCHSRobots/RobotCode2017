// RobotBuilder Version: 2.0
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// Java from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in the future.


package org.usfirst.frc4415.SteamShipBot2.commands;
import edu.wpi.first.wpilibj.command.Command;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;

import org.usfirst.frc4415.SteamShipBot2.Robot;

/**
 *
 */
public class TurretDefault extends Command {

	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS

	// END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS

	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
	public TurretDefault() {

		// END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
		// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING

		// END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING
		// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
        requires(Robot.turret);

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	}

	// Called just before this Command runs the first time
	protected void initialize() {
	}

	// Called repeatedly when this Command is scheduled to run
	protected void execute() {

		Robot.turret.setTurret();

		if ((Robot.turret.getLeftLimit() == false && Robot.oi.getShooterJoystick().getRawAxis(4) < 0) 
			|| 
			(Robot.turret.getRightLimit() == false && Robot.oi.getShooterJoystick().getRawAxis(4) > 0)) {

			Robot.turret.turretOff();
			
		} else {
			
			Robot.turret.setTurret();
			
		}
		/*if (Robot.oi.getShooterJoystick().getPOV(0) == 90) {
			Robot.turret.turretRight();
		}

		if (Robot.oi.getShooterJoystick().getPOV(0) == 270) {
			Robot.turret.turretLeft();
		}

		if (Robot.turret.getMiddleLimit() == false) {
			Robot.turret.turretOff();
		}*/


		SmartDashboard.putBoolean("Left Limit", Robot.turret.getLeftLimit());
		SmartDashboard.putBoolean("Middle Limit", Robot.turret.getMiddleLimit());
		SmartDashboard.putBoolean("Right Limit", Robot.turret.getRightLimit());

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
