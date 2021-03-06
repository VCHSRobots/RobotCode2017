﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using uPLibrary.Networking.M2Mqtt;

namespace MqttShow
{
    public partial class MainForm : Form
    {
        #region Class Variables...
        private AppSettings m_Settings = new AppSettings();
        private delegate void StringFunc(string msg);
        private delegate void String2Func(string s1, string s2);
        private delegate void LogFunc(TextBox b, string msg);
        private delegate void VoidFunc();
        Timer m_timer = null;
        Timer m_timer_ping = null;
        Mqtt m_mqtt = null;
        private bool m_dead = false;
        private DataTable m_MessageTable;
        private int m_UIDisable = 0;

        #endregion

        #region Construction...
        /// <summary>
        /// Construction
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Size = m_Settings.FormSize;
            this.Location = m_Settings.FormLocation;
            LoadParameters();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Trim();
            if (userName.Length <= 0)
            {
                userName = "UnknownID";
            }
            else if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }
            m_mqtt = new Mqtt("10.44.15.19", 5802, userName);
            labelUserID.Text = userName;
            m_mqtt.NewMessageReady += NewMessageReady;
            m_mqtt.ConnectionStatusChanged += ConnectionStatusChanged;
            m_mqtt.Start();

            SendFrameDecimation();

            m_timer = new Timer();
            m_timer.Interval = 50;
            m_timer.Tick += timer_tick;
            m_timer.Start();

            m_timer_ping = new Timer();
            m_timer_ping.Interval = 10000;
            m_timer_ping.Tick += timer_ping_tick;
            m_timer_ping.Start();

            m_MessageTable = new DataTable("Messages");
            m_MessageTable.Columns.Add("Topic", typeof(string));
            m_MessageTable.Columns.Add("Seq", typeof(string));
            m_MessageTable.Columns.Add("TS", typeof(string));
            m_MessageTable.Columns.Add("Payload", typeof(string));
            this.dataGridViewMsgs.DataSource = m_MessageTable;
        }
        #endregion

        #region LoadParameters()
        /// <summary>
        /// Loads UI parameters from disk
        /// </summary>
        private void LoadParameters()
        {
            m_UIDisable++;
            this.numericUpDownFrameDecimation.Value = m_Settings.FrameDecimation;
            this.checkBoxPauseRobotLog.Checked = m_Settings.PauseRobotLog;
            m_UIDisable--;
        }
        #endregion

        #region SaveParameters()
        /// <summary>
        /// Saves UI parameters to disk.
        /// </summary>
        private void SaveParameters()
        {
            m_Settings.FrameDecimation = (int) this.numericUpDownFrameDecimation.Value;
            m_Settings.PauseRobotLog = this.checkBoxPauseRobotLog.Checked;
        }
        #endregion

        #region OnResize()
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int gap = 10;
            int nx = this.ClientSize.Width;
            int ny = this.ClientSize.Height;
            int nx2 = nx / 2 - gap - gap / 2;
            tabControlMain.Location = new Point(nx / 2 + gap / 2, tabControlMain.Location.Y);
            panelClearBox.Location = new Point(nx / 2 + gap / 2, panelClearBox.Location.Y);
            int w = nx - tabControlMain.Location.X - gap;
            int h = ny - tabControlMain.Location.Y - gap;
            tabControlMain.Size = new Size(w, h);
            w = nx / 2 - gap - gap / 2;
            h = ny - pictureBoxTarget.Location.Y - gap;
            pictureBoxTarget.Size = new Size(w, h);

            nx = tabPageTarSys.ClientSize.Width;
            ny = tabPageTarSys.ClientSize.Height;
            w = nx - textBoxParamEdit.Location.X - gap;
            h = ny - textBoxParamEdit.Location.Y - gap;
            textBoxParamEdit.Size = new Size(w, h);

            nx = tabPageRio.ClientSize.Width;
            ny = tabPageRio.ClientSize.Height;
            w = nx - textBoxRoboRioParams.Location.X - gap;
            h = ny - textBoxRoboRioParams.Location.Y - gap;
            textBoxRoboRioParams.Size = new Size(w, h);

            nx = tabPageMsgs.ClientSize.Width;
            ny = tabPageMsgs.ClientSize.Height;
            dataGridViewMsgs.Location = new Point(0, 0);
            dataGridViewMsgs.Size = new Size(nx, ny);
        }
        #endregion

        #region OnClosing()
        protected override void OnClosing(CancelEventArgs e)
        {
            m_dead = true;
            m_mqtt.Kill();
            m_Settings.FormLocation = this.Location;
            m_Settings.FormSize = this.Size;
            SaveParameters();
            m_Settings.Save();
            base.OnClosing(e);
        }
        #endregion

        #region OnClosed()
        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
            base.OnClosed(e);
        }
        #endregion

        #region ConnectionStatusChanged()
        /// <summary>
        /// Callback when connection status has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionStatusChanged(object sender, EventArgs e)
        {
            if (m_dead) return;
            VoidFunc func = new VoidFunc(CheckStatus);
        }
        #endregion

        #region CheckStatus()
        /// <summary>
        /// Check the status of the MQTT connection and display UI.
        /// </summary>
        private void CheckStatus()
        {
            string status = "Disconnected";
            Color c = Color.Red;
            if (m_mqtt.IsConnected)
            {
                status = "Connected";
                c = Color.DarkGreen;
            }
            label_ConnectionStatus.ForeColor = c;
            label_ConnectionStatus.Text = status;
        }
        #endregion

        #region NewMessageReady()
        /// <summary>
        /// Callback when we have a new messages.  Can be called from 
        /// any thread.  Does not block.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMessageReady(object sender, EventArgs e)
        {
            if (m_dead) return;
            VoidFunc func = new VoidFunc(GetNewMessages);
            try
            {
                this.BeginInvoke(func);
            }
            catch (System.InvalidOperationException)
            {
                // Happens on shut down... doesn't matter.
                return;
            }
        }
        #endregion

        #region GetNewMessages()
        /// <summary>
        /// Retrieve the new messages and display them.  Be sure to 
        /// call this on the UI thread only!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetNewMessages()
        {
            MqttMessage[] msgs = m_mqtt.GetMessages();
            foreach( MqttMessage m in msgs)
            {
                ProcessIncomingMsg(m.Topic, m.Message);
            }
        }
        #endregion

        #region timer_ping_tick()
        private int m_PingID = 0;
        private long m_PingStartTime = 0;
        private long m_lastPingTest = 0;
        private void timer_ping_tick(object sender, EventArgs e)
        {
            if (m_lastPingTest != 0)
            {
                double telp = StopWatch.Stop(m_lastPingTest);
                AddLogLine(textBox_MainLog, String.Format("Ping Test Timmer = {0:0.000000}.", telp));
            }
            m_PingID++;
            m_PingStartTime = StopWatch.Start();
            string msg = String.Format("{0:0}", m_PingID);
            m_mqtt.SendMessage("robot/pingtest", msg);
        }
        #endregion

        #region timer_tick()
        /// <summary>
        /// timer_tick -- Do periodic status checks and maintain status UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tick(object sender, EventArgs e)
        {
            CheckStatus();
            //VoidFunc f = new VoidFunc(CheckStatus);
            //this.BeginInvoke(f);
        }
        #endregion

        #region ShowSavedMessages()
        /// <summary>
        /// Builds a List of messages, and keeps last one.
        /// </summary>
        private void ShowSavedMessages()
        {
            if (this.InvokeRequired)
            {
                VoidFunc f = new VoidFunc(ShowSavedMessages);
                this.BeginInvoke(f);
            }

            MqttMessage[] AllMsgs = m_mqtt.GetAllSavedMessages();
            //TopicComparer sorter = new TopicComparer();
            //Array.Sort(AllMsgs, sorter);
            //DataTable dt = new DataTable("Messages");
            //dt.Columns.Add("Topic", typeof(string));
            //dt.Columns.Add("Seq", typeof(string));
            //dt.Columns.Add("TS", typeof(string));
            //dt.Columns.Add("Payload", typeof(string));
            m_MessageTable.Rows.Clear();
            foreach (MqttMessage m in AllMsgs)
            {
                string sseq = string.Format("{0,0}", m.Sequence);
                string sts = string.Format("{0,0}", m.Timestamp);
                string data = m.Message;
                if (data.Length > 1000)
                {
                    data = data.Substring(0, 1000);
                }
                m_MessageTable.Rows.Add(m.Topic, sseq, sts, data);
            }
            //dataGridView1.DataSource = m_MessageTable;
            //textBoxMqttList.Lines = x.ToArray();
        }
        #endregion

        #region DisplayPic
        /// <summary>
        /// Display the Picture sent from the Jetson
        /// </summary>
        /// <param name="data"></param>
        private void DisplayPic(string data)
        {
            try
            {
                byte[] bdata = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(bdata);
                Image img = Image.FromStream(ms);
                pictureBoxTarget.Image = img;
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region ProcessIncomingMsg()
        private void ProcessIncomingMsg(string topic, string message)
        {
            if (topic == "pic/ts")
            {
                object[] args = new object[1];
                args[0] = message;
                StringFunc f = new StringFunc(DisplayPic);
                this.BeginInvoke(f, args);
                return;
            }

            string[] names = topic.Split('/');
            if (names.Length <= 2) return;
            if (names[0] != "robot") return;

            ShowSavedMessages();

            if (topic == "robot/roborio/log")
            {
                if (!checkBoxPauseRobotLog.Checked)
                {
                    AddLogLine(textBoxRobotLog, message);
                }
                return;
            }
            else
            {
                AddLogLine(textBoxMqttList, topic + ": " + message);
            }

            if (names[1] == "jetson")
            {
                AddLogLine(textBoxJetsonLog, topic + ": " + message);
            }

            if (topic == "robot/jetson/ping")
            {
                int pingid = 0;
                bool okay = Int32.TryParse(message.Trim(), out pingid);
                string m = "";
                if (okay && pingid == m_PingID)
                {
                    double ElapsedSecs = StopWatch.Stop(m_PingStartTime);
                    m = String.Format("Ping {0} to Jetson = {1:0.000} ms.", m_PingID, ElapsedSecs * 1000.0);
                }
                else
                {
                    m = String.Format("Invalid Ping Response.  Expected {0}, Got " + message.Trim(), m_PingID);
                }
                AddLogLine(textBox_MainLog, m);
            }

            if (names[1] != "roborio" && names[1] != "jetson")
            {
                string msg = topic + ": " + message;
                AddLogLine(textBox_MainLog, msg);
            }

            if (topic == "robot/jetson/targetparams")
            {
                object[] args = new object[1];
                args[0] = message;
                this.BeginInvoke(new StringFunc(LoadParams), args); 
            }

            if (topic == "robot/rio/params")
            {
                object[] args = new object[1];
                args[0] = message;
                this.BeginInvoke(new StringFunc(LoadRioParams), args);
            }
        }
        #endregion

        #region LoadParams()
        /// <summary>
        /// Loads the params into the text box for editing.
        /// </summary>
        /// <param name="data"></param>
        private void LoadParams(string data)
        {
            textBoxParamEdit.Lines = data.Split(';');
        }
        #endregion

        #region LoadRioParams()
        /// <summary>
        /// Loads the roborio params into the text box for editing.
        /// </summary>
        /// <param name="data"></param>
        private void LoadRioParams(string data)
        {
            textBoxRoboRioParams.Lines = data.Split(';');
        }
        #endregion

        #region AddLogLine()
        /// <summary>
        /// Adds a line to a text box, and treats it like a log.
        /// Should be thread safe.
        /// </summary>
        /// <param name="msg"></param>
        private void AddLogLine(TextBox box, string msg)
        {
            if (box.InvokeRequired)
            {
                object[] args = new object[1];
                args[0] = msg;
                LogFunc target = new LogFunc(AddLogLine);
                box.BeginInvoke(target, args);
                return;
            }
            List<String> lines = new List<string>(box.Lines);
            if (lines.Count > 2000)
            {
                int nremove = lines.Count - 2000;
                lines.RemoveRange(0, nremove);
            }
            lines.Add(msg);
            box.Lines = lines.ToArray();
        }
        #endregion

        #region SendSide()
        /// <summary>
        /// Send side basied on radio buttons.
        /// </summary>
        private void SendSide()
        {
            if (radioButtonBlueSide.Checked && !radioButtonRedSide.Checked)
            {
                m_mqtt.SendMessage("robot/ds/autoside", "blue");
                AddLogLine(textBox_MainLog, "Blue Side Sent.");
                return;
            }
            if (!radioButtonBlueSide.Checked && radioButtonRedSide.Checked)
            {
                m_mqtt.SendMessage("robot/ds/autoside", "red");
                AddLogLine(textBox_MainLog, "Red Side Sent.");
                return;
            }
        }
        #endregion

        #region SendAutoProgram()
        /// <summary>
        /// Send the auto program basied on radio buttons.
        /// </summary>
        private void SendAutoProgram()
        {
            string prgm = "";
            if (radioButtonMoveForward.Checked) prgm = "MoveForward";
            if (radioButtonCenterGear.Checked) prgm = "CenterGear";
            if (radioButtonCenterGearAndShoot.Checked) prgm = "GearAndShoot";
            if (radioButtonSideGearAndShoot.Checked) prgm = "SideGearAndShoot";
            if (radioButtonBinAndShoot.Checked) prgm = "BinAndShoot";
            m_mqtt.SendMessage("robot/ds/autoprogram", prgm);
            AddLogLine(textBox_MainLog, "Auto Program Selected: " + prgm);
        }
        #endregion

        #region Red/Blue Radio Buttons
        private void radioButtonRedSide_CheckedChanged(object sender, EventArgs e)
        {
            SendSide();
        }

        private void radioButtonBlueSide_CheckedChanged(object sender, EventArgs e)
        {
            SendSide();
        }
        #endregion

        #region Auto Radio Buttons
        private void radioButtonMoveForward_CheckedChanged(object sender, EventArgs e)
        {
            SendAutoProgram();
        }

        private void radioButtonCenterGear_CheckedChanged(object sender, EventArgs e)
        {
            SendAutoProgram();
        }

        private void radioButtonCenterGearAndShoot_CheckedChanged(object sender, EventArgs e)
        {
            SendAutoProgram();
        }

        private void radioButtonSideGearAndShoot_CheckedChanged(object sender, EventArgs e)
        {
            SendAutoProgram();
        }

        private void radioButtonBinAndShoot_CheckedChanged(object sender, EventArgs e)
        {
            SendAutoProgram();
        }
        #endregion

        #region Clear Buttons...
        private void linkLabelClearGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox_MainLog.Text = "";
        }

        private void linkLabelClearRobot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRobotLog.Text = "";
        }

        private void linkLabelClearJetson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxJetsonLog.Text = "";
        }

        private void linkLabelClearMqtt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxMqttList.Text = "";
        }
        #endregion

        #region UI Events...
        private void linkLabelSendAuto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendSide();
            SendAutoProgram();
        }


        #endregion

        #region Sending Commands to RoboRio
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                m_mqtt.SendMessage("robot/ds/tstcamlight", "1");
            }
            else
            {
                m_mqtt.SendMessage("robot/ds/tstcamlight", "0");
            }
        }
        #endregion

        #region Send Commands to Target System...

        private void buttonSendParams_Click(object sender, EventArgs e)
        {
            // Encode the parameters, skip lines that don't work.
            string m = "";
            string[] lines = textBoxParamEdit.Lines;
            int nerrors = 0;
            foreach( string x in lines)
            {
                bool okay = false;
                string xx = x.Trim();
                if (xx.Length <= 0) continue;
                string[] parts = xx.Split('=');
                if (parts.Length == 2) {
                    string key = parts[0];
                    double val;
                    okay = double.TryParse(parts[1], out val);
                    if (okay)
                    {
                        string p = key + "=" + string.Format("{0}", val) + ";";
                        m += p;
                    }
                }
                if (!okay) nerrors++;
            }
            m_mqtt.SendMessage("robot/ds/targetparams", m);
            if (nerrors > 0) {
                this.labelParamErrors.Text = string.Format("Syntax Errors {0:0}", nerrors);
            }
            else
            {
                this.labelParamErrors.Text = "";
            }
        }

        private void buttonForceDefaults_Click(object sender, EventArgs e)
        {
            m_mqtt.SendMessage("robot/ds/usedefaultparams", "0");
        }

        private void buttonGetParams_Click(object sender, EventArgs e)
        {
            m_mqtt.SendMessage("robot/ds/sendparams", "0");
        }
        #endregion

        #region Commands for RoboRio Parameters
        private void linkLabelSendRoboRioParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Encode the parameters, skip lines that don't work.
            string m = "";
            string[] lines = textBoxRoboRioParams.Lines;
            int nerrors = 0;
            foreach (string x in lines)
            {
                bool okay = false;
                string xx = x.Trim();
                if (xx.Length <= 0) continue;
                string[] parts = xx.Split('=');
                if (parts.Length == 2)
                {
                    string key = parts[0];
                    double val;
                    okay = double.TryParse(parts[1], out val);
                    if (okay)
                    {
                        string p = key + "=" + string.Format("{0}", val) + ";";
                        m += p;
                    }
                }
                if (!okay) nerrors++;
            }
            m_mqtt.SendMessage("robot/ds/rio/tableparams", m);
            if (nerrors > 0)
            {
                this.labelRioParamErrors.Text = string.Format("Syntax Errors {0:0}", nerrors);
            }
            else
            {
                this.labelRioParamErrors.Text = "";
            }
        }

        private void linkLabelGetRoboRioParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_mqtt.SendMessage("robot/ds/rio/sendtableparams", "0");
        }

        private void linkLabelSetRoboRioDefaults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_mqtt.SendMessage("robot/ds/rio/usetabledefaults", "0");
        }

        private void linkLabelSaveRoboRIOParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string finalPath = Path.Combine(folderLocation, "RioParams.txt");
            string data = textBoxRoboRioParams.Text;
            File.WriteAllText(finalPath, data);
        }

        private void linkLabelLoadRoboRioParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string finalPath = Path.Combine(folderLocation, "RioParams.txt");
            string data = "";
            try
            {
                data = File.ReadAllText(finalPath);
            }
            catch
            {
                data = "";
            }
            textBoxRoboRioParams.Text = data;
        }
        #endregion

        #region SendFrameDecimation()
            /// <summary>
            /// Sends the Frame Decimation...
            /// </summary>
            /// <param name="iDecimate"></param>
        private void SendFrameDecimation()
        {
            if (m_UIDisable > 0) return;
            int icount = (int)this.numericUpDownFrameDecimation.Value;
            m_mqtt.SendMessage("robot/ds/framedecimation", icount.ToString());
        }
        #endregion

        #region UI Events...
        private void numericUpDownFrameDecimation_ValueChanged(object sender, EventArgs e)
        {
            SendFrameDecimation();
        }
        #endregion

        #region Events to Setup Target Mode

        private void SetupTargetingMode()
        {
            string star = "0";
            if (this.radioButtonTargetNone.Checked) star = "0";
            if (this.radioButtonTargetBoiler.Checked) star = "1";
            if (this.radioButtonTargetPeg.Checked) star = "2";
            m_mqtt.SendMessage("robot/ds/targetmode", star);
            //m_mqtt.SendMessage("robot/ds/tstcamlight", "1");
            checkBox1.Checked = true;  // This caused the mqtt msg to be sent because the UI event is triggered.
            m_Settings.FrameDecimation = 10; // This should cause a mqtt msg to be sent.
        }

        private void radioButtonTargetPeg_CheckedChanged(object sender, EventArgs e)
        {
            SetupTargetingMode();
        }

        private void radioButtonTargetBoiler_CheckedChanged(object sender, EventArgs e)
        {
            SetupTargetingMode();
        }

        private void radioButtonTargetNone_CheckedChanged(object sender, EventArgs e)
        {
            SetupTargetingMode();
        }

        private void linkLabelSendTargetMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetupTargetingMode();

        }
        #endregion

        #region UI Events to Control LED programs
        private void numericUpDownLedProgram_ValueChanged(object sender, EventArgs e)
        {
            int indx = (int) numericUpDownLedProgram.Value;
            String s = String.Format("{0,0}", indx);
            m_mqtt.SendMessage("robot/ds/setleds", s);
        }
        #endregion
    }

    #region TopicComparer class
    public class TopicComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            if ((x is MqttMessage) && (y is MqttMessage)) {
                MqttMessage xx = (MqttMessage) x;
                MqttMessage yy = (MqttMessage) y;
                return string.Compare(xx.Topic, yy.Topic);
            }
            return 0;
        }
    }
    #endregion

    #region AppSettings class
    public class AppSettings : ApplicationSettingsBase
    {
        #region FormSize
        [UserScopedSetting()]
        [DefaultSettingValue("600, 400")]
        public Size FormSize
        {
            get { return (Size)this["FormSize"]; }
            set { this["FormSize"] = (Size)value;  }
        }
        #endregion

        #region FormLocation
        [UserScopedSetting()]
        [DefaultSettingValue("20, 20")]
        public Point FormLocation
        {
            get { return (Point)this["FormLocation"]; }
            set { this["FormLocation"] = (Point)value; }
        }
        #endregion

        #region FrameDecimation
        [UserScopedSetting()]
        [DefaultSettingValue("100")]
        public int FrameDecimation
        {
            get { return (int)this["FrameDecimation"]; }
            set { this["FrameDecimation"] = (int)value; }
        }
        #endregion

        #region PauseRobotLog
        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool PauseRobotLog
        {
            get { return (bool)this["PauseRobotLog"]; }
            set { this["PauseRobotLog"] = (bool)value; }
        }
        #endregion

    }
    #endregion
}
