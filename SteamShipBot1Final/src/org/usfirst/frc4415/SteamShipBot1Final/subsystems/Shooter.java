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
import com.ctre.CANTalon;

import edu.wpi.first.wpilibj.command.Subsystem;


/**
 *
 */
public class Shooter extends Subsystem {

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS
	
	public boolean toggleShooter = false;
	public double speed = -.75;

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    private final CANTalon shooterMotor = RobotMap.shootershooterMotor;

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS


    // Put methods for controlling this subsystem
    // here. Call these from Commands.

    public void initDefaultCommand() {
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND

        setDefaultCommand(new ShooterDefault());

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND

        // Set the default command for a subsystem here.
        // setDefaultCommand(new MySpecialCommand());
    }
    
    public void toggleShooter() {
    	toggleShooter = !toggleShooter;
    }
    
    public boolean getToggleShooter() {
    	return toggleShooter;
    }
    
    public void set() {
    	shooterMotor.set(speed);
    }
    
    public void set(double power){
    	shooterMotor.set(power);
    }
    
    public void setOff() {
    	shooterMotor.set(0);
    }
    
    public void speedUp() {
    	speed = speed - .005; 
    }
    
    public void slowDown() {
    	speed = speed + .005;
    }
    
    public double showSpeed() {
    	return -1 * speed;
    }
    
}

