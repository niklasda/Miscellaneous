namespace ComLister
{
    partial class VariableExpanderForm
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
            this.pnlExpander = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.cbbVariables = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.pnlExpander.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlExpander
            // 
            this.pnlExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExpander.Controls.Add(this.txtResult);
            this.pnlExpander.Controls.Add(this.cbbVariables);
            this.pnlExpander.Controls.Add(this.btnExpand);
            this.pnlExpander.Location = new System.Drawing.Point(12, 12);
            this.pnlExpander.Name = "pnlExpander";
            this.pnlExpander.Size = new System.Drawing.Size(361, 142);
            this.pnlExpander.TabIndex = 0;
            this.pnlExpander.TabStop = false;
            this.pnlExpander.Text = "Expander";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(298, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(6, 56);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(75, 23);
            this.btnExpand.TabIndex = 1;
            this.btnExpand.Text = "Expand";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // cbbVariables
            // 
            this.cbbVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbVariables.FormattingEnabled = true;
            this.cbbVariables.Location = new System.Drawing.Point(6, 29);
            this.cbbVariables.Name = "cbbVariables";
            this.cbbVariables.Size = new System.Drawing.Size(347, 21);
            this.cbbVariables.TabIndex = 0;
            this.cbbVariables.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbVariables_KeyUp);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(6, 85);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(347, 20);
            this.txtResult.TabIndex = 2;
            // 
            // VariableExpanderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 195);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlExpander);
            this.Name = "VariableExpanderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable Expander";
            this.Load += new System.EventHandler(this.VariableExpanderForm_Load);
            this.pnlExpander.ResumeLayout(false);
            this.pnlExpander.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlExpander;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cbbVariables;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnClose;
    }
}