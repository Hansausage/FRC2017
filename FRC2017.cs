﻿using System;
using System.Collections.Generic;
using System.Linq;
using WPILib;
using WPILib.SmartDashboard;

namespace FRC2017
{
    /// <summary>
    /// The VM is configured to automatically run this class, and to call the
    /// functions corresponding to each mode, as described in the IterativeRobot
    /// documentation. 
    /// </summary>
    public class FRC2017 : IterativeRobot
    {
        const string defaultAuto = "Default";
        const string customAuto = "My Auto";
        string autoSelected;
        SendableChooser chooser;
        RobotDrive drive;
        Joystick stick;
        
        
        
        
        /// <summary>
        /// This function is run when the robot is first started up and should be
        /// used for any initialization code.
        /// </summary>
        public override void RobotInit()
        {
            chooser = new SendableChooser();
            chooser.AddDefault("Default Auto", defaultAuto);
            chooser.AddObject("My Auto", customAuto);
            SmartDashboard.PutData("Chooser", chooser);
            
            //create joystick and robotdrive objects for joystick input and motor control
            stick = new Joystick(0);
            drive = new RobotDrive(0, 1, 2, 3);
        }

        // This autonomous (along with the sendable chooser above) shows how to select between
        // different autonomous modes using the dashboard. The senable chooser code works with
        // the Java SmartDashboard. If you prefer the LabVIEW Dashboard, remove all the chooser
        // code an uncomment the GetString code to get the uto name from the text box below
        // the gyro.
        //You can add additional auto modes by adding additional comparisons to the switch
        // structure below with additional strings. If using the SendableChooser
        // be sure to add them to the chooser code above as well.
        public override void AutonomousInit()
        {
            autoSelected = (string)chooser.GetSelected();
            //autoSelected = SmartDashboard.GetString("Auto Selector", defaultAuto);
            Console.WriteLine("Auto selected: " + autoSelected);
        }

        /// <summary>
        /// This function is called periodically during autonomous
        /// </summary>
        public override void AutonomousPeriodic()
        {
            switch (autoSelected)
            {
                case customAuto:
                    //Put custom auto code here
                    break;
                case defaultAuto:
                default:
                    //Put default auto code here
                    break;
            }
        }

        /// <summary>
        /// This function is called periodically during operator control
        /// </summary>
        public override void TeleopPeriodic()
        {

            //while teleop is enabled, and the drivestation is enabled, run this code
            while(IsOperatorControl && IsEnabled)
            {
                //utilize our drive class to call the ArcadeDrive method and accept input from the stick/joystick object
                drive.TankDrive(-stick.GetRawAxis(1), stick.GetRawAxis(5));
                //create a delay of .1 second
                Timer.Delay(0.1);
            }
           
        }



        /// <summary>
        /// This function is called periodically during test mode
        /// </summary>
        public override void TestPeriodic()
        {

        }
    }
}
