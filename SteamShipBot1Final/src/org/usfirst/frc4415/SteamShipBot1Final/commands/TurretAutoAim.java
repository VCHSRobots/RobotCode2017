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
import java.util.ArrayList;

import edu.wpi.first.wpilibj.RobotDrive;
import edu.wpi.first.wpilibj.command.Command;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;

import org.usfirst.frc4415.SteamShipBot1Final.PIDController;
import org.usfirst.frc4415.SteamShipBot1Final.PIDRobotDriveRotate;
import org.usfirst.frc4415.SteamShipBot1Final.PIDTurret;
import org.usfirst.frc4415.SteamShipBot1Final.Robot;
import org.usfirst.frc4415.SteamShipBot1Final.subsystems.Turret;

/**
 *
 */
public class TurretAutoAim extends Command {
	
	ArrayList<PIDController> autoProgram;
	RobotDrive robotDrive = Robot.driveTrain.getRobotDrive();
	Turret turret = Robot.turret;
	int autoStage = 0;
	long startTime; 
    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS
 
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_DECLARATIONS

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
    public TurretAutoAim() {

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTOR
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING

        // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=VARIABLE_SETTING
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
        requires(Robot.turret);

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
        requires(Robot.driveTrain);
    }

    // Called just before this Command runs the first time
    protected void initialize() {
    	Robot.driveTrain.invertMotorsArcade();
    	Robot.driveTrain.setMecanum();
    	Robot.target.on();
    	autoStage = 0;
    	startTime = System.currentTimeMillis();
    	
    	autoProgram = new ArrayList<>();
    	autoProgram.add(new PIDRobotDriveRotate(
    			robotDrive, 0, false, 200, 10000));
    	autoProgram.get(0).setPGain(Robot.tableReader.get("pgainrotatetarget", 0.001));
    	autoProgram.get(0).setDeadband(Robot.tableReader.get("deadbandrotatetarget", 0.1));
    	autoProgram.get(0).setClipping(1);
    	
    	autoProgram.add(new PIDTurret(
    			turret, 0, 4, 10000));
    	autoProgram.get(1).setPGain(Robot.tableReader.get("pgainturret", 0.01));
    	autoProgram.get(1).setDeadband(Robot.tableReader.get("deadbandturret", 0.05));
    	autoProgram.get(1).setClipping(1);
    	
    }

    // Called repeatedly when this Command is scheduled to run
    protected void execute() {
    	double time = (double) (System.currentTimeMillis() - startTime);
    	double feedback = Robot.targetReportMonitor.report().x1000() * -1.0;
    	SmartDashboard.putNumber("Feedback", feedback);
    	autoProgram.get(autoStage).run(feedback);
    	System.out.println(autoProgram.get(autoStage));
    	if(autoProgram.get(autoStage).isDone()){
    		autoStage++;
    	}
    }

    // Make this return true when this Command no longer needs to run execute()
    protected boolean isFinished() {
        return autoStage >= autoProgram.size();
    }

    // Called once after isFinished returns true
    protected void end() {
    	Robot.target.off();
    	Robot.driveTrain.set(0);
    	Robot.turret.turn(0);
    }

    // Called when another command which requires one or more of the same
    // subsystems is scheduled to run
    protected void interrupted() {
    	end();
    }
}
