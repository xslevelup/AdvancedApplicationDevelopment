namespace TcpConnectorCliSrv
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
            this.clearLog = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listenPort = new System.Windows.Forms.NumericUpDown();
            this.listen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.targetPort = new System.Windows.Forms.NumericUpDown();
            this.send = new System.Windows.Forms.Button();
            this.clientCount = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.useSSL = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.certFile = new System.Windows.Forms.TextBox();
            this.browseCert = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.forwardOnServer = new System.Windows.Forms.CheckBox();
            this.targetHost = new System.Windows.Forms.ComboBox();
            this.localHost = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.binaryData = new System.Windows.Forms.CheckBox();
            this.sendServer = new System.Windows.Forms.CheckBox();
            this.sendClients = new System.Windows.Forms.CheckBox();
            this.serverGroup = new System.Windows.Forms.GroupBox();
            this.userListFile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.browseUserListFile = new System.Windows.Forms.Button();
            this.clientGroup = new System.Windows.Forms.GroupBox();
            this.messageGroup = new System.Windows.Forms.GroupBox();
            this.logGroup = new System.Windows.Forms.GroupBox();
            this.certPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listenPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPort)).BeginInit();
            this.serverGroup.SuspendLayout();
            this.clientGroup.SuspendLayout();
            this.messageGroup.SuspendLayout();
            this.logGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(292, 290);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 23);
            this.clearLog.TabIndex = 23;
            this.clearLog.Text = "Clear";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.log.FormattingEnabled = true;
            this.log.HorizontalScrollbar = true;
            this.log.ItemHeight = 14;
            this.log.Location = new System.Drawing.Point(8, 42);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(359, 242);
            this.log.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Message:";
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(64, 19);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(222, 20);
            this.message.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Port:";
            // 
            // listenPort
            // 
            this.listenPort.Location = new System.Drawing.Point(223, 19);
            this.listenPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.listenPort.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.listenPort.Name = "listenPort";
            this.listenPort.Size = new System.Drawing.Size(63, 20);
            this.listenPort.TabIndex = 18;
            this.listenPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(292, 18);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 17;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Host:";
            // 
            // targetPort
            // 
            this.targetPort.Location = new System.Drawing.Point(223, 19);
            this.targetPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.targetPort.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.targetPort.Name = "targetPort";
            this.targetPort.Size = new System.Drawing.Size(63, 20);
            this.targetPort.TabIndex = 14;
            this.targetPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(292, 18);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 12;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // clientCount
            // 
            this.clientCount.AutoSize = true;
            this.clientCount.Location = new System.Drawing.Point(177, 21);
            this.clientCount.Name = "clientCount";
            this.clientCount.Size = new System.Drawing.Size(13, 13);
            this.clientCount.TabIndex = 24;
            this.clientCount.Text = "0";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(292, 18);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 25;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // useSSL
            // 
            this.useSSL.AutoSize = true;
            this.useSSL.Location = new System.Drawing.Point(292, 47);
            this.useSSL.Name = "useSSL";
            this.useSSL.Size = new System.Drawing.Size(74, 17);
            this.useSSL.TabIndex = 26;
            this.useSSL.Text = "SSL client";
            this.useSSL.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Certificate:";
            // 
            // certFile
            // 
            this.certFile.Location = new System.Drawing.Point(64, 47);
            this.certFile.Name = "certFile";
            this.certFile.Size = new System.Drawing.Size(279, 20);
            this.certFile.TabIndex = 27;
            // 
            // browseCert
            // 
            this.browseCert.Location = new System.Drawing.Point(343, 47);
            this.browseCert.Name = "browseCert";
            this.browseCert.Size = new System.Drawing.Size(24, 21);
            this.browseCert.TabIndex = 29;
            this.browseCert.Text = "...";
            this.browseCert.UseVisualStyleBackColor = true;
            this.browseCert.Click += new System.EventHandler(this.browseCert_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Client count:";
            // 
            // forwardOnServer
            // 
            this.forwardOnServer.AutoSize = true;
            this.forwardOnServer.Location = new System.Drawing.Point(64, 47);
            this.forwardOnServer.Name = "forwardOnServer";
            this.forwardOnServer.Size = new System.Drawing.Size(64, 17);
            this.forwardOnServer.TabIndex = 31;
            this.forwardOnServer.Text = "Forward";
            this.forwardOnServer.UseVisualStyleBackColor = true;
            // 
            // targetHost
            // 
            this.targetHost.FormattingEnabled = true;
            this.targetHost.Location = new System.Drawing.Point(64, 19);
            this.targetHost.Name = "targetHost";
            this.targetHost.Size = new System.Drawing.Size(118, 21);
            this.targetHost.TabIndex = 32;
            // 
            // localHost
            // 
            this.localHost.FormattingEnabled = true;
            this.localHost.Location = new System.Drawing.Point(64, 19);
            this.localHost.Name = "localHost";
            this.localHost.Size = new System.Drawing.Size(118, 21);
            this.localHost.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Host:";
            // 
            // binaryData
            // 
            this.binaryData.AutoSize = true;
            this.binaryData.Location = new System.Drawing.Point(292, 19);
            this.binaryData.Name = "binaryData";
            this.binaryData.Size = new System.Drawing.Size(55, 17);
            this.binaryData.TabIndex = 35;
            this.binaryData.Text = "Binary";
            this.binaryData.UseVisualStyleBackColor = true;
            // 
            // sendServer
            // 
            this.sendServer.AutoSize = true;
            this.sendServer.Location = new System.Drawing.Point(64, 45);
            this.sendServer.Name = "sendServer";
            this.sendServer.Size = new System.Drawing.Size(95, 17);
            this.sendServer.TabIndex = 36;
            this.sendServer.Text = "Send to server";
            this.sendServer.UseVisualStyleBackColor = true;
            // 
            // sendClients
            // 
            this.sendClients.AutoSize = true;
            this.sendClients.Location = new System.Drawing.Point(191, 45);
            this.sendClients.Name = "sendClients";
            this.sendClients.Size = new System.Drawing.Size(96, 17);
            this.sendClients.TabIndex = 37;
            this.sendClients.Text = "Send to clients";
            this.sendClients.UseVisualStyleBackColor = true;
            // 
            // serverGroup
            // 
            this.serverGroup.Controls.Add(this.certPassword);
            this.serverGroup.Controls.Add(this.label9);
            this.serverGroup.Controls.Add(this.userListFile);
            this.serverGroup.Controls.Add(this.label8);
            this.serverGroup.Controls.Add(this.browseUserListFile);
            this.serverGroup.Controls.Add(this.localHost);
            this.serverGroup.Controls.Add(this.listen);
            this.serverGroup.Controls.Add(this.listenPort);
            this.serverGroup.Controls.Add(this.label3);
            this.serverGroup.Controls.Add(this.certFile);
            this.serverGroup.Controls.Add(this.label7);
            this.serverGroup.Controls.Add(this.label5);
            this.serverGroup.Controls.Add(this.browseCert);
            this.serverGroup.Location = new System.Drawing.Point(12, 12);
            this.serverGroup.Name = "serverGroup";
            this.serverGroup.Size = new System.Drawing.Size(384, 135);
            this.serverGroup.TabIndex = 38;
            this.serverGroup.TabStop = false;
            this.serverGroup.Text = "Server";
            // 
            // userListFile
            // 
            this.userListFile.Location = new System.Drawing.Point(64, 99);
            this.userListFile.Name = "userListFile";
            this.userListFile.Size = new System.Drawing.Size(279, 20);
            this.userListFile.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "User list:";
            // 
            // browseUserListFile
            // 
            this.browseUserListFile.Location = new System.Drawing.Point(343, 99);
            this.browseUserListFile.Name = "browseUserListFile";
            this.browseUserListFile.Size = new System.Drawing.Size(24, 21);
            this.browseUserListFile.TabIndex = 37;
            this.browseUserListFile.Text = "...";
            this.browseUserListFile.UseVisualStyleBackColor = true;
            this.browseUserListFile.Click += new System.EventHandler(this.browseUserListFile_Click);
            // 
            // clientGroup
            // 
            this.clientGroup.Controls.Add(this.targetHost);
            this.clientGroup.Controls.Add(this.targetPort);
            this.clientGroup.Controls.Add(this.label1);
            this.clientGroup.Controls.Add(this.label2);
            this.clientGroup.Controls.Add(this.forwardOnServer);
            this.clientGroup.Controls.Add(this.connect);
            this.clientGroup.Controls.Add(this.useSSL);
            this.clientGroup.Location = new System.Drawing.Point(12, 153);
            this.clientGroup.Name = "clientGroup";
            this.clientGroup.Size = new System.Drawing.Size(384, 72);
            this.clientGroup.TabIndex = 39;
            this.clientGroup.TabStop = false;
            this.clientGroup.Text = "Client";
            // 
            // messageGroup
            // 
            this.messageGroup.Controls.Add(this.message);
            this.messageGroup.Controls.Add(this.send);
            this.messageGroup.Controls.Add(this.label4);
            this.messageGroup.Controls.Add(this.sendClients);
            this.messageGroup.Controls.Add(this.sendServer);
            this.messageGroup.Location = new System.Drawing.Point(12, 231);
            this.messageGroup.Name = "messageGroup";
            this.messageGroup.Size = new System.Drawing.Size(384, 74);
            this.messageGroup.TabIndex = 40;
            this.messageGroup.TabStop = false;
            this.messageGroup.Text = "Message";
            // 
            // logGroup
            // 
            this.logGroup.Controls.Add(this.log);
            this.logGroup.Controls.Add(this.clearLog);
            this.logGroup.Controls.Add(this.clientCount);
            this.logGroup.Controls.Add(this.label6);
            this.logGroup.Controls.Add(this.binaryData);
            this.logGroup.Location = new System.Drawing.Point(12, 311);
            this.logGroup.Name = "logGroup";
            this.logGroup.Size = new System.Drawing.Size(384, 321);
            this.logGroup.TabIndex = 41;
            this.logGroup.TabStop = false;
            this.logGroup.Text = "Log";
            // 
            // certPassword
            // 
            this.certPassword.Location = new System.Drawing.Point(64, 73);
            this.certPassword.Name = "certPassword";
            this.certPassword.PasswordChar = '*';
            this.certPassword.Size = new System.Drawing.Size(279, 20);
            this.certPassword.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Cert. pwd:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 645);
            this.Controls.Add(this.logGroup);
            this.Controls.Add(this.messageGroup);
            this.Controls.Add(this.clientGroup);
            this.Controls.Add(this.serverGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP connector Client/Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listenPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPort)).EndInit();
            this.serverGroup.ResumeLayout(false);
            this.serverGroup.PerformLayout();
            this.clientGroup.ResumeLayout(false);
            this.clientGroup.PerformLayout();
            this.messageGroup.ResumeLayout(false);
            this.messageGroup.PerformLayout();
            this.logGroup.ResumeLayout(false);
            this.logGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown listenPort;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown targetPort;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label clientCount;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.CheckBox useSSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox certFile;
        private System.Windows.Forms.Button browseCert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox forwardOnServer;
        private System.Windows.Forms.ComboBox targetHost;
        private System.Windows.Forms.ComboBox localHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox binaryData;
        private System.Windows.Forms.CheckBox sendServer;
        private System.Windows.Forms.CheckBox sendClients;
        private System.Windows.Forms.GroupBox serverGroup;
        private System.Windows.Forms.GroupBox clientGroup;
        private System.Windows.Forms.GroupBox messageGroup;
        private System.Windows.Forms.GroupBox logGroup;
        private System.Windows.Forms.TextBox userListFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button browseUserListFile;
        private System.Windows.Forms.TextBox certPassword;
        private System.Windows.Forms.Label label9;
    }
}

