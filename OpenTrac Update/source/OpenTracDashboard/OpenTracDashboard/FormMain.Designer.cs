namespace OpenTracDashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabOpenTracTransactions = new System.Windows.Forms.TabPage();
            this.tabSpcTransactions = new System.Windows.Forms.TabPage();
            this.tabOtSummary = new System.Windows.Forms.TabPage();
            this.textLogs = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainerOT = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainerSpc = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvInboundOt = new System.Windows.Forms.DataGridView();
            this.dgvOutboundOt = new System.Windows.Forms.DataGridView();
            this.dgvInboundSpc = new System.Windows.Forms.DataGridView();
            this.dataOutboundSpc = new System.Windows.Forms.DataGridView();
            this.dgvKeyStore = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabOpenTracTransactions.SuspendLayout();
            this.tabSpcTransactions.SuspendLayout();
            this.tabOtSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOT)).BeginInit();
            this.splitContainerOT.Panel1.SuspendLayout();
            this.splitContainerOT.Panel2.SuspendLayout();
            this.splitContainerOT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSpc)).BeginInit();
            this.splitContainerSpc.Panel1.SuspendLayout();
            this.splitContainerSpc.Panel2.SuspendLayout();
            this.splitContainerSpc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboundOt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutboundOt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboundSpc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOutboundSpc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyStore)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1281, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1281, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabOpenTracTransactions);
            this.tabControl1.Controls.Add(this.tabSpcTransactions);
            this.tabControl1.Controls.Add(this.tabOtSummary);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1281, 579);
            this.tabControl1.TabIndex = 2;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.textLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1273, 550);
            this.tabLogs.TabIndex = 0;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.propertyGrid1);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1273, 550);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabOpenTracTransactions
            // 
            this.tabOpenTracTransactions.Controls.Add(this.splitContainerOT);
            this.tabOpenTracTransactions.Location = new System.Drawing.Point(4, 25);
            this.tabOpenTracTransactions.Name = "tabOpenTracTransactions";
            this.tabOpenTracTransactions.Size = new System.Drawing.Size(1273, 550);
            this.tabOpenTracTransactions.TabIndex = 2;
            this.tabOpenTracTransactions.Text = "OpenTrac Transactions";
            this.tabOpenTracTransactions.UseVisualStyleBackColor = true;
            // 
            // tabSpcTransactions
            // 
            this.tabSpcTransactions.Controls.Add(this.splitContainerSpc);
            this.tabSpcTransactions.Location = new System.Drawing.Point(4, 25);
            this.tabSpcTransactions.Name = "tabSpcTransactions";
            this.tabSpcTransactions.Size = new System.Drawing.Size(1273, 550);
            this.tabSpcTransactions.TabIndex = 3;
            this.tabSpcTransactions.Text = "SPC Transactions";
            this.tabSpcTransactions.UseVisualStyleBackColor = true;
            // 
            // tabOtSummary
            // 
            this.tabOtSummary.Controls.Add(this.dgvKeyStore);
            this.tabOtSummary.Controls.Add(this.panel3);
            this.tabOtSummary.Location = new System.Drawing.Point(4, 25);
            this.tabOtSummary.Name = "tabOtSummary";
            this.tabOtSummary.Size = new System.Drawing.Size(1273, 550);
            this.tabOtSummary.TabIndex = 4;
            this.tabOtSummary.Text = "OpenTrac Summary";
            this.tabOtSummary.UseVisualStyleBackColor = true;
            // 
            // textLogs
            // 
            this.textLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLogs.Location = new System.Drawing.Point(3, 3);
            this.textLogs.Multiline = true;
            this.textLogs.Name = "textLogs";
            this.textLogs.ReadOnly = true;
            this.textLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLogs.Size = new System.Drawing.Size(1267, 544);
            this.textLogs.TabIndex = 0;
            this.textLogs.Text = "(No Logs Yet...)";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(18, 20);
            this.labelStatus.Text = "...";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(1267, 544);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1273, 462);
            this.panel3.TabIndex = 1;
            // 
            // splitContainerOT
            // 
            this.splitContainerOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOT.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOT.Name = "splitContainerOT";
            this.splitContainerOT.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOT.Panel1
            // 
            this.splitContainerOT.Panel1.Controls.Add(this.dgvInboundOt);
            this.splitContainerOT.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainerOT.Panel2
            // 
            this.splitContainerOT.Panel2.Controls.Add(this.dgvOutboundOt);
            this.splitContainerOT.Panel2.Controls.Add(this.panel4);
            this.splitContainerOT.Size = new System.Drawing.Size(1273, 550);
            this.splitContainerOT.SplitterDistance = 266;
            this.splitContainerOT.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 43);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1273, 41);
            this.panel4.TabIndex = 1;
            // 
            // splitContainerSpc
            // 
            this.splitContainerSpc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSpc.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSpc.Name = "splitContainerSpc";
            this.splitContainerSpc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSpc.Panel1
            // 
            this.splitContainerSpc.Panel1.Controls.Add(this.dgvInboundSpc);
            this.splitContainerSpc.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainerSpc.Panel2
            // 
            this.splitContainerSpc.Panel2.Controls.Add(this.dataOutboundSpc);
            this.splitContainerSpc.Panel2.Controls.Add(this.panel5);
            this.splitContainerSpc.Size = new System.Drawing.Size(1273, 550);
            this.splitContainerSpc.SplitterDistance = 289;
            this.splitContainerSpc.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1273, 43);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1273, 41);
            this.panel5.TabIndex = 1;
            // 
            // dgvInboundOt
            // 
            this.dgvInboundOt.AllowUserToAddRows = false;
            this.dgvInboundOt.AllowUserToDeleteRows = false;
            this.dgvInboundOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInboundOt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInboundOt.Location = new System.Drawing.Point(0, 43);
            this.dgvInboundOt.Name = "dgvInboundOt";
            this.dgvInboundOt.ReadOnly = true;
            this.dgvInboundOt.RowTemplate.Height = 24;
            this.dgvInboundOt.Size = new System.Drawing.Size(1273, 223);
            this.dgvInboundOt.TabIndex = 2;
            // 
            // dgvOutboundOt
            // 
            this.dgvOutboundOt.AllowUserToAddRows = false;
            this.dgvOutboundOt.AllowUserToDeleteRows = false;
            this.dgvOutboundOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutboundOt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutboundOt.Location = new System.Drawing.Point(0, 41);
            this.dgvOutboundOt.Name = "dgvOutboundOt";
            this.dgvOutboundOt.ReadOnly = true;
            this.dgvOutboundOt.RowTemplate.Height = 24;
            this.dgvOutboundOt.Size = new System.Drawing.Size(1273, 239);
            this.dgvOutboundOt.TabIndex = 3;
            // 
            // dgvInboundSpc
            // 
            this.dgvInboundSpc.AllowUserToAddRows = false;
            this.dgvInboundSpc.AllowUserToDeleteRows = false;
            this.dgvInboundSpc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInboundSpc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInboundSpc.Location = new System.Drawing.Point(0, 43);
            this.dgvInboundSpc.Name = "dgvInboundSpc";
            this.dgvInboundSpc.ReadOnly = true;
            this.dgvInboundSpc.RowTemplate.Height = 24;
            this.dgvInboundSpc.Size = new System.Drawing.Size(1273, 246);
            this.dgvInboundSpc.TabIndex = 3;
            // 
            // dataOutboundSpc
            // 
            this.dataOutboundSpc.AllowUserToAddRows = false;
            this.dataOutboundSpc.AllowUserToDeleteRows = false;
            this.dataOutboundSpc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOutboundSpc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataOutboundSpc.Location = new System.Drawing.Point(0, 41);
            this.dataOutboundSpc.Name = "dataOutboundSpc";
            this.dataOutboundSpc.ReadOnly = true;
            this.dataOutboundSpc.RowTemplate.Height = 24;
            this.dataOutboundSpc.Size = new System.Drawing.Size(1273, 216);
            this.dataOutboundSpc.TabIndex = 3;
            // 
            // dgvKeyStore
            // 
            this.dgvKeyStore.AllowUserToAddRows = false;
            this.dgvKeyStore.AllowUserToDeleteRows = false;
            this.dgvKeyStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeyStore.Location = new System.Drawing.Point(0, 462);
            this.dgvKeyStore.Name = "dgvKeyStore";
            this.dgvKeyStore.ReadOnly = true;
            this.dgvKeyStore.RowTemplate.Height = 24;
            this.dgvKeyStore.Size = new System.Drawing.Size(1273, 88);
            this.dgvKeyStore.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRANSACTION_INBOUND";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "TRANSACTION_OUTBOUND";
            // 
            // timerSecond
            // 
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 632);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "NSBSL OpenTrac Dashboard";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabOpenTracTransactions.ResumeLayout(false);
            this.tabSpcTransactions.ResumeLayout(false);
            this.tabOtSummary.ResumeLayout(false);
            this.splitContainerOT.Panel1.ResumeLayout(false);
            this.splitContainerOT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOT)).EndInit();
            this.splitContainerOT.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainerSpc.Panel1.ResumeLayout(false);
            this.splitContainerSpc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSpc)).EndInit();
            this.splitContainerSpc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboundOt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutboundOt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboundSpc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOutboundSpc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TextBox textLogs;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabOpenTracTransactions;
        private System.Windows.Forms.TabPage tabSpcTransactions;
        private System.Windows.Forms.TabPage tabOtSummary;
        private System.Windows.Forms.SplitContainer splitContainerOT;
        private System.Windows.Forms.DataGridView dgvInboundOt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOutboundOt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainerSpc;
        private System.Windows.Forms.DataGridView dgvInboundSpc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataOutboundSpc;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvKeyStore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}

