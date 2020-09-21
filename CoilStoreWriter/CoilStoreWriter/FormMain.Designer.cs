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
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerGeneral = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.textLogs = new System.Windows.Forms.TextBox();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonTestRefresh = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.textFileCandidate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvCoils = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvCoilReadingsDb = new System.Windows.Forms.DataGridView();
            this.dgvCoilReadingsList = new System.Windows.Forms.DataGridView();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoils)).BeginInit();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilReadingsDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilReadingsList)).BeginInit();
            this.statusStrip3.SuspendLayout();
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
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem2.Text = "&File";
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem2.Text = "E&xit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
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
            this.tabStatus.Controls.Add(this.splitContainer4);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(1132, 470);
            this.tabStatus.TabIndex = 3;
            this.tabStatus.Text = "Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer4.Size = new System.Drawing.Size(1132, 470);
            this.splitContainer4.SplitterDistance = 177;
            this.splitContainer4.TabIndex = 0;
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
            this.tabControl1.Controls.Add(this.tabTest);
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
            // tabTest
            // 
            this.tabTest.Controls.Add(this.splitContainer1);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Size = new System.Drawing.Size(1132, 470);
            this.tabTest.TabIndex = 4;
            this.tabTest.Text = "Test";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonTestRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.buttonChooseFile);
            this.splitContainer1.Panel1.Controls.Add(this.textFileCandidate);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 470);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonTestRefresh
            // 
            this.buttonTestRefresh.Location = new System.Drawing.Point(11, 166);
            this.buttonTestRefresh.Name = "buttonTestRefresh";
            this.buttonTestRefresh.Size = new System.Drawing.Size(87, 42);
            this.buttonTestRefresh.TabIndex = 3;
            this.buttonTestRefresh.Text = "Refresh";
            this.buttonTestRefresh.UseVisualStyleBackColor = true;
            this.buttonTestRefresh.Click += new System.EventHandler(this.buttonTestRefresh_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(191, 29);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseFile.TabIndex = 2;
            this.buttonChooseFile.Text = "Choose...";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // textFileCandidate
            // 
            this.textFileCandidate.Location = new System.Drawing.Point(11, 59);
            this.textFileCandidate.Multiline = true;
            this.textFileCandidate.Name = "textFileCandidate";
            this.textFileCandidate.ReadOnly = true;
            this.textFileCandidate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textFileCandidate.Size = new System.Drawing.Size(363, 57);
            this.textFileCandidate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose File to place in import folder:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvCoils);
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip3);
            this.splitContainer2.Size = new System.Drawing.Size(751, 470);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvCoils
            // 
            this.dgvCoils.AllowUserToAddRows = false;
            this.dgvCoils.AllowUserToDeleteRows = false;
            this.dgvCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoils.Location = new System.Drawing.Point(0, 22);
            this.dgvCoils.Name = "dgvCoils";
            this.dgvCoils.ReadOnly = true;
            this.dgvCoils.Size = new System.Drawing.Size(751, 186);
            this.dgvCoils.TabIndex = 1;
            this.dgvCoils.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoils_CellContentClick);
            this.dgvCoils.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCoils_RowHeaderMouseClick);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(751, 22);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel1.Text = "Coil";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 22);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvCoilReadingsDb);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvCoilReadingsList);
            this.splitContainer3.Size = new System.Drawing.Size(751, 236);
            this.splitContainer3.SplitterDistance = 404;
            this.splitContainer3.TabIndex = 1;
            // 
            // dgvCoilReadingsDb
            // 
            this.dgvCoilReadingsDb.AllowUserToAddRows = false;
            this.dgvCoilReadingsDb.AllowUserToDeleteRows = false;
            this.dgvCoilReadingsDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoilReadingsDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoilReadingsDb.Location = new System.Drawing.Point(0, 0);
            this.dgvCoilReadingsDb.Name = "dgvCoilReadingsDb";
            this.dgvCoilReadingsDb.ReadOnly = true;
            this.dgvCoilReadingsDb.Size = new System.Drawing.Size(404, 236);
            this.dgvCoilReadingsDb.TabIndex = 2;
            // 
            // dgvCoilReadingsList
            // 
            this.dgvCoilReadingsList.AllowUserToAddRows = false;
            this.dgvCoilReadingsList.AllowUserToDeleteRows = false;
            this.dgvCoilReadingsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoilReadingsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoilReadingsList.Location = new System.Drawing.Point(0, 0);
            this.dgvCoilReadingsList.Name = "dgvCoilReadingsList";
            this.dgvCoilReadingsList.ReadOnly = true;
            this.dgvCoilReadingsList.Size = new System.Drawing.Size(343, 236);
            this.dgvCoilReadingsList.TabIndex = 2;
            // 
            // statusStrip3
            // 
            this.statusStrip3.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip3.Location = new System.Drawing.Point(0, 0);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(751, 22);
            this.statusStrip3.TabIndex = 0;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(272, 17);
            this.toolStripStatusLabel2.Text = "CoilReading (left is table, right is from comma list)";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            this.tabTest.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoils)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilReadingsDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilReadingsList)).EndInit();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
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
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TextBox textLogs;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.TextBox textFileCandidate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvCoils;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvCoilReadingsDb;
        private System.Windows.Forms.DataGridView dgvCoilReadingsList;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button buttonTestRefresh;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}

