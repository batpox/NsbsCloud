namespace OpenTracDashboard
{
    partial class FormConnectStrings
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.v = new System.Windows.Forms.TabPage();
            this.tabSpcDb = new System.Windows.Forms.TabPage();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textOTDataSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxOTIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonOTChangeConnection = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.v.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(895, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.v);
            this.tabControl1.Controls.Add(this.tabSpcDb);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(895, 324);
            this.tabControl1.TabIndex = 2;
            // 
            // v
            // 
            this.v.Controls.Add(this.buttonOTChangeConnection);
            this.v.Controls.Add(this.textBox3);
            this.v.Controls.Add(this.textBox2);
            this.v.Controls.Add(this.textBox1);
            this.v.Controls.Add(this.checkBoxOTIntegratedSecurity);
            this.v.Controls.Add(this.label5);
            this.v.Controls.Add(this.label4);
            this.v.Controls.Add(this.label3);
            this.v.Controls.Add(this.label2);
            this.v.Controls.Add(this.textOTDataSource);
            this.v.Controls.Add(this.label1);
            this.v.Location = new System.Drawing.Point(4, 25);
            this.v.Name = "v";
            this.v.Padding = new System.Windows.Forms.Padding(3);
            this.v.Size = new System.Drawing.Size(887, 295);
            this.v.TabIndex = 0;
            this.v.Text = "OpenTrac DB";
            this.v.UseVisualStyleBackColor = true;
            // 
            // tabSpcDb
            // 
            this.tabSpcDb.Location = new System.Drawing.Point(4, 25);
            this.tabSpcDb.Name = "tabSpcDb";
            this.tabSpcDb.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpcDb.Size = new System.Drawing.Size(967, 579);
            this.tabSpcDb.TabIndex = 1;
            this.tabSpcDb.Text = "SPC Db";
            this.tabSpcDb.UseVisualStyleBackColor = true;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataSource";
            // 
            // textOTDataSource
            // 
            this.textOTDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOTDataSource.Location = new System.Drawing.Point(168, 46);
            this.textOTDataSource.Name = "textOTDataSource";
            this.textOTDataSource.Size = new System.Drawing.Size(695, 22);
            this.textOTDataSource.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "InitialCatalog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "UserID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "IntegratedSecurity";
            // 
            // checkBoxOTIntegratedSecurity
            // 
            this.checkBoxOTIntegratedSecurity.AutoSize = true;
            this.checkBoxOTIntegratedSecurity.Location = new System.Drawing.Point(168, 158);
            this.checkBoxOTIntegratedSecurity.Name = "checkBoxOTIntegratedSecurity";
            this.checkBoxOTIntegratedSecurity.Size = new System.Drawing.Size(18, 17);
            this.checkBoxOTIntegratedSecurity.TabIndex = 6;
            this.checkBoxOTIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(168, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(459, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(168, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(274, 22);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(168, 130);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(274, 22);
            this.textBox3.TabIndex = 9;
            // 
            // buttonOTChangeConnection
            // 
            this.buttonOTChangeConnection.Location = new System.Drawing.Point(445, 213);
            this.buttonOTChangeConnection.Name = "buttonOTChangeConnection";
            this.buttonOTChangeConnection.Size = new System.Drawing.Size(203, 37);
            this.buttonOTChangeConnection.TabIndex = 10;
            this.buttonOTChangeConnection.Text = "Change Connection";
            this.toolTip1.SetToolTip(this.buttonOTChangeConnection, "Change and Test the new Connection String");
            this.buttonOTChangeConnection.UseVisualStyleBackColor = true;
            // 
            // FormConnectStrings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 374);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormConnectStrings";
            this.Text = "Database Connect Strings";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.v.ResumeLayout(false);
            this.v.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage v;
        private System.Windows.Forms.TabPage tabSpcDb;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxOTIntegratedSecurity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textOTDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOTChangeConnection;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}