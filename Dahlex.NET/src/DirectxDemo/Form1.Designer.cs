namespace DirectxDemo
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
            this.gbDrawAreaContainer = new System.Windows.Forms.GroupBox();
            this.pDrawArea = new System.Windows.Forms.Panel();
            this.bDoSomething = new System.Windows.Forms.Button();
            this.b3d = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.gbDrawAreaContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDrawAreaContainer
            // 
            this.gbDrawAreaContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDrawAreaContainer.Controls.Add(this.pDrawArea);
            this.gbDrawAreaContainer.Location = new System.Drawing.Point(13, 13);
            this.gbDrawAreaContainer.Name = "gbDrawAreaContainer";
            this.gbDrawAreaContainer.Size = new System.Drawing.Size(358, 271);
            this.gbDrawAreaContainer.TabIndex = 0;
            this.gbDrawAreaContainer.TabStop = false;
            this.gbDrawAreaContainer.Text = "DrawAreaContainer";
            // 
            // pDrawArea
            // 
            this.pDrawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pDrawArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDrawArea.Location = new System.Drawing.Point(7, 20);
            this.pDrawArea.Name = "pDrawArea";
            this.pDrawArea.Size = new System.Drawing.Size(345, 245);
            this.pDrawArea.TabIndex = 0;
            this.pDrawArea.Resize += new System.EventHandler(this.pDrawArea_Resize);
            this.pDrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pDrawArea_Paint);
            // 
            // bDoSomething
            // 
            this.bDoSomething.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDoSomething.Location = new System.Drawing.Point(13, 291);
            this.bDoSomething.Name = "bDoSomething";
            this.bDoSomething.Size = new System.Drawing.Size(100, 23);
            this.bDoSomething.TabIndex = 1;
            this.bDoSomething.Text = "Do something";
            this.bDoSomething.UseVisualStyleBackColor = true;
            this.bDoSomething.Click += new System.EventHandler(this.bDoSomething_Click);
            // 
            // b3d
            // 
            this.b3d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b3d.Location = new System.Drawing.Point(130, 291);
            this.b3d.Name = "b3d";
            this.b3d.Size = new System.Drawing.Size(75, 23);
            this.b3d.TabIndex = 2;
            this.b3d.Text = "Do 3D";
            this.b3d.UseVisualStyleBackColor = true;
            this.b3d.Click += new System.EventHandler(this.b3d_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClear.Location = new System.Drawing.Point(212, 291);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bReset
            // 
            this.bReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bReset.Location = new System.Drawing.Point(294, 291);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 4;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 329);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.b3d);
            this.Controls.Add(this.bDoSomething);
            this.Controls.Add(this.gbDrawAreaContainer);
            this.Name = "Form1";
            this.Text = "DirectX 9 .NET 2.0 x64 demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDrawAreaContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDrawAreaContainer;
        private System.Windows.Forms.Panel pDrawArea;
        private System.Windows.Forms.Button bDoSomething;
        private System.Windows.Forms.Button b3d;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bReset;
    }
}

