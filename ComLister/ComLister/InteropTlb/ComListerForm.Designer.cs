namespace ComLister
{
    partial class ComListerForm
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
            this.txtInteropLog = new System.Windows.Forms.TextBox();
            this.gridComs = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnHideSystem = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCOMObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCOMPlusObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInProcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showDepenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWhosLockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDependencyWalkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWhoslockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.variableExpanderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.openSystemRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridComs)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInteropLog
            // 
            this.txtInteropLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInteropLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtInteropLog.Location = new System.Drawing.Point(12, 33);
            this.txtInteropLog.Multiline = true;
            this.txtInteropLog.Name = "txtInteropLog";
            this.txtInteropLog.ReadOnly = true;
            this.txtInteropLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInteropLog.Size = new System.Drawing.Size(487, 152);
            this.txtInteropLog.TabIndex = 1;
            // 
            // gridComs
            // 
            this.gridComs.AllowUserToAddRows = false;
            this.gridComs.AllowUserToDeleteRows = false;
            this.gridComs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridComs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComs.Location = new System.Drawing.Point(12, 230);
            this.gridComs.MultiSelect = false;
            this.gridComs.Name = "gridComs";
            this.gridComs.ReadOnly = true;
            this.gridComs.Size = new System.Drawing.Size(858, 274);
            this.gridComs.TabIndex = 0;
            this.gridComs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComs_CellClick);
            this.gridComs.SelectionChanged += new System.EventHandler(this.gridComs_SelectionChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(88, 201);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(140, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyUp);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(232, 199);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(61, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(20, 203);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(68, 13);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Caption filter:";
            // 
            // btnHideSystem
            // 
            this.btnHideSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnHideSystem.AutoSize = true;
            this.btnHideSystem.Location = new System.Drawing.Point(305, 199);
            this.btnHideSystem.Name = "btnHideSystem";
            this.btnHideSystem.Size = new System.Drawing.Size(164, 23);
            this.btnHideSystem.TabIndex = 5;
            this.btnHideSystem.Text = "Hide Empty and System Entries";
            this.btnHideSystem.UseVisualStyleBackColor = true;
            this.btnHideSystem.CheckedChanged += new System.EventHandler(this.btnHideSystem_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(799, 211);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(26, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "#: 0";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(882, 24);
            this.menuStripMain.TabIndex = 7;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listCOMObjectsToolStripMenuItem,
            this.listCOMPlusObjectsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // listCOMObjectsToolStripMenuItem
            // 
            this.listCOMObjectsToolStripMenuItem.Name = "listCOMObjectsToolStripMenuItem";
            this.listCOMObjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.listCOMObjectsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.listCOMObjectsToolStripMenuItem.Text = "List &COM Objects";
            this.listCOMObjectsToolStripMenuItem.Click += new System.EventHandler(this.listCOMObjectsToolStripMenuItem_Click);
            // 
            // listCOMPlusObjectsToolStripMenuItem
            // 
            this.listCOMPlusObjectsToolStripMenuItem.Name = "listCOMPlusObjectsToolStripMenuItem";
            this.listCOMPlusObjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.listCOMPlusObjectsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.listCOMPlusObjectsToolStripMenuItem.Text = "List COM&+ Objects";
            this.listCOMPlusObjectsToolStripMenuItem.Click += new System.EventHandler(this.listCOMPlusObjectsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocationToolStripMenuItem,
            this.openLocalToolStripMenuItem,
            this.openInProcToolStripMenuItem,
            this.toolStripMenuItem1,
            this.registerToolStripMenuItem,
            this.unregisterToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showDepenToolStripMenuItem,
            this.showWhosLockingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // openLocationToolStripMenuItem
            // 
            this.openLocationToolStripMenuItem.Name = "openLocationToolStripMenuItem";
            this.openLocationToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openLocationToolStripMenuItem.Text = "Open Location";
            this.openLocationToolStripMenuItem.Click += new System.EventHandler(this.openLocationToolStripMenuItem_Click);
            // 
            // openLocalToolStripMenuItem
            // 
            this.openLocalToolStripMenuItem.Name = "openLocalToolStripMenuItem";
            this.openLocalToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openLocalToolStripMenuItem.Text = "Open LocalServer Location";
            this.openLocalToolStripMenuItem.Click += new System.EventHandler(this.openLocalToolStripMenuItem_Click);
            // 
            // openInProcToolStripMenuItem
            // 
            this.openInProcToolStripMenuItem.Name = "openInProcToolStripMenuItem";
            this.openInProcToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openInProcToolStripMenuItem.Text = "Open InProcServer Location";
            this.openInProcToolStripMenuItem.Click += new System.EventHandler(this.openInProcToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // unregisterToolStripMenuItem
            // 
            this.unregisterToolStripMenuItem.Name = "unregisterToolStripMenuItem";
            this.unregisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.unregisterToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.unregisterToolStripMenuItem.Text = "Unregister";
            this.unregisterToolStripMenuItem.Click += new System.EventHandler(this.unregisterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // showDepenToolStripMenuItem
            // 
            this.showDepenToolStripMenuItem.Name = "showDepenToolStripMenuItem";
            this.showDepenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.showDepenToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showDepenToolStripMenuItem.Text = "Show Dependencies";
            this.showDepenToolStripMenuItem.Click += new System.EventHandler(this.showDependenciesToolStripMenuItem_Click);
            // 
            // showWhosLockingToolStripMenuItem
            // 
            this.showWhosLockingToolStripMenuItem.Name = "showWhosLockingToolStripMenuItem";
            this.showWhosLockingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.showWhosLockingToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showWhosLockingToolStripMenuItem.Text = "Show Who\'s Locking";
            this.showWhosLockingToolStripMenuItem.Click += new System.EventHandler(this.showWhosLockingToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDependencyWalkerToolStripMenuItem,
            this.startWhoslockingToolStripMenuItem,
            this.toolStripMenuItem3,
            this.variableExpanderToolStripMenuItem,
            this.toolStripMenuItem4,
            this.openSystemRootToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // startDependencyWalkerToolStripMenuItem
            // 
            this.startDependencyWalkerToolStripMenuItem.Name = "startDependencyWalkerToolStripMenuItem";
            this.startDependencyWalkerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.startDependencyWalkerToolStripMenuItem.Text = "Start Dependency Walker";
            this.startDependencyWalkerToolStripMenuItem.Click += new System.EventHandler(this.startDependencyWalkerToolStripMenuItem_Click);
            // 
            // startWhoslockingToolStripMenuItem
            // 
            this.startWhoslockingToolStripMenuItem.Name = "startWhoslockingToolStripMenuItem";
            this.startWhoslockingToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.startWhoslockingToolStripMenuItem.Text = "Start Who\'s Locking";
            this.startWhoslockingToolStripMenuItem.Click += new System.EventHandler(this.startWhoslockingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(196, 6);
            // 
            // variableExpanderToolStripMenuItem
            // 
            this.variableExpanderToolStripMenuItem.Name = "variableExpanderToolStripMenuItem";
            this.variableExpanderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.variableExpanderToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.variableExpanderToolStripMenuItem.Text = "Variable Expander";
            this.variableExpanderToolStripMenuItem.Click += new System.EventHandler(this.variableExpanderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(196, 6);
            // 
            // openSystemRootToolStripMenuItem
            // 
            this.openSystemRootToolStripMenuItem.Name = "openSystemRootToolStripMenuItem";
            this.openSystemRootToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openSystemRootToolStripMenuItem.Text = "Open %SystemRoot%";
            this.openSystemRootToolStripMenuItem.Click += new System.EventHandler(this.openSystemRootToolStripMenuItem_Click);
            // 
            // ComListerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 516);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnHideSystem);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.gridComs);
            this.Controls.Add(this.txtInteropLog);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "ComListerForm";
            this.Text = "COM Lister";
            ((System.ComponentModel.ISupportInitialize)(this.gridComs)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInteropLog;
        private System.Windows.Forms.DataGridView gridComs;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox btnHideSystem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listCOMObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listCOMPlusObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInProcToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDepenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWhosLockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDependencyWalkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWhoslockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem variableExpanderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem openSystemRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

