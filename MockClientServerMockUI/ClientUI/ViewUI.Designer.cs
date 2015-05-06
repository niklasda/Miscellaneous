namespace Mockdemo.ClientUI
{
    partial class ViewUI
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
            this.bGet = new System.Windows.Forms.Button();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.bDraw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bGet
            // 
            this.bGet.Location = new System.Drawing.Point(13, 13);
            this.bGet.Name = "bGet";
            this.bGet.Size = new System.Drawing.Size(75, 23);
            this.bGet.TabIndex = 0;
            this.bGet.Text = "Get";
            this.bGet.UseVisualStyleBackColor = true;
            this.bGet.Click += new System.EventHandler(this.bGet_Click);
            // 
            // tbVersion
            // 
            this.tbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVersion.Location = new System.Drawing.Point(13, 54);
            this.tbVersion.Multiline = true;
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(411, 176);
            this.tbVersion.TabIndex = 1;
            this.tbVersion.TextChanged += new System.EventHandler(this.tbVersion_TextChanged);
            // 
            // bDraw
            // 
            this.bDraw.Location = new System.Drawing.Point(95, 13);
            this.bDraw.Name = "bDraw";
            this.bDraw.Size = new System.Drawing.Size(75, 23);
            this.bDraw.TabIndex = 2;
            this.bDraw.Text = "Draw";
            this.bDraw.UseVisualStyleBackColor = true;
            this.bDraw.Click += new System.EventHandler(this.bDraw_Click);
            // 
            // ViewUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 242);
            this.Controls.Add(this.bDraw);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.bGet);
            this.Name = "ViewUI";
            this.Text = "Demo UI v10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGet;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Button bDraw;
    }
}

