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

import org.usfirst.frc4415.SteamShipBot1Final.commands.*;
import edu.wpi.first.wpilibj.smartdashboard.SmartDashboard;
import edu.wpi.first.wpilibj.Joystick;
import edu.wpi.first.wpilibj.buttons.*;
import org.usfirst.frc4415.SteamShipBot1Final.subsystems.*;


/**
 * This class is the glue that binds the controls on the physical operator
 * interface to the commands and command groups that allow control of the robot.
 */
public class OI {
    //// CREATING BUTTONS
    // One type of button is a joystick button which is any button on a joystick.
    // You create one by telling it which joystick it's on and which button
    // number it is.
    // Joystick stick = new Joystick(port);
    // Button button = new JoystickButton(stick, buttonNumber);

    // There are a few additional built in buttons you can use. Additionally,
    // by subclassing Button you can create custom triggers and bind those to
    // commands the same as any other Button.

    //// TRIGGERING COMMANDS WITH BUTTONS
    // Once you have a button, it's trivial to bind it to a button in one of
    // three ways:

    // Start the command when the button is pressed and let it run the command
    // until it is finished as determined by it's isFinished method.
    // button.whenPressed(new ExampleCommand());

    // Run the command while the button is being held down and interrupt it once
    // the button is released.
    // button.whileHeld(new ExampleCommand());

    // Start the command when the button is released  and let it run the command
    // until it is finished as determined by it's isFinished method.
    // button.whenReleased(new ExampleCommand());


    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    public JoystickButton forwardButton;
    public JoystickButton backwardButton;
    public JoystickButton toggleDriveButton;
    public JoystickButton toggleDirectionButton;
    public JoystickButton toggleGearHandlerButton;
    public JoystickButton toggleGyroButton;
    public JoystickButton strafeLeftButton;
    public JoystickButton strafeRightButton;
    public JoystickButton toggleGearGripButton;
    public Joystick driverJoystick;
    public JoystickButton toggleShooterButton;
    public JoystickButton cam1Button;
    public JoystickButton cam2Button;
    public JoystickButton cam3Button;
    public JoystickButton cam4Button;
    public JoystickButton autoAimButton;
    public JoystickButton turretResetButton;
    public Joystick shooterJoystick;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS

    public OI() {
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS

        shooterJoystick = new Joystick(1);
        
        turretResetButton = new JoystickButton(shooterJoystick, 7);
        turretResetButton.whenPressed(new TurretReset());
        autoAimButton = new JoystickButton(shooterJoystick, 6);
        autoAimButton.whenPressed(new TurretAutoAim());
        cam4Button = new JoystickButton(shooterJoystick, 3);
        cam4Button.whenPressed(new FuelTankToggleWing());
        cam3Button = new JoystickButton(shooterJoystick, 1);
        cam3Button.whenPressed(new CameraSystemCam3());
        cam2Button = new JoystickButton(shooterJoystick, 2);
        cam2Button.whenPressed(new CameraSystemCam2());
        cam1Button = new JoystickButton(shooterJoystick, 4);
        cam1Button.whenPressed(new CameraSystemCam1());
        toggleShooterButton = new JoystickButton(shooterJoystick, 5);
        toggleShooterButton.whenPressed(new ShooterToggleShooter());
        driverJoystick = new Joystick(0);
        
        toggleGearGripButton = new JoystickButton(driverJoystick, 4);
        toggleGearGripButton.whenPressed(new GearHandlerToggleGearGrip());
        strafeRightButton = new JoystickButton(driverJoystick, 10);
        strafeRightButton.whileHeld(new DriveTrainStrafeRight());
        strafeLeftButton = new JoystickButton(driverJoystick, 9);
        strafeLeftButton.whileHeld(new DriveTrainStrafeLeft());
        toggleGyroButton = new JoystickButton(driverJoystick, 2);
        toggleGyroButton.whenPressed(new DriveTrainToggleGyro());
        toggleGearHandlerButton = new JoystickButton(driverJoystick, 3);
        toggleGearHandlerButton.whenPressed(new GearHandlerToggleGearHandler());
        toggleDirectionButton = new JoystickButton(driverJoystick, 1);
        toggleDirectionButton.whenPressed(new DriveTrainToggleDirection());
        toggleDriveButton = new JoystickButton(driverJoystick, 5);
        toggleDriveButton.whenPressed(new DriveTrainToggleDrive());
        backwardButton = new JoystickButton(driverJoystick, 7);
        backwardButton.whileHeld(new ClimberBackward());
        forwardButton = new JoystickButton(driverJoystick, 6);
        forwardButton.whileHeld(new ClimberForward());


        // SmartDashboard Buttons
        SmartDashboard.putData("AutoSideGearAndShoot", new AutoSideGearAndShoot());
        SmartDashboard.putData("Target Default", new TargetDefault());

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
    }

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=FUNCTIONS
    public Joystick getDriverJoystick() {
        return driverJoystick;
    }

    public Joystick getShooterJoystick() {
        return shooterJoystick;
    }


    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=FUNCTIONS
}
