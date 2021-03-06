﻿namespace MqttShow
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_MainLog = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label_ConnectionStatus = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageTarSys = new System.Windows.Forms.TabPage();
            this.labelParamErrors = new System.Windows.Forms.Label();
            this.buttonForceDefaults = new System.Windows.Forms.Button();
            this.buttonGetParams = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonTargetPeg = new System.Windows.Forms.RadioButton();
            this.radioButtonTargetBoiler = new System.Windows.Forms.RadioButton();
            this.radioButtonTargetNone = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabelSendTargetMode = new System.Windows.Forms.LinkLabel();
            this.textBoxParamEdit = new System.Windows.Forms.TextBox();
            this.buttonSendParams = new System.Windows.Forms.Button();
            this.tabPageMsgs = new System.Windows.Forms.TabPage();
            this.dataGridViewMsgs = new System.Windows.Forms.DataGridView();
            this.tabPageRobot = new System.Windows.Forms.TabPage();
            this.textBoxRobotLog = new System.Windows.Forms.TextBox();
            this.tabPageJetson = new System.Windows.Forms.TabPage();
            this.textBoxJetsonLog = new System.Windows.Forms.TextBox();
            this.tabPageMqttList = new System.Windows.Forms.TabPage();
            this.textBoxMqttList = new System.Windows.Forms.TextBox();
            this.tabPageRio = new System.Windows.Forms.TabPage();
            this.labelRioParamErrors = new System.Windows.Forms.Label();
            this.linkLabelSaveRoboRIOParams = new System.Windows.Forms.LinkLabel();
            this.linkLabelLoadRoboRioParams = new System.Windows.Forms.LinkLabel();
            this.linkLabelSetRoboRioDefaults = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelGetRoboRioParams = new System.Windows.Forms.LinkLabel();
            this.textBoxRoboRioParams = new System.Windows.Forms.TextBox();
            this.linkLabelSendRoboRioParams = new System.Windows.Forms.LinkLabel();
            this.pictureBoxTarget = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonBlueSide = new System.Windows.Forms.RadioButton();
            this.radioButtonRedSide = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonBinAndShoot = new System.Windows.Forms.RadioButton();
            this.radioButtonSideGearAndShoot = new System.Windows.Forms.RadioButton();
            this.radioButtonMoveForward = new System.Windows.Forms.RadioButton();
            this.radioButtonCenterGearAndShoot = new System.Windows.Forms.RadioButton();
            this.radioButtonCenterGear = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabelClearGeneral = new System.Windows.Forms.LinkLabel();
            this.linkLabelClearRobot = new System.Windows.Forms.LinkLabel();
            this.linkLabelClearJetson = new System.Windows.Forms.LinkLabel();
            this.linkLabelClearMqtt = new System.Windows.Forms.LinkLabel();
            this.panelClearBox = new System.Windows.Forms.Panel();
            this.linkLabelSendAuto = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownFrameDecimation = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.checkBoxPauseRobotLog = new System.Windows.Forms.CheckBox();
            this.numericUpDownLedProgram = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageTarSys.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageMsgs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsgs)).BeginInit();
            this.tabPageRobot.SuspendLayout();
            this.tabPageJetson.SuspendLayout();
            this.tabPageMqttList.SuspendLayout();
            this.tabPageRio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelClearBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameDecimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLedProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_MainLog
            // 
            this.textBox_MainLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MainLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MainLog.Location = new System.Drawing.Point(3, 3);
            this.textBox_MainLog.Multiline = true;
            this.textBox_MainLog.Name = "textBox_MainLog";
            this.textBox_MainLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MainLog.Size = new System.Drawing.Size(615, 426);
            this.textBox_MainLog.TabIndex = 0;
            this.textBox_MainLog.WordWrap = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label_ConnectionStatus
            // 
            this.label_ConnectionStatus.AutoSize = true;
            this.label_ConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConnectionStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.label_ConnectionStatus.Location = new System.Drawing.Point(12, 9);
            this.label_ConnectionStatus.Name = "label_ConnectionStatus";
            this.label_ConnectionStatus.Size = new System.Drawing.Size(116, 25);
            this.label_ConnectionStatus.TabIndex = 2;
            this.label_ConnectionStatus.Text = "Connected";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Controls.Add(this.tabPageTarSys);
            this.tabControlMain.Controls.Add(this.tabPageMsgs);
            this.tabControlMain.Controls.Add(this.tabPageRobot);
            this.tabControlMain.Controls.Add(this.tabPageJetson);
            this.tabControlMain.Controls.Add(this.tabPageMqttList);
            this.tabControlMain.Controls.Add(this.tabPageRio);
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(494, 67);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(629, 461);
            this.tabControlMain.TabIndex = 4;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.textBox_MainLog);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(621, 432);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General Log";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageTarSys
            // 
            this.tabPageTarSys.Controls.Add(this.labelParamErrors);
            this.tabPageTarSys.Controls.Add(this.buttonForceDefaults);
            this.tabPageTarSys.Controls.Add(this.buttonGetParams);
            this.tabPageTarSys.Controls.Add(this.panel2);
            this.tabPageTarSys.Controls.Add(this.textBoxParamEdit);
            this.tabPageTarSys.Controls.Add(this.buttonSendParams);
            this.tabPageTarSys.Location = new System.Drawing.Point(4, 25);
            this.tabPageTarSys.Name = "tabPageTarSys";
            this.tabPageTarSys.Size = new System.Drawing.Size(621, 432);
            this.tabPageTarSys.TabIndex = 5;
            this.tabPageTarSys.Text = "TargSys";
            this.tabPageTarSys.UseVisualStyleBackColor = true;
            // 
            // labelParamErrors
            // 
            this.labelParamErrors.AutoSize = true;
            this.labelParamErrors.Location = new System.Drawing.Point(164, 67);
            this.labelParamErrors.Name = "labelParamErrors";
            this.labelParamErrors.Size = new System.Drawing.Size(0, 16);
            this.labelParamErrors.TabIndex = 17;
            // 
            // buttonForceDefaults
            // 
            this.buttonForceDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForceDefaults.Location = new System.Drawing.Point(161, 17);
            this.buttonForceDefaults.Name = "buttonForceDefaults";
            this.buttonForceDefaults.Size = new System.Drawing.Size(129, 30);
            this.buttonForceDefaults.TabIndex = 16;
            this.buttonForceDefaults.Text = "Force Defaults";
            this.buttonForceDefaults.UseVisualStyleBackColor = true;
            this.buttonForceDefaults.Click += new System.EventHandler(this.buttonForceDefaults_Click);
            // 
            // buttonGetParams
            // 
            this.buttonGetParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetParams.Location = new System.Drawing.Point(20, 53);
            this.buttonGetParams.Name = "buttonGetParams";
            this.buttonGetParams.Size = new System.Drawing.Size(129, 30);
            this.buttonGetParams.TabIndex = 15;
            this.buttonGetParams.Text = "Get Params";
            this.buttonGetParams.UseVisualStyleBackColor = true;
            this.buttonGetParams.Click += new System.EventHandler(this.buttonGetParams_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonTargetPeg);
            this.panel2.Controls.Add(this.radioButtonTargetBoiler);
            this.panel2.Controls.Add(this.radioButtonTargetNone);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.linkLabelSendTargetMode);
            this.panel2.Location = new System.Drawing.Point(311, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 83);
            this.panel2.TabIndex = 14;
            // 
            // radioButtonTargetPeg
            // 
            this.radioButtonTargetPeg.AutoSize = true;
            this.radioButtonTargetPeg.Location = new System.Drawing.Point(12, 31);
            this.radioButtonTargetPeg.Name = "radioButtonTargetPeg";
            this.radioButtonTargetPeg.Size = new System.Drawing.Size(51, 20);
            this.radioButtonTargetPeg.TabIndex = 4;
            this.radioButtonTargetPeg.Text = "Peg";
            this.radioButtonTargetPeg.UseVisualStyleBackColor = true;
            this.radioButtonTargetPeg.CheckedChanged += new System.EventHandler(this.radioButtonTargetPeg_CheckedChanged);
            // 
            // radioButtonTargetBoiler
            // 
            this.radioButtonTargetBoiler.AutoSize = true;
            this.radioButtonTargetBoiler.Location = new System.Drawing.Point(12, 57);
            this.radioButtonTargetBoiler.Name = "radioButtonTargetBoiler";
            this.radioButtonTargetBoiler.Size = new System.Drawing.Size(61, 20);
            this.radioButtonTargetBoiler.TabIndex = 3;
            this.radioButtonTargetBoiler.Text = "Boiler";
            this.radioButtonTargetBoiler.UseVisualStyleBackColor = true;
            this.radioButtonTargetBoiler.CheckedChanged += new System.EventHandler(this.radioButtonTargetBoiler_CheckedChanged);
            // 
            // radioButtonTargetNone
            // 
            this.radioButtonTargetNone.AutoSize = true;
            this.radioButtonTargetNone.Checked = true;
            this.radioButtonTargetNone.Location = new System.Drawing.Point(74, 31);
            this.radioButtonTargetNone.Name = "radioButtonTargetNone";
            this.radioButtonTargetNone.Size = new System.Drawing.Size(59, 20);
            this.radioButtonTargetNone.TabIndex = 2;
            this.radioButtonTargetNone.TabStop = true;
            this.radioButtonTargetNone.Text = "None";
            this.radioButtonTargetNone.UseVisualStyleBackColor = true;
            this.radioButtonTargetNone.CheckedChanged += new System.EventHandler(this.radioButtonTargetNone_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Target Mode";
            // 
            // linkLabelSendTargetMode
            // 
            this.linkLabelSendTargetMode.AutoSize = true;
            this.linkLabelSendTargetMode.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabelSendTargetMode.Location = new System.Drawing.Point(93, 57);
            this.linkLabelSendTargetMode.Name = "linkLabelSendTargetMode";
            this.linkLabelSendTargetMode.Size = new System.Drawing.Size(40, 16);
            this.linkLabelSendTargetMode.TabIndex = 0;
            this.linkLabelSendTargetMode.TabStop = true;
            this.linkLabelSendTargetMode.Text = "Send";
            this.linkLabelSendTargetMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSendTargetMode_LinkClicked);
            // 
            // textBoxParamEdit
            // 
            this.textBoxParamEdit.Location = new System.Drawing.Point(20, 106);
            this.textBoxParamEdit.Multiline = true;
            this.textBoxParamEdit.Name = "textBoxParamEdit";
            this.textBoxParamEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxParamEdit.Size = new System.Drawing.Size(464, 311);
            this.textBoxParamEdit.TabIndex = 5;
            this.textBoxParamEdit.WordWrap = false;
            // 
            // buttonSendParams
            // 
            this.buttonSendParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendParams.Location = new System.Drawing.Point(20, 17);
            this.buttonSendParams.Name = "buttonSendParams";
            this.buttonSendParams.Size = new System.Drawing.Size(129, 30);
            this.buttonSendParams.TabIndex = 13;
            this.buttonSendParams.Text = "Send Params";
            this.buttonSendParams.UseVisualStyleBackColor = true;
            this.buttonSendParams.Click += new System.EventHandler(this.buttonSendParams_Click);
            // 
            // tabPageMsgs
            // 
            this.tabPageMsgs.Controls.Add(this.dataGridViewMsgs);
            this.tabPageMsgs.Location = new System.Drawing.Point(4, 25);
            this.tabPageMsgs.Name = "tabPageMsgs";
            this.tabPageMsgs.Size = new System.Drawing.Size(621, 432);
            this.tabPageMsgs.TabIndex = 6;
            this.tabPageMsgs.Text = "Msgs";
            this.tabPageMsgs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMsgs
            // 
            this.dataGridViewMsgs.AllowUserToAddRows = false;
            this.dataGridViewMsgs.AllowUserToDeleteRows = false;
            this.dataGridViewMsgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMsgs.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMsgs.Name = "dataGridViewMsgs";
            this.dataGridViewMsgs.ReadOnly = true;
            this.dataGridViewMsgs.Size = new System.Drawing.Size(621, 432);
            this.dataGridViewMsgs.TabIndex = 0;
            // 
            // tabPageRobot
            // 
            this.tabPageRobot.Controls.Add(this.textBoxRobotLog);
            this.tabPageRobot.Location = new System.Drawing.Point(4, 25);
            this.tabPageRobot.Name = "tabPageRobot";
            this.tabPageRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRobot.Size = new System.Drawing.Size(621, 432);
            this.tabPageRobot.TabIndex = 1;
            this.tabPageRobot.Text = "RoboRio Log";
            this.tabPageRobot.UseVisualStyleBackColor = true;
            // 
            // textBoxRobotLog
            // 
            this.textBoxRobotLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRobotLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRobotLog.Location = new System.Drawing.Point(3, 3);
            this.textBoxRobotLog.Multiline = true;
            this.textBoxRobotLog.Name = "textBoxRobotLog";
            this.textBoxRobotLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRobotLog.Size = new System.Drawing.Size(615, 426);
            this.textBoxRobotLog.TabIndex = 1;
            this.textBoxRobotLog.WordWrap = false;
            // 
            // tabPageJetson
            // 
            this.tabPageJetson.Controls.Add(this.textBoxJetsonLog);
            this.tabPageJetson.Location = new System.Drawing.Point(4, 25);
            this.tabPageJetson.Name = "tabPageJetson";
            this.tabPageJetson.Size = new System.Drawing.Size(621, 432);
            this.tabPageJetson.TabIndex = 2;
            this.tabPageJetson.Text = "Jetson Msgs";
            this.tabPageJetson.UseVisualStyleBackColor = true;
            // 
            // textBoxJetsonLog
            // 
            this.textBoxJetsonLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJetsonLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxJetsonLog.Multiline = true;
            this.textBoxJetsonLog.Name = "textBoxJetsonLog";
            this.textBoxJetsonLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxJetsonLog.Size = new System.Drawing.Size(621, 432);
            this.textBoxJetsonLog.TabIndex = 2;
            this.textBoxJetsonLog.WordWrap = false;
            // 
            // tabPageMqttList
            // 
            this.tabPageMqttList.Controls.Add(this.textBoxMqttList);
            this.tabPageMqttList.Location = new System.Drawing.Point(4, 25);
            this.tabPageMqttList.Name = "tabPageMqttList";
            this.tabPageMqttList.Size = new System.Drawing.Size(621, 432);
            this.tabPageMqttList.TabIndex = 3;
            this.tabPageMqttList.Text = "Mqtt List";
            this.tabPageMqttList.UseVisualStyleBackColor = true;
            // 
            // textBoxMqttList
            // 
            this.textBoxMqttList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMqttList.Location = new System.Drawing.Point(0, 0);
            this.textBoxMqttList.Multiline = true;
            this.textBoxMqttList.Name = "textBoxMqttList";
            this.textBoxMqttList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMqttList.Size = new System.Drawing.Size(621, 432);
            this.textBoxMqttList.TabIndex = 1;
            this.textBoxMqttList.WordWrap = false;
            // 
            // tabPageRio
            // 
            this.tabPageRio.Controls.Add(this.labelRioParamErrors);
            this.tabPageRio.Controls.Add(this.linkLabelSaveRoboRIOParams);
            this.tabPageRio.Controls.Add(this.linkLabelLoadRoboRioParams);
            this.tabPageRio.Controls.Add(this.linkLabelSetRoboRioDefaults);
            this.tabPageRio.Controls.Add(this.label1);
            this.tabPageRio.Controls.Add(this.linkLabelGetRoboRioParams);
            this.tabPageRio.Controls.Add(this.textBoxRoboRioParams);
            this.tabPageRio.Controls.Add(this.linkLabelSendRoboRioParams);
            this.tabPageRio.Location = new System.Drawing.Point(4, 25);
            this.tabPageRio.Name = "tabPageRio";
            this.tabPageRio.Size = new System.Drawing.Size(621, 432);
            this.tabPageRio.TabIndex = 4;
            this.tabPageRio.Text = "Rio Params";
            this.tabPageRio.UseVisualStyleBackColor = true;
            // 
            // labelRioParamErrors
            // 
            this.labelRioParamErrors.AutoSize = true;
            this.labelRioParamErrors.Location = new System.Drawing.Point(302, 17);
            this.labelRioParamErrors.Name = "labelRioParamErrors";
            this.labelRioParamErrors.Size = new System.Drawing.Size(0, 16);
            this.labelRioParamErrors.TabIndex = 26;
            // 
            // linkLabelSaveRoboRIOParams
            // 
            this.linkLabelSaveRoboRIOParams.AutoSize = true;
            this.linkLabelSaveRoboRIOParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSaveRoboRIOParams.Location = new System.Drawing.Point(443, 39);
            this.linkLabelSaveRoboRIOParams.Name = "linkLabelSaveRoboRIOParams";
            this.linkLabelSaveRoboRIOParams.Size = new System.Drawing.Size(135, 20);
            this.linkLabelSaveRoboRIOParams.TabIndex = 25;
            this.linkLabelSaveRoboRIOParams.TabStop = true;
            this.linkLabelSaveRoboRIOParams.Text = "Save To Laptop";
            this.linkLabelSaveRoboRIOParams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSaveRoboRIOParams_LinkClicked);
            // 
            // linkLabelLoadRoboRioParams
            // 
            this.linkLabelLoadRoboRioParams.AutoSize = true;
            this.linkLabelLoadRoboRioParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLoadRoboRioParams.Location = new System.Drawing.Point(443, 13);
            this.linkLabelLoadRoboRioParams.Name = "linkLabelLoadRoboRioParams";
            this.linkLabelLoadRoboRioParams.Size = new System.Drawing.Size(156, 20);
            this.linkLabelLoadRoboRioParams.TabIndex = 24;
            this.linkLabelLoadRoboRioParams.TabStop = true;
            this.linkLabelLoadRoboRioParams.Text = "Load From Laptop";
            this.linkLabelLoadRoboRioParams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLoadRoboRioParams_LinkClicked);
            // 
            // linkLabelSetRoboRioDefaults
            // 
            this.linkLabelSetRoboRioDefaults.AutoSize = true;
            this.linkLabelSetRoboRioDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSetRoboRioDefaults.Location = new System.Drawing.Point(303, 39);
            this.linkLabelSetRoboRioDefaults.Name = "linkLabelSetRoboRioDefaults";
            this.linkLabelSetRoboRioDefaults.Size = new System.Drawing.Size(110, 20);
            this.linkLabelSetRoboRioDefaults.TabIndex = 23;
            this.linkLabelSetRoboRioDefaults.TabStop = true;
            this.linkLabelSetRoboRioDefaults.Text = "Set Defaults";
            this.linkLabelSetRoboRioDefaults.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSetRoboRioDefaults_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Parameters For RoboRIO";
            // 
            // linkLabelGetRoboRioParams
            // 
            this.linkLabelGetRoboRioParams.AutoSize = true;
            this.linkLabelGetRoboRioParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelGetRoboRioParams.Location = new System.Drawing.Point(172, 39);
            this.linkLabelGetRoboRioParams.Name = "linkLabelGetRoboRioParams";
            this.linkLabelGetRoboRioParams.Size = new System.Drawing.Size(104, 20);
            this.linkLabelGetRoboRioParams.TabIndex = 21;
            this.linkLabelGetRoboRioParams.TabStop = true;
            this.linkLabelGetRoboRioParams.Text = "Get Params";
            this.linkLabelGetRoboRioParams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGetRoboRioParams_LinkClicked);
            // 
            // textBoxRoboRioParams
            // 
            this.textBoxRoboRioParams.Location = new System.Drawing.Point(29, 73);
            this.textBoxRoboRioParams.Multiline = true;
            this.textBoxRoboRioParams.Name = "textBoxRoboRioParams";
            this.textBoxRoboRioParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRoboRioParams.Size = new System.Drawing.Size(464, 341);
            this.textBoxRoboRioParams.TabIndex = 17;
            this.textBoxRoboRioParams.WordWrap = false;
            // 
            // linkLabelSendRoboRioParams
            // 
            this.linkLabelSendRoboRioParams.AutoSize = true;
            this.linkLabelSendRoboRioParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSendRoboRioParams.Location = new System.Drawing.Point(25, 39);
            this.linkLabelSendRoboRioParams.Name = "linkLabelSendRoboRioParams";
            this.linkLabelSendRoboRioParams.Size = new System.Drawing.Size(116, 20);
            this.linkLabelSendRoboRioParams.TabIndex = 2;
            this.linkLabelSendRoboRioParams.TabStop = true;
            this.linkLabelSendRoboRioParams.Text = "Send Params";
            this.linkLabelSendRoboRioParams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSendRoboRioParams_LinkClicked);
            // 
            // pictureBoxTarget
            // 
            this.pictureBoxTarget.Location = new System.Drawing.Point(17, 197);
            this.pictureBoxTarget.Name = "pictureBoxTarget";
            this.pictureBoxTarget.Size = new System.Drawing.Size(364, 331);
            this.pictureBoxTarget.TabIndex = 14;
            this.pictureBoxTarget.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonBlueSide);
            this.panel1.Controls.Add(this.radioButtonRedSide);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(29, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 70);
            this.panel1.TabIndex = 16;
            // 
            // radioButtonBlueSide
            // 
            this.radioButtonBlueSide.AutoSize = true;
            this.radioButtonBlueSide.Checked = true;
            this.radioButtonBlueSide.Location = new System.Drawing.Point(17, 46);
            this.radioButtonBlueSide.Name = "radioButtonBlueSide";
            this.radioButtonBlueSide.Size = new System.Drawing.Size(70, 17);
            this.radioButtonBlueSide.TabIndex = 2;
            this.radioButtonBlueSide.TabStop = true;
            this.radioButtonBlueSide.Text = "Blue Side";
            this.radioButtonBlueSide.UseVisualStyleBackColor = true;
            this.radioButtonBlueSide.CheckedChanged += new System.EventHandler(this.radioButtonBlueSide_CheckedChanged);
            // 
            // radioButtonRedSide
            // 
            this.radioButtonRedSide.AutoSize = true;
            this.radioButtonRedSide.Location = new System.Drawing.Point(17, 24);
            this.radioButtonRedSide.Name = "radioButtonRedSide";
            this.radioButtonRedSide.Size = new System.Drawing.Size(69, 17);
            this.radioButtonRedSide.TabIndex = 1;
            this.radioButtonRedSide.Text = "Red Side";
            this.radioButtonRedSide.UseVisualStyleBackColor = true;
            this.radioButtonRedSide.CheckedChanged += new System.EventHandler(this.radioButtonRedSide_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Autonomous Side";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.radioButtonBinAndShoot);
            this.panel3.Controls.Add(this.radioButtonSideGearAndShoot);
            this.panel3.Controls.Add(this.radioButtonMoveForward);
            this.panel3.Controls.Add(this.radioButtonCenterGearAndShoot);
            this.panel3.Controls.Add(this.radioButtonCenterGear);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(171, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 124);
            this.panel3.TabIndex = 16;
            // 
            // radioButtonBinAndShoot
            // 
            this.radioButtonBinAndShoot.AutoSize = true;
            this.radioButtonBinAndShoot.Location = new System.Drawing.Point(4, 97);
            this.radioButtonBinAndShoot.Name = "radioButtonBinAndShoot";
            this.radioButtonBinAndShoot.Size = new System.Drawing.Size(92, 17);
            this.radioButtonBinAndShoot.TabIndex = 5;
            this.radioButtonBinAndShoot.Text = "Bin and Shoot";
            this.radioButtonBinAndShoot.UseVisualStyleBackColor = true;
            this.radioButtonBinAndShoot.CheckedChanged += new System.EventHandler(this.radioButtonBinAndShoot_CheckedChanged);
            // 
            // radioButtonSideGearAndShoot
            // 
            this.radioButtonSideGearAndShoot.AutoSize = true;
            this.radioButtonSideGearAndShoot.Location = new System.Drawing.Point(5, 78);
            this.radioButtonSideGearAndShoot.Name = "radioButtonSideGearAndShoot";
            this.radioButtonSideGearAndShoot.Size = new System.Drawing.Size(124, 17);
            this.radioButtonSideGearAndShoot.TabIndex = 4;
            this.radioButtonSideGearAndShoot.Text = "Side Gear and Shoot";
            this.radioButtonSideGearAndShoot.UseVisualStyleBackColor = true;
            this.radioButtonSideGearAndShoot.CheckedChanged += new System.EventHandler(this.radioButtonSideGearAndShoot_CheckedChanged);
            // 
            // radioButtonMoveForward
            // 
            this.radioButtonMoveForward.AutoSize = true;
            this.radioButtonMoveForward.Location = new System.Drawing.Point(6, 22);
            this.radioButtonMoveForward.Name = "radioButtonMoveForward";
            this.radioButtonMoveForward.Size = new System.Drawing.Size(93, 17);
            this.radioButtonMoveForward.TabIndex = 3;
            this.radioButtonMoveForward.Text = "Move Forward";
            this.radioButtonMoveForward.UseVisualStyleBackColor = true;
            this.radioButtonMoveForward.CheckedChanged += new System.EventHandler(this.radioButtonMoveForward_CheckedChanged);
            // 
            // radioButtonCenterGearAndShoot
            // 
            this.radioButtonCenterGearAndShoot.AutoSize = true;
            this.radioButtonCenterGearAndShoot.Checked = true;
            this.radioButtonCenterGearAndShoot.Location = new System.Drawing.Point(6, 59);
            this.radioButtonCenterGearAndShoot.Name = "radioButtonCenterGearAndShoot";
            this.radioButtonCenterGearAndShoot.Size = new System.Drawing.Size(122, 17);
            this.radioButtonCenterGearAndShoot.TabIndex = 2;
            this.radioButtonCenterGearAndShoot.TabStop = true;
            this.radioButtonCenterGearAndShoot.Text = "Cntr Gear and Shoot";
            this.radioButtonCenterGearAndShoot.UseVisualStyleBackColor = true;
            this.radioButtonCenterGearAndShoot.CheckedChanged += new System.EventHandler(this.radioButtonCenterGearAndShoot_CheckedChanged);
            // 
            // radioButtonCenterGear
            // 
            this.radioButtonCenterGear.AutoSize = true;
            this.radioButtonCenterGear.Location = new System.Drawing.Point(6, 39);
            this.radioButtonCenterGear.Name = "radioButtonCenterGear";
            this.radioButtonCenterGear.Size = new System.Drawing.Size(82, 17);
            this.radioButtonCenterGear.TabIndex = 1;
            this.radioButtonCenterGear.Text = "Center Gear";
            this.radioButtonCenterGear.UseVisualStyleBackColor = true;
            this.radioButtonCenterGear.CheckedChanged += new System.EventHandler(this.radioButtonCenterGear_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Autonomous Program";
            // 
            // linkLabelClearGeneral
            // 
            this.linkLabelClearGeneral.AutoSize = true;
            this.linkLabelClearGeneral.Location = new System.Drawing.Point(5, 5);
            this.linkLabelClearGeneral.Name = "linkLabelClearGeneral";
            this.linkLabelClearGeneral.Size = new System.Drawing.Size(54, 13);
            this.linkLabelClearGeneral.TabIndex = 17;
            this.linkLabelClearGeneral.TabStop = true;
            this.linkLabelClearGeneral.Text = "Clear Gen";
            this.linkLabelClearGeneral.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearGeneral_LinkClicked);
            // 
            // linkLabelClearRobot
            // 
            this.linkLabelClearRobot.AutoSize = true;
            this.linkLabelClearRobot.Location = new System.Drawing.Point(90, 5);
            this.linkLabelClearRobot.Name = "linkLabelClearRobot";
            this.linkLabelClearRobot.Size = new System.Drawing.Size(63, 13);
            this.linkLabelClearRobot.TabIndex = 18;
            this.linkLabelClearRobot.TabStop = true;
            this.linkLabelClearRobot.Text = "Clear Robot";
            this.linkLabelClearRobot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearRobot_LinkClicked);
            // 
            // linkLabelClearJetson
            // 
            this.linkLabelClearJetson.AutoSize = true;
            this.linkLabelClearJetson.Location = new System.Drawing.Point(168, 5);
            this.linkLabelClearJetson.Name = "linkLabelClearJetson";
            this.linkLabelClearJetson.Size = new System.Drawing.Size(65, 13);
            this.linkLabelClearJetson.TabIndex = 19;
            this.linkLabelClearJetson.TabStop = true;
            this.linkLabelClearJetson.Text = "Clear Jetson";
            this.linkLabelClearJetson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearJetson_LinkClicked);
            // 
            // linkLabelClearMqtt
            // 
            this.linkLabelClearMqtt.AutoSize = true;
            this.linkLabelClearMqtt.Location = new System.Drawing.Point(239, 5);
            this.linkLabelClearMqtt.Name = "linkLabelClearMqtt";
            this.linkLabelClearMqtt.Size = new System.Drawing.Size(55, 13);
            this.linkLabelClearMqtt.TabIndex = 20;
            this.linkLabelClearMqtt.TabStop = true;
            this.linkLabelClearMqtt.Text = "Clear Mqtt";
            this.linkLabelClearMqtt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearMqtt_LinkClicked);
            // 
            // panelClearBox
            // 
            this.panelClearBox.Controls.Add(this.linkLabelClearMqtt);
            this.panelClearBox.Controls.Add(this.linkLabelClearJetson);
            this.panelClearBox.Controls.Add(this.linkLabelClearRobot);
            this.panelClearBox.Controls.Add(this.linkLabelClearGeneral);
            this.panelClearBox.Location = new System.Drawing.Point(494, 28);
            this.panelClearBox.Name = "panelClearBox";
            this.panelClearBox.Size = new System.Drawing.Size(325, 25);
            this.panelClearBox.TabIndex = 21;
            // 
            // linkLabelSendAuto
            // 
            this.linkLabelSendAuto.AutoSize = true;
            this.linkLabelSendAuto.Location = new System.Drawing.Point(331, 18);
            this.linkLabelSendAuto.Name = "linkLabelSendAuto";
            this.linkLabelSendAuto.Size = new System.Drawing.Size(32, 13);
            this.linkLabelSendAuto.TabIndex = 22;
            this.linkLabelSendAuto.TabStop = true;
            this.linkLabelSendAuto.Text = "Send";
            this.linkLabelSendAuto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSendAuto_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(334, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Cam";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDownFrameDecimation
            // 
            this.numericUpDownFrameDecimation.Location = new System.Drawing.Point(334, 108);
            this.numericUpDownFrameDecimation.Name = "numericUpDownFrameDecimation";
            this.numericUpDownFrameDecimation.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownFrameDecimation.TabIndex = 24;
            this.numericUpDownFrameDecimation.ValueChanged += new System.EventHandler(this.numericUpDownFrameDecimation_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Pic Speed (0=off)";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(40, 43);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(40, 13);
            this.labelUserID.TabIndex = 26;
            this.labelUserID.Text = "UserID";
            // 
            // checkBoxPauseRobotLog
            // 
            this.checkBoxPauseRobotLog.AutoSize = true;
            this.checkBoxPauseRobotLog.Location = new System.Drawing.Point(334, 42);
            this.checkBoxPauseRobotLog.Name = "checkBoxPauseRobotLog";
            this.checkBoxPauseRobotLog.Size = new System.Drawing.Size(109, 17);
            this.checkBoxPauseRobotLog.TabIndex = 27;
            this.checkBoxPauseRobotLog.Text = "Pause Robot Log";
            this.checkBoxPauseRobotLog.UseVisualStyleBackColor = true;
            // 
            // numericUpDownLedProgram
            // 
            this.numericUpDownLedProgram.Location = new System.Drawing.Point(334, 151);
            this.numericUpDownLedProgram.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownLedProgram.Name = "numericUpDownLedProgram";
            this.numericUpDownLedProgram.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownLedProgram.TabIndex = 28;
            this.numericUpDownLedProgram.ValueChanged += new System.EventHandler(this.numericUpDownLedProgram_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Led Prgm";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownLedProgram);
            this.Controls.Add(this.checkBoxPauseRobotLog);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownFrameDecimation);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linkLabelSendAuto);
            this.Controls.Add(this.panelClearBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxTarget);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.label_ConnectionStatus);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MQTT Show";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageTarSys.ResumeLayout(false);
            this.tabPageTarSys.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageMsgs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsgs)).EndInit();
            this.tabPageRobot.ResumeLayout(false);
            this.tabPageRobot.PerformLayout();
            this.tabPageJetson.ResumeLayout(false);
            this.tabPageJetson.PerformLayout();
            this.tabPageMqttList.ResumeLayout(false);
            this.tabPageMqttList.PerformLayout();
            this.tabPageRio.ResumeLayout(false);
            this.tabPageRio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelClearBox.ResumeLayout(false);
            this.panelClearBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameDecimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLedProgram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_MainLog;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label_ConnectionStatus;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageRobot;
        private System.Windows.Forms.TextBox textBoxParamEdit;
        private System.Windows.Forms.Button buttonSendParams;
        private System.Windows.Forms.PictureBox pictureBoxTarget;
        private System.Windows.Forms.TextBox textBoxRobotLog;
        private System.Windows.Forms.TabPage tabPageJetson;
        private System.Windows.Forms.TextBox textBoxJetsonLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonBlueSide;
        private System.Windows.Forms.RadioButton radioButtonRedSide;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonBinAndShoot;
        private System.Windows.Forms.RadioButton radioButtonSideGearAndShoot;
        private System.Windows.Forms.RadioButton radioButtonMoveForward;
        private System.Windows.Forms.RadioButton radioButtonCenterGearAndShoot;
        private System.Windows.Forms.RadioButton radioButtonCenterGear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageMqttList;
        private System.Windows.Forms.TextBox textBoxMqttList;
        private System.Windows.Forms.LinkLabel linkLabelClearGeneral;
        private System.Windows.Forms.LinkLabel linkLabelClearRobot;
        private System.Windows.Forms.LinkLabel linkLabelClearJetson;
        private System.Windows.Forms.LinkLabel linkLabelClearMqtt;
        private System.Windows.Forms.Panel panelClearBox;
        private System.Windows.Forms.TabPage tabPageTarSys;
        private System.Windows.Forms.TabPage tabPageRio;
        private System.Windows.Forms.LinkLabel linkLabelSendRoboRioParams;
        private System.Windows.Forms.LinkLabel linkLabelSendAuto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonTargetPeg;
        private System.Windows.Forms.RadioButton radioButtonTargetBoiler;
        private System.Windows.Forms.RadioButton radioButtonTargetNone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabelSendTargetMode;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonForceDefaults;
        private System.Windows.Forms.Button buttonGetParams;
        private System.Windows.Forms.Label labelParamErrors;
        private System.Windows.Forms.TabPage tabPageMsgs;
        private System.Windows.Forms.DataGridView dataGridViewMsgs;
        private System.Windows.Forms.NumericUpDown numericUpDownFrameDecimation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelGetRoboRioParams;
        private System.Windows.Forms.TextBox textBoxRoboRioParams;
        private System.Windows.Forms.LinkLabel linkLabelSetRoboRioDefaults;
        private System.Windows.Forms.LinkLabel linkLabelSaveRoboRIOParams;
        private System.Windows.Forms.LinkLabel linkLabelLoadRoboRioParams;
        private System.Windows.Forms.Label labelRioParamErrors;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.CheckBox checkBoxPauseRobotLog;
        private System.Windows.Forms.NumericUpDown numericUpDownLedProgram;
        private System.Windows.Forms.Label label3;
    }
}

