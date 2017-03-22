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
import edu.wpi.first.wpilibj.smartdashboard.SendableChooser;
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
    SendableChooser autoChooser;

    public static OI oi;
    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    public static DriveTrain driveTrain;
    public static Shooter shooter;
    public static Blender blender;
    public static Climber climber;
    public static Turret turret;
    public static GearHandler gearHandler;
    public static CameraSystem cameraSystem;
    public static FuelTank fuelTank;
    public static Target target;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS

    String hostName = "10.44.15.19";
    int port = 5800;
    int m_nCountTeleOpLoop = 0;
    int m_nCountAutoLoop = 0;
    int m_nCountDisabledLoop = 0;
    int m_nCountTestLoop = 0;
    int m_nCountReportPeriod = 200;
    
    public static CameraServer server1;
    public static CameraServer server2;
    public static AHRS navX;
    public static TableReader tableReader;
    public static MouseReader mouseReader;
    public static TargetReader targetReader;
    public static Mqtt mqtt;
    public static AutoParams autoParams;
    public static ShooterThread shooterThread;
    
    /**
     * This function is run when the robot is first started up and should be
     * used for any initialization code.
     */
    public void robotInit() {
    RobotMap.init();
    
	    try {
			navX = new AHRS(SPI.Port.kMXP); 
			navX.reset();
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
        fuelTank = new FuelTank();
        target = new Target();

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
        //autoChooser = new SendableChooser();
        //autoChooser.addDefault("Move Straight", new AutoMoveStraight());
        //autoChooser.addObject("Shoot on Red Team", new AutoShootRed());
        //autoChooser.addObject("Shoot on Blue Team", new AutoShootBlue());
        
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
		mqtt = new Mqtt("10.44.15.19", 5802, "RoboRio");
		mqtt.start();
		autoParams = new AutoParams(mqtt);
        
        //targetReader.SetTargetRequest("T1");
        
        tableReader.start();
        //mouseReader.start(); 
        //targetReader.start();
        
        shooterThread = new ShooterThread();
        shooterThread.start();
        
        Robot.cameraSystem.ledOff();
        Robot.cameraSystem.ledToggle();
    }

    private void commonDashboardReport(){
        SmartDashboard.putNumber("X Field Number", mouseReader.getXField());
        SmartDashboard.putNumber("Y Field Number", mouseReader.getYField());
        
        SmartDashboard.putNumber("TargetComm Restarts", targetReader.getNumRestarts());
        SmartDashboard.putNumber("TargetComm Reports",  targetReader.getNumReports());
        
        SmartDashboard.putNumber("TableComm Restarts",  tableReader.getNumRestarts());
        SmartDashboard.putNumber("TableComm Updates",    tableReader.getNumUpdates());      
        SmartDashboard.putNumber("TableComm TimeChecks",  tableReader.getNumTimeStampChecks()); 
        
        SmartDashboard.putNumber("MouseComm  Restarts", mouseReader.getNumRestarts());
        SmartDashboard.putNumber("MouseComm. Reports",  mouseReader.getNumReports());
          
		SmartDashboard.putNumber("Invert Drive?", Robot.driveTrain.getInvertDrive());
		SmartDashboard.putNumber("X Value", Robot.oi.getDriverJoystick().getRawAxis(0));
		SmartDashboard.putNumber("Y Value", Robot.oi.getDriverJoystick().getRawAxis(1));
		SmartDashboard.putNumber("Z Value", Robot.oi.getDriverJoystick().getRawAxis(2));
		SmartDashboard.putNumber("Turret Value", Robot.oi.getShooterJoystick().getRawAxis(4));
		SmartDashboard.putNumber("Gyro On ? ", Robot.driveTrain.getGyro0());
		SmartDashboard.putBoolean("Mecanum", Robot.driveTrain.getChangeDrive());
		SmartDashboard.putNumber("Gyro Angle: ", Robot.navX.getAngle());
		SmartDashboard.putNumber("Drive Encoder", Robot.driveTrain.getEncoder());

		SmartDashboard.putNumber("IR Sensor", Robot.driveTrain.getIR());
		
		SmartDashboard.putNumber("Camera X Value" , Robot.cameraSystem.getX());
		SmartDashboard.putNumber("Camera Y Value", Robot.cameraSystem.getY());
		SmartDashboard.putNumber("POV", oi.getShooterJoystick().getPOV());
		
		SmartDashboard.putBoolean("Shooter Enabled", Robot.shooter.getShooterToggle());
		SmartDashboard.putNumber("Shooter Encoder", Robot.shooter.getEncoderSpeed());
		SmartDashboard.putNumber("Shooter Output Voltage", Robot.shooter.getOutputVoltage());
		SmartDashboard.putNumber("SetPoint Value", Robot.shooter.getSetpoint());
		
		SmartDashboard.putBoolean("Pin 1", Robot.cameraSystem.getPin1());
		SmartDashboard.putBoolean("Pin 2", Robot.cameraSystem.getPin2());
		SmartDashboard.putBoolean("Pin 3", Robot.cameraSystem.getPin3());
		SmartDashboard.putBoolean("Pin 4", Robot.cameraSystem.getPin4());

		if (Robot.mqtt != null) {
			SmartDashboard.putNumber("MqTT Received", Robot.mqtt.getCountReceived());
			SmartDashboard.putNumber("MqTT Sent",     Robot.mqtt.getCountSent());
			SmartDashboard.putNumber("MqTT Save Msg", Robot.mqtt.getCountSavedMsgs());
			SmartDashboard.putNumber("MqTT Dups",     Robot.mqtt.getCountDups());
			SmartDashboard.putNumber("Mqtt Errors",   Robot.mqtt.getCountErrors());
		}
		

		SmartDashboard.putString("AutoSide",     Robot.autoParams.getSide());
		SmartDashboard.putString("AutoPrm",      Robot.autoParams.getProgram());
		SmartDashboard.putBoolean("AutoDefault", Robot.autoParams.isDefaults());
		
		MqttMsg m = mqtt.getMessage("robot/ds/tstcamlight");
		if (m != null) {
			SmartDashboard.putString("TargetLgjt", m.getMessage());
		}
		else {
			SmartDashboard.putString("TargetLgjt", "null");
		}
		
		SmartDashboard.putString("AutoSide",     Robot.autoParams.getSide());
    }
    
    // ################################################################
    // Stuff that we should always be doing no matter what the mode
    
    public void doCoreFunctions(){
    	MqttMsg m = mqtt.getMessage("robot/ds/tstcamlight");
    	if (m != null) {
    		if (m.getLong() > 0) {
    			target.on();
    		}
    		else {
    			target.off();
    		}
    	}
    	
    }
    
    // ################################################################
    // Disabled MODE

    public void disabledInit(){
        doCoreFunctions();
    	//Robot.cameraSystem.ledOff();
    	m_nCountDisabledLoop = 0;
    	mqtt.logf("Mode: Disabled Mode Selected");
        commonDashboardReport();
    }

    public void disabledPeriodic() {
    	doCoreFunctions();
    	m_nCountDisabledLoop++;
    	if (m_nCountDisabledLoop % m_nCountReportPeriod == 0) {
    		mqtt.logf("Mode: Disabled Loop Count = %d", m_nCountDisabledLoop);
    	}
		Robot.autoParams.loadData();  // Do this a lot before Auto Mode.
    	Robot.shooter.shooterToggle = false;
        Scheduler.getInstance().run();
        commonDashboardReport();
    }
    
    // ################################################################
    // Autonomous MODE

    public void autonomousInit() {
        doCoreFunctions();
        // schedule the autonomous command (example)
    	//autonomousCommand = (Command) autoChooser.getSelected();
    	
        //if (autonomousCommand != null) autonomousCommand.start();

        Robot.autoParams.loadData();  // Do this only ONCE during auto.  This is to avoid changing params during actual auto.
        commonDashboardReport();
        m_nCountAutoLoop = 0;
    	mqtt.logf("Mode: Auto Mode Selected");
        fuelTank.retract();
        navX.reset();
    }

    public void autonomousPeriodic() {
        doCoreFunctions();
    	m_nCountAutoLoop++;
    	if (m_nCountAutoLoop % m_nCountReportPeriod == 0) {
    		mqtt.logf("Mode: Auto Loop Count = %d", m_nCountAutoLoop);
    	}
        Scheduler.getInstance().run();
        commonDashboardReport();
    }

    // ################################################################
    // TeloOP MODE
    
    public void teleopInit() {
        doCoreFunctions();
        // This makes sure that the autonomous stops running when
        // teleop starts running. If you want the autonomous to
        // continue until interrupted by another command, remove
        // this line or comment it out.
        if (autonomousCommand != null) autonomousCommand.cancel();
        
        driveTrain.setArcade();
    	driveTrain.invertDrive = -1;
    	driveTrain.gyroEnable = 0;			// Gyro is off
    	shooter.shooterToggle = false;

    	//shooter.speed = -.75;
    	gearHandler.handlerIn();
    	gearHandler.gearRelease();
    	cameraSystem.setServo1(.62999);
    	cameraSystem.setServo2(.05799);
    	shooter.disarm();
    	fuelTank.retract();
    	
    	Robot.autoParams.loadData();  // Do this a lots during non-auto modes.
    	commonDashboardReport();
    	m_nCountTeleOpLoop = 0;
    	mqtt.logf("Mode: TeleOp Selected");
    	
    	MqttMsg m = mqtt.getMessageByTopic("robot/jetson/ts/x");
    	if (m != null) {
    		
    	}
    }

    public void teleopPeriodic() {
        doCoreFunctions();
    	m_nCountTeleOpLoop++;
    	if (m_nCountTeleOpLoop % m_nCountReportPeriod == 0) {
    		mqtt.logf("Mode: TeleOP Loop Count = %d", m_nCountTeleOpLoop);
    	}
    	Robot.autoParams.loadData();  // No need to do this here, but its nice to keep dashboard updated.
    	Scheduler.getInstance().run();
    	commonDashboardReport();
    }

    // ################################################################
    // TEST MODE

    public void testPeriodic() {
        doCoreFunctions();
    	m_nCountTestLoop++;
    	if (m_nCountTestLoop % m_nCountReportPeriod == 0) {
    		mqtt.logf("Mode: Test Loop Count = %d", m_nCountTestLoop);
    	}
    	Robot.autoParams.loadData();  // Do this a lots during non-auto modes.
        LiveWindow.run();
    	commonDashboardReport();
    }
}
