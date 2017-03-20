namespace UDPConnector
{
    partial class mainForm
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
            this.send = new System.Windows.Forms.Button();
            this.targetHost = new System.Windows.Forms.TextBox();
            this.targetPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listenPort = new System.Windows.Forms.NumericUpDown();
            this.message = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.ListBox();
            this.clearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.targetPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listenPort)).BeginInit();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(298, 36);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // targetHost
            // 
            this.targetHost.Location = new System.Drawing.Point(70, 12);
            this.targetHost.Name = "targetHost";
            this.targetHost.Size = new System.Drawing.Size(118, 20);
            this.targetHost.TabIndex = 1;
            this.targetHost.Text = "127.0.0.1";
            // 
            // targetPort
            // 
            this.targetPort.Location = new System.Drawing.Point(229, 12);
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
            this.targetPort.TabIndex = 2;
            this.targetPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(298, 65);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 5;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port:";
            // 
            // listenPort
            // 
            this.listenPort.Location = new System.Drawing.Point(229, 65);
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
            this.listenPort.TabIndex = 6;
            this.listenPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(70, 38);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(222, 20);
            this.message.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message:";
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.log.FormattingEnabled = true;
            this.log.ItemHeight = 14;
            this.log.Location = new System.Drawing.Point(14, 94);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(359, 242);
            this.log.TabIndex = 10;
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(14, 65);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 23);
            this.clearLog.TabIndex = 11;
            this.clearLog.Text = "Clear";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 359);
            this.Controls.Add(this.clearLog);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listenPort);
            this.Controls.Add(this.listen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetPort);
            this.Controls.Add(this.targetHost);
            this.Controls.Add(this.send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP connector Client/Server";
            ((System.ComponentModel.ISupportInitialize)(this.targetPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listenPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox targetHost;
        private System.Windows.Forms.NumericUpDown targetPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown listenPort;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Button clearLog;
    }
}

