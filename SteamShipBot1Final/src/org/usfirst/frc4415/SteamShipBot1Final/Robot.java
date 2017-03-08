// RobotBuilder Version: 2.0
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// Java from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in the future.


package org.usfirst.frc4415.SteamShipBot1Final;

import edu.wpi.first.wpilibj.CameraServer;
import edu.wpi.first.wpilibj.DriverStation;
import edu.wpi.first.wpilibj.IterativeRobot;
import edu.wpi.first.wpilibj.SPI;
import edu.wpi.first.wpilibj.command.Command;
import edu.wpi.first.wpilibj.command.Scheduler;
import edu.wpi.first.wpilibj.livewindow.LiveWindow;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;

import org.usfirst.frc4415.SteamShipBot1Final.commands.*;
import org.usfirst.frc4415.SteamShipBot1Final.subsystems.*;

import com.kauailabs.navx.frc.AHRS;

import org.usfirst.frc4415.SteamShipBot1Final.Robot;

import edu.wpi.first.wpilibj.CameraServer;

/**
 * The VM is configured to automatically run this class, and to call the
 * functions corresponding to each mode, as described in the IterativeRobot
 * documentation. If you change the name of this class or the package after
 * creating this project, you must also update the manifest file in the resource
 * directory.
 */
public class Robot extends IterativeRobot {

    Command autonomousCommand;

    public static OI oi;
    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    public static DriveTrain driveTrain;
    public static Shooter shooter;
    public static Blender blender;
    public static Climber climber;
    public static Turret turret;
    public static GearHandler gearHandler;
    public static CameraSystem cameraSystem;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS

    String hostName = "10.44.15.19";
    int port = 5800;
    
    public static CameraServer server1;
    public static CameraServer server2;
    public static AHRS navX;
    public static TableReader tableReader;
    public static MouseReader mouseReader;
    public static TargetReader targetReader;
    
    /**
     * This function is run when the robot is first started up and should be
     * used for any initialization code.
     */
    public void robotInit() {
    RobotMap.init();
    
	    try {
			navX = new AHRS(SPI.Port.kMXP); 
		} catch (RuntimeException ex ) {
			DriverStation.reportError("Error instantiating navX MXP:  " + ex.getMessage(), true);
			navX = null;
		}
    
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
        driveTrain = new DriveTrain();
        shooter = new Shooter();
        blender = new Blender();
        climber = new Climber();
        turret = new Turret();
        gearHandler = new GearHandler();
        cameraSystem = new CameraSystem();

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
        // OI must be constructed after subsystems. If the OI creates Commands
        //(which it very likely will), subsystems are not guaranteed to be
        // constructed yet. Thus, their requires() statements may grab null
        // pointers. Bad news. Don't move it.
        oi = new OI();

        // instantiate the command used for the autonomous period
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=AUTONOMOUS

        autonomousCommand = new AutonomousCommand();

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=AUTONOMOUS
        
        server1 = CameraServer.getInstance();
        //server.setQuality(50);
        //the camera name (ex "cam0") can be found through the roborio web interface
        server1.startAutomaticCapture("cam1", 0);
     
        server2 = CameraServer.getInstance();
        //server.setQuality(50);
        //the camera name (ex "cam0") can be found through the roborio web interface
        server2.startAutomaticCapture("cam2", 1);
        
        tableReader = new TableReader(hostName, port);
        mouseReader = new MouseReader(hostName, port, navX);
        targetReader = new TargetReader(hostName, port, navX);
        
        targetReader.SetTargetRequest("T1");
        
        tableReader.start();
        mouseReader.start(); 
        targetReader.start();
        
        Robot.cameraSystem.ledOff();
    }

    private void CommonDashboardReport(){
        SmartDashboard.putNumber("X Field Number", mouseReader.getXField());
        SmartDashboard.putNumber("Y Field Number", mouseReader.getYField());
        
        SmartDashboard.putNumber("TargetComm Restarts", targetReader.getNumRestarts());
        SmartDashboard.putNumber("TargetComm Reports",  targetReader.getNumReports());
        
        SmartDashboard.putNumber("TableComm Restarts",  tableReader.getNumRestarts());
        SmartDashboard.putNumber("TableComm Updates",    tableReader.getNumUpdates());      
        SmartDashboard.putNumber("TableComm TimeChecks",  tableReader.getNumTimeStampChecks()); 
        
        SmartDashboard.putNumber("MouseComm  Restarts", mouseReader.getNumRestarts());
        SmartDashboard.putNumber("MouseComm. Reports",  mouseReader.getNumReports());
    }
    
    
    /**
     * This function is called when the disabled button is hit.
     * You can use it to reset subsystems before shutting down.
     */
    public void disabledInit(){
    	Robot.cameraSystem.ledOff();
        CommonDashboardReport();
    }

    public void disabledPeriodic() {
        Scheduler.getInstance().run();
        CommonDashboardReport();
    }

    public void autonomousInit() {
        // schedule the autonomous command (example)
        if (autonomousCommand != null) autonomousCommand.start();
        CommonDashboardReport();
    }

    /**
     * This function is called periodically during autonomous
     */
    public void autonomousPeriodic() {
        Scheduler.getInstance().run();
        CommonDashboardReport();
    }

    public void teleopInit() {
        // This makes sure that the autonomous stops running when
        // teleop starts running. If you want the autonomous to
        // continue until interrupted by another command, remove
        // this line or comment it out.
        if (autonomousCommand != null) autonomousCommand.cancel();
        
        Robot.driveTrain.changeDrive = false;
        Robot.driveTrain.setMecanum();
    	Robot.driveTrain.invertDrive = -1;
    	Robot.driveTrain.gyroEnable = 0;				// Gyro is off
    	Robot.shooter.toggleShooter = false;
    	Robot.shooter.speed = -.75;
    	Robot.gearHandler.toggleHandler = false;
    	Robot.gearHandler.toggleGear = true;
    	
    	CommonDashboardReport();
    }

    /**
     * This function is called periodically during operator control
     */
    public void teleopPeriodic() {
        Scheduler.getInstance().run();
    	CommonDashboardReport();
    }

    /**
     * This function is called periodically during test mode
     */
    public void testPeriodic() {
        LiveWindow.run();
    	CommonDashboardReport();
    }
}
