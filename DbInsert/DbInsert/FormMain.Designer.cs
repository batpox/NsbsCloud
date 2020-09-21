namespace CoilStore
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerGeneral = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textEventInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textEventProblem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEventReceived = new System.Windows.Forms.TextBox();
            this.textLastEvent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.textLogs = new System.Windows.Forms.TextBox();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1140, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(16, 17);
            this.LabelStatus.Text = "...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1140, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // timerGeneral
            // 
            this.timerGeneral.Interval = 1000;
            this.timerGeneral.Tick += new System.EventHandler(this.timerGeneral_Tick);
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.groupBox1);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(1132, 470);
            this.tabStatus.TabIndex = 3;
            this.tabStatus.Text = "Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textEventInfo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textEventProblem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textEventReceived);
            this.groupBox1.Controls.Add(this.textLastEvent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 126);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1069, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EventPump";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Info";
            // 
            // textEventInfo
            // 
            this.textEventInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEventInfo.Location = new System.Drawing.Point(70, 96);
            this.textEventInfo.Margin = new System.Windows.Forms.Padding(2);
            this.textEventInfo.Name = "textEventInfo";
            this.textEventInfo.ReadOnly = true;
            this.textEventInfo.Size = new System.Drawing.Size(995, 20);
            this.textEventInfo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Problem";
            // 
            // textEventProblem
            // 
            this.textEventProblem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEventProblem.Location = new System.Drawing.Point(70, 72);
            this.textEventProblem.Margin = new System.Windows.Forms.Padding(2);
            this.textEventProblem.Name = "textEventProblem";
            this.textEventProblem.ReadOnly = true;
            this.textEventProblem.Size = new System.Drawing.Size(995, 20);
            this.textEventProblem.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Received";
            // 
            // textEventReceived
            // 
            this.textEventReceived.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEventReceived.Location = new System.Drawing.Point(71, 48);
            this.textEventReceived.Margin = new System.Windows.Forms.Padding(2);
            this.textEventReceived.Name = "textEventReceived";
            this.textEventReceived.ReadOnly = true;
            this.textEventReceived.Size = new System.Drawing.Size(995, 20);
            this.textEventReceived.TabIndex = 2;
            // 
            // textLastEvent
            // 
            this.textLastEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLastEvent.Location = new System.Drawing.Point(71, 24);
            this.textLastEvent.Margin = new System.Windows.Forms.Padding(2);
            this.textLastEvent.Name = "textLastEvent";
            this.textLastEvent.ReadOnly = true;
            this.textLastEvent.Size = new System.Drawing.Size(995, 20);
            this.textLastEvent.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Event";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.propertyGrid1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(1132, 470);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(1132, 470);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabStatus);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1140, 496);
            this.tabControl1.TabIndex = 2;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.textLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Margin = new System.Windows.Forms.Padding(2);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(2);
            this.tabLogs.Size = new System.Drawing.Size(1132, 470);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // textLogs
            // 
            this.textLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLogs.Location = new System.Drawing.Point(2, 2);
            this.textLogs.Margin = new System.Windows.Forms.Padding(2);
            this.textLogs.Multiline = true;
            this.textLogs.Name = "textLogs";
            this.textLogs.ReadOnly = true;
            this.textLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLogs.Size = new System.Drawing.Size(1128, 466);
            this.textLogs.TabIndex = 0;
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem2.Text = "&File";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem2.Text = "E&xit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 542);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "(Name Here)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabStatus.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timerGeneral;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textEventInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textEventProblem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEventReceived;
        private System.Windows.Forms.TextBox textLastEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TextBox textLogs;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    }
}

