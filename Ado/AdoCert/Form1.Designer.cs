namespace AdoCert
{
    partial class Form1
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
            this.buttonConn = new System.Windows.Forms.Button();
            this.buttonSchema = new System.Windows.Forms.Button();
            this.buttonAsync = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.dataGridViewSchema = new System.Windows.Forms.DataGridView();
            this.buttonString = new System.Windows.Forms.Button();
            this.buttonAdapter = new System.Windows.Forms.Button();
            this.buttonPool = new System.Windows.Forms.Button();
            this.buttonFaactory = new System.Windows.Forms.Button();
            this.buttonReader = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonMars = new System.Windows.Forms.Button();
            this.buttonXmlReader = new System.Windows.Forms.Button();
            this.buttonFullEdit = new System.Windows.Forms.Button();
            this.buttonCache = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLinqSql = new System.Windows.Forms.Button();
            this.buttonLinqEf = new System.Windows.Forms.Button();
            this.buttonSync = new System.Windows.Forms.Button();
            this.buttonDependency = new System.Windows.Forms.Button();
            this.buttonPermission = new System.Windows.Forms.Button();
            this.buttonRemoveDep = new System.Windows.Forms.Button();
            this.buttonAsync2 = new System.Windows.Forms.Button();
            this.buttonBulk = new System.Windows.Forms.Button();
            this.buttonParams = new System.Windows.Forms.Button();
            this.buttonTrans = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConn
            // 
            this.buttonConn.Location = new System.Drawing.Point(13, 13);
            this.buttonConn.Name = "buttonConn";
            this.buttonConn.Size = new System.Drawing.Size(75, 23);
            this.buttonConn.TabIndex = 0;
            this.buttonConn.Text = "Connect 1";
            this.buttonConn.UseVisualStyleBackColor = true;
            this.buttonConn.Click += new System.EventHandler(this.buttonConn_Click);
            // 
            // buttonSchema
            // 
            this.buttonSchema.Location = new System.Drawing.Point(13, 42);
            this.buttonSchema.Name = "buttonSchema";
            this.buttonSchema.Size = new System.Drawing.Size(75, 23);
            this.buttonSchema.TabIndex = 1;
            this.buttonSchema.Text = "GetSchema";
            this.buttonSchema.UseVisualStyleBackColor = true;
            this.buttonSchema.Click += new System.EventHandler(this.buttonSchema_Click);
            // 
            // buttonAsync
            // 
            this.buttonAsync.Location = new System.Drawing.Point(13, 73);
            this.buttonAsync.Name = "buttonAsync";
            this.buttonAsync.Size = new System.Drawing.Size(75, 23);
            this.buttonAsync.TabIndex = 2;
            this.buttonAsync.Text = "Async Command";
            this.buttonAsync.UseVisualStyleBackColor = true;
            this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLog.Location = new System.Drawing.Point(146, 13);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(534, 578);
            this.textBoxLog.TabIndex = 3;
            // 
            // dataGridViewSchema
            // 
            this.dataGridViewSchema.AllowUserToAddRows = false;
            this.dataGridViewSchema.AllowUserToDeleteRows = false;
            this.dataGridViewSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchema.Location = new System.Drawing.Point(705, 12);
            this.dataGridViewSchema.Name = "dataGridViewSchema";
            this.dataGridViewSchema.ReadOnly = true;
            this.dataGridViewSchema.Size = new System.Drawing.Size(544, 554);
            this.dataGridViewSchema.TabIndex = 4;
            // 
            // buttonString
            // 
            this.buttonString.Location = new System.Drawing.Point(13, 102);
            this.buttonString.Name = "buttonString";
            this.buttonString.Size = new System.Drawing.Size(75, 23);
            this.buttonString.TabIndex = 2;
            this.buttonString.Text = "Cs Builder";
            this.buttonString.UseVisualStyleBackColor = true;
            this.buttonString.Click += new System.EventHandler(this.buttonString_Click);
            // 
            // buttonAdapter
            // 
            this.buttonAdapter.Location = new System.Drawing.Point(13, 131);
            this.buttonAdapter.Name = "buttonAdapter";
            this.buttonAdapter.Size = new System.Drawing.Size(75, 23);
            this.buttonAdapter.TabIndex = 2;
            this.buttonAdapter.Text = "Adapter";
            this.buttonAdapter.UseVisualStyleBackColor = true;
            this.buttonAdapter.Click += new System.EventHandler(this.buttonAdapter_Click);
            // 
            // buttonPool
            // 
            this.buttonPool.Location = new System.Drawing.Point(13, 160);
            this.buttonPool.Name = "buttonPool";
            this.buttonPool.Size = new System.Drawing.Size(75, 23);
            this.buttonPool.TabIndex = 5;
            this.buttonPool.Text = "Pool";
            this.buttonPool.UseVisualStyleBackColor = true;
            this.buttonPool.Click += new System.EventHandler(this.buttonPool_Click);
            // 
            // buttonFaactory
            // 
            this.buttonFaactory.Location = new System.Drawing.Point(13, 189);
            this.buttonFaactory.Name = "buttonFaactory";
            this.buttonFaactory.Size = new System.Drawing.Size(75, 23);
            this.buttonFaactory.TabIndex = 6;
            this.buttonFaactory.Text = "Factory";
            this.buttonFaactory.UseVisualStyleBackColor = true;
            this.buttonFaactory.Click += new System.EventHandler(this.buttonFactory_Click);
            // 
            // buttonReader
            // 
            this.buttonReader.Location = new System.Drawing.Point(13, 218);
            this.buttonReader.Name = "buttonReader";
            this.buttonReader.Size = new System.Drawing.Size(75, 23);
            this.buttonReader.TabIndex = 7;
            this.buttonReader.Text = "Reader";
            this.buttonReader.UseVisualStyleBackColor = true;
            this.buttonReader.Click += new System.EventHandler(this.buttonReader_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Location = new System.Drawing.Point(12, 305);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(75, 23);
            this.buttonTable.TabIndex = 8;
            this.buttonTable.Text = "DataTable";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(12, 335);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 9;
            this.buttonSet.Text = "DataSet";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonMars
            // 
            this.buttonMars.Location = new System.Drawing.Point(12, 365);
            this.buttonMars.Name = "buttonMars";
            this.buttonMars.Size = new System.Drawing.Size(75, 23);
            this.buttonMars.TabIndex = 10;
            this.buttonMars.Text = "MARS";
            this.buttonMars.UseVisualStyleBackColor = true;
            this.buttonMars.Click += new System.EventHandler(this.buttonMars_Click);
            // 
            // buttonXmlReader
            // 
            this.buttonXmlReader.Location = new System.Drawing.Point(12, 247);
            this.buttonXmlReader.Name = "buttonXmlReader";
            this.buttonXmlReader.Size = new System.Drawing.Size(75, 23);
            this.buttonXmlReader.TabIndex = 7;
            this.buttonXmlReader.Text = "XmlReader";
            this.buttonXmlReader.UseVisualStyleBackColor = true;
            this.buttonXmlReader.Click += new System.EventHandler(this.buttonXmlReader_Click);
            // 
            // buttonFullEdit
            // 
            this.buttonFullEdit.Location = new System.Drawing.Point(12, 276);
            this.buttonFullEdit.Name = "buttonFullEdit";
            this.buttonFullEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonFullEdit.TabIndex = 7;
            this.buttonFullEdit.Text = "Full Edit";
            this.buttonFullEdit.UseVisualStyleBackColor = true;
            this.buttonFullEdit.Click += new System.EventHandler(this.buttonFullEdit_Click);
            // 
            // buttonCache
            // 
            this.buttonCache.Location = new System.Drawing.Point(13, 395);
            this.buttonCache.Name = "buttonCache";
            this.buttonCache.Size = new System.Drawing.Size(75, 23);
            this.buttonCache.TabIndex = 11;
            this.buttonCache.Text = "Cache";
            this.buttonCache.UseVisualStyleBackColor = true;
            this.buttonCache.Click += new System.EventHandler(this.buttonCache_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearLog.Location = new System.Drawing.Point(605, 597);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 12;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(1173, 598);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLinqSql
            // 
            this.buttonLinqSql.Location = new System.Drawing.Point(13, 425);
            this.buttonLinqSql.Name = "buttonLinqSql";
            this.buttonLinqSql.Size = new System.Drawing.Size(75, 23);
            this.buttonLinqSql.TabIndex = 14;
            this.buttonLinqSql.Text = "Linq to SQL";
            this.buttonLinqSql.UseVisualStyleBackColor = true;
            this.buttonLinqSql.Click += new System.EventHandler(this.buttonLinqSql_Click);
            // 
            // buttonLinqEf
            // 
            this.buttonLinqEf.Location = new System.Drawing.Point(13, 455);
            this.buttonLinqEf.Name = "buttonLinqEf";
            this.buttonLinqEf.Size = new System.Drawing.Size(75, 23);
            this.buttonLinqEf.TabIndex = 15;
            this.buttonLinqEf.Text = "Linq to EF";
            this.buttonLinqEf.UseVisualStyleBackColor = true;
            this.buttonLinqEf.Click += new System.EventHandler(this.buttonLinqEf_Click);
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(13, 485);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(75, 23);
            this.buttonSync.TabIndex = 16;
            this.buttonSync.Text = "Sync";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // buttonDependency
            // 
            this.buttonDependency.Location = new System.Drawing.Point(13, 514);
            this.buttonDependency.Name = "buttonDependency";
            this.buttonDependency.Size = new System.Drawing.Size(75, 23);
            this.buttonDependency.TabIndex = 16;
            this.buttonDependency.Text = "SqlDepend";
            this.buttonDependency.UseVisualStyleBackColor = true;
            this.buttonDependency.Click += new System.EventHandler(this.buttonDependency_Click);
            // 
            // buttonPermission
            // 
            this.buttonPermission.Location = new System.Drawing.Point(13, 543);
            this.buttonPermission.Name = "buttonPermission";
            this.buttonPermission.Size = new System.Drawing.Size(75, 23);
            this.buttonPermission.TabIndex = 16;
            this.buttonPermission.Text = "Permission";
            this.buttonPermission.UseVisualStyleBackColor = true;
            this.buttonPermission.Click += new System.EventHandler(this.buttonPermission_Click);
            // 
            // buttonRemoveDep
            // 
            this.buttonRemoveDep.Location = new System.Drawing.Point(94, 514);
            this.buttonRemoveDep.Name = "buttonRemoveDep";
            this.buttonRemoveDep.Size = new System.Drawing.Size(32, 23);
            this.buttonRemoveDep.TabIndex = 16;
            this.buttonRemoveDep.Text = "x";
            this.buttonRemoveDep.UseVisualStyleBackColor = true;
            this.buttonRemoveDep.Click += new System.EventHandler(this.buttonRemoveDep_Click);
            // 
            // buttonAsync2
            // 
            this.buttonAsync2.Location = new System.Drawing.Point(51, 82);
            this.buttonAsync2.Name = "buttonAsync2";
            this.buttonAsync2.Size = new System.Drawing.Size(75, 23);
            this.buttonAsync2.TabIndex = 2;
            this.buttonAsync2.Text = "Async Command 2";
            this.buttonAsync2.UseVisualStyleBackColor = true;
            this.buttonAsync2.Click += new System.EventHandler(this.buttonAsync2_Click);
            // 
            // buttonBulk
            // 
            this.buttonBulk.Location = new System.Drawing.Point(12, 572);
            this.buttonBulk.Name = "buttonBulk";
            this.buttonBulk.Size = new System.Drawing.Size(75, 23);
            this.buttonBulk.TabIndex = 17;
            this.buttonBulk.Text = "Bulk";
            this.buttonBulk.UseVisualStyleBackColor = true;
            this.buttonBulk.Click += new System.EventHandler(this.buttonBulk_Click);
            // 
            // buttonParams
            // 
            this.buttonParams.Location = new System.Drawing.Point(42, 26);
            this.buttonParams.Name = "buttonParams";
            this.buttonParams.Size = new System.Drawing.Size(75, 23);
            this.buttonParams.TabIndex = 0;
            this.buttonParams.Text = "Params";
            this.buttonParams.UseVisualStyleBackColor = true;
            this.buttonParams.Click += new System.EventHandler(this.buttonParams_Click);
            // 
            // buttonTrans
            // 
            this.buttonTrans.Location = new System.Drawing.Point(13, 602);
            this.buttonTrans.Name = "buttonTrans";
            this.buttonTrans.Size = new System.Drawing.Size(75, 23);
            this.buttonTrans.TabIndex = 18;
            this.buttonTrans.Text = "Transact";
            this.buttonTrans.UseVisualStyleBackColor = true;
            this.buttonTrans.Click += new System.EventHandler(this.buttonTrans_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 633);
            this.Controls.Add(this.buttonTrans);
            this.Controls.Add(this.buttonBulk);
            this.Controls.Add(this.buttonPermission);
            this.Controls.Add(this.buttonRemoveDep);
            this.Controls.Add(this.buttonDependency);
            this.Controls.Add(this.buttonSync);
            this.Controls.Add(this.buttonLinqEf);
            this.Controls.Add(this.buttonLinqSql);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.buttonCache);
            this.Controls.Add(this.buttonMars);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.buttonFullEdit);
            this.Controls.Add(this.buttonXmlReader);
            this.Controls.Add(this.buttonReader);
            this.Controls.Add(this.buttonFaactory);
            this.Controls.Add(this.buttonPool);
            this.Controls.Add(this.dataGridViewSchema);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonAdapter);
            this.Controls.Add(this.buttonString);
            this.Controls.Add(this.buttonAsync2);
            this.Controls.Add(this.buttonAsync);
            this.Controls.Add(this.buttonSchema);
            this.Controls.Add(this.buttonParams);
            this.Controls.Add(this.buttonConn);
            this.Name = "Form1";
            this.Text = "Ado Cert";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConn;
        private System.Windows.Forms.Button buttonSchema;
        private System.Windows.Forms.Button buttonAsync;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.DataGridView dataGridViewSchema;
        private System.Windows.Forms.Button buttonString;
        private System.Windows.Forms.Button buttonAdapter;
        private System.Windows.Forms.Button buttonPool;
        private System.Windows.Forms.Button buttonFaactory;
        private System.Windows.Forms.Button buttonReader;
        private System.Windows.Forms.Button buttonTable;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonMars;
        private System.Windows.Forms.Button buttonXmlReader;
        private System.Windows.Forms.Button buttonFullEdit;
        private System.Windows.Forms.Button buttonCache;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLinqSql;
        private System.Windows.Forms.Button buttonLinqEf;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.Button buttonDependency;
        private System.Windows.Forms.Button buttonPermission;
        private System.Windows.Forms.Button buttonRemoveDep;
        private System.Windows.Forms.Button buttonAsync2;
        private System.Windows.Forms.Button buttonBulk;
        private System.Windows.Forms.Button buttonParams;
        private System.Windows.Forms.Button buttonTrans;
    }
}

