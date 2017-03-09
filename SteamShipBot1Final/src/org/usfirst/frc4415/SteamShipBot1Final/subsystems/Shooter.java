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
import com.ctre.CANTalon.TalonControlMode;

import edu.wpi.first.wpilibj.command.Subsystem;


/**
 *
 */
public class Shooter extends Subsystem {

    // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS

    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTANTS
	
	public boolean shooterToggle = false;
	public double speed = -.75;
	private boolean isArmed = false;

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
    
    public double getEncoderSpeed(){
    	return shooterMotor.getSpeed();
    }
    
    public double getEncoderPosition(){
    	return shooterMotor.getPosition();
    }
    
    public void set(double setPoint){
    	shooterMotor.set(setPoint);
    }
    
    public void disarm(){
    	isArmed = false;
    }
    
    public void arm(){
    	isArmed = true;
    }
    
    public boolean getIsArmed(){
    	return isArmed;
    }
    
    public void stopMotor(){
    	shooterMotor.stopMotor();
    	disarm();
    }
    
    public double getOutputVoltage(){
    	return shooterMotor.getOutputVoltage();
    }
    
    public boolean getShooterToggle(){
    	return shooterToggle;
    }
    
    public void toggleShooter(){
    	shooterToggle = !shooterToggle;
    }
    
    public void setSpeedMode(){
        shooterMotor.changeControlMode(TalonControlMode.Speed);
    }
    
    public void setThrottleMode(){
    	shooterMotor.changeControlMode(TalonControlMode.PercentVbus);
    }
    
    public void off(){
    	shooterToggle = false;
    	shooterMotor.changeControlMode(TalonControlMode.PercentVbus);
    	shooterMotor.set(0);
    	isArmed = false;
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

