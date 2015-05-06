namespace XceedBoll
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chartToolbarControl1 = new Xceed.Chart.ChartToolbarControl();
            this.m_ChartControl = new Xceed.Chart.ChartControl();
            this.groupBoxEmaControls = new System.Windows.Forms.GroupBox();
            this.checkBoxEma = new System.Windows.Forms.CheckBox();
            this.trackBarEmaPeriod = new System.Windows.Forms.TrackBar();
            this.groupBoxSmaControls = new System.Windows.Forms.GroupBox();
            this.checkBoxSma = new System.Windows.Forms.CheckBox();
            this.trackBarSmaPeriod = new System.Windows.Forms.TrackBar();
            this.groupBoxBollControls = new System.Windows.Forms.GroupBox();
            this.checkBoxBoll = new System.Windows.Forms.CheckBox();
            this.trackBarDeviation = new System.Windows.Forms.TrackBar();
            this.trackBarBollPeriod = new System.Windows.Forms.TrackBar();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.checkBoxCandleStyle = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelRate = new System.Windows.Forms.Label();
            this.groupBoxEmaControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmaPeriod)).BeginInit();
            this.groupBoxSmaControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmaPeriod)).BeginInit();
            this.groupBoxBollControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBollPeriod)).BeginInit();
            this.groupBoxChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartToolbarControl1
            // 
            this.chartToolbarControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Load);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Save);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Print);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ActiveChart);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Wizard);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ChartEditor);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.RotateLeft);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.RotateRight);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ElevationUp);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ElevationDown);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ZoomIn);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ZoomOut);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ViewerRotationLeft);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ViewerRotationRight);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.OffsetXLeft);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.OffsetXRight);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.OffsetYUp);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.OffsetYDown);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.IncreaseChartWidth);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.IncreaseChartHeight);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.IncreaseChartDepth);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.DecreaseChartWidth);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.DecreaseChartHeight);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.DecreaseChartDepth);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Orthogonal);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Perspective);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.View2D);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.PredefinedProjection);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.MouseTrackball);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.MouseZoom);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.MouseOffset);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.MouseDisabled);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.PredefinedLightScheme);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.Separator);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.ImageBorder);
            this.chartToolbarControl1.ButtonsConfig.Add(Xceed.Chart.ChartToolbarButtons.BackgroundFillEffect);
            this.chartToolbarControl1.ChartControl = null;
            this.chartToolbarControl1.ChartSizeStep = 5F;
            this.chartToolbarControl1.ElevationStep = 10F;
            this.chartToolbarControl1.Location = new System.Drawing.Point(2, 2);
            this.chartToolbarControl1.Name = "chartToolbarControl1";
            this.chartToolbarControl1.OffsetStep = 5F;
            this.chartToolbarControl1.RotationStep = 10F;
            this.chartToolbarControl1.Size = new System.Drawing.Size(914, 22);
            this.chartToolbarControl1.TabIndex = 2;
            this.chartToolbarControl1.ZoomStep = 5F;
            // 
            // m_ChartControl
            // 
            this.m_ChartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ChartControl.BackColor = System.Drawing.SystemColors.Control;
            this.m_ChartControl.Background = ((Xceed.Chart.Standard.Background)(resources.GetObject("m_ChartControl.Background")));
            this.m_ChartControl.Charts = ((Xceed.Chart.Core.ChartCollection)(resources.GetObject("m_ChartControl.Charts")));
            this.m_ChartControl.InteractivityOperations = ((Xceed.Chart.Core.InteractivityOperationsCollection)(resources.GetObject("m_ChartControl.InteractivityOperations")));
            this.m_ChartControl.Labels = ((Xceed.Chart.Standard.ChartLabelCollection)(resources.GetObject("m_ChartControl.Labels")));
            this.m_ChartControl.Legends = ((Xceed.Chart.Core.LegendCollection)(resources.GetObject("m_ChartControl.Legends")));
            this.m_ChartControl.Location = new System.Drawing.Point(12, 41);
            this.m_ChartControl.Name = "m_ChartControl";
            this.m_ChartControl.Settings = ((Xceed.Chart.Core.Settings)(resources.GetObject("m_ChartControl.Settings")));
            this.m_ChartControl.Size = new System.Drawing.Size(996, 522);
            this.m_ChartControl.TabIndex = 4;
            this.m_ChartControl.Text = "chartControl1";
            this.m_ChartControl.Watermarks = ((Xceed.Chart.Standard.WatermarkCollection)(resources.GetObject("m_ChartControl.Watermarks")));
            // 
            // groupBoxEmaControls
            // 
            this.groupBoxEmaControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEmaControls.Controls.Add(this.checkBoxEma);
            this.groupBoxEmaControls.Controls.Add(this.trackBarEmaPeriod);
            this.groupBoxEmaControls.Location = new System.Drawing.Point(1025, 41);
            this.groupBoxEmaControls.Name = "groupBoxEmaControls";
            this.groupBoxEmaControls.Size = new System.Drawing.Size(286, 90);
            this.groupBoxEmaControls.TabIndex = 5;
            this.groupBoxEmaControls.TabStop = false;
            this.groupBoxEmaControls.Text = "EMA Controls";
            // 
            // checkBoxEma
            // 
            this.checkBoxEma.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEma.AutoSize = true;
            this.checkBoxEma.Location = new System.Drawing.Point(6, 38);
            this.checkBoxEma.Name = "checkBoxEma";
            this.checkBoxEma.Size = new System.Drawing.Size(40, 23);
            this.checkBoxEma.TabIndex = 2;
            this.checkBoxEma.Text = "EMA";
            this.checkBoxEma.UseVisualStyleBackColor = true;
            this.checkBoxEma.CheckedChanged += new System.EventHandler(this.checkBoxEma_CheckedChanged);
            // 
            // trackBarEmaPeriod
            // 
            this.trackBarEmaPeriod.Location = new System.Drawing.Point(52, 38);
            this.trackBarEmaPeriod.Maximum = 300;
            this.trackBarEmaPeriod.Name = "trackBarEmaPeriod";
            this.trackBarEmaPeriod.Size = new System.Drawing.Size(228, 45);
            this.trackBarEmaPeriod.TabIndex = 1;
            this.trackBarEmaPeriod.TickFrequency = 10;
            this.trackBarEmaPeriod.Value = 20;
            this.trackBarEmaPeriod.Scroll += new System.EventHandler(this.trackBarEma_Scroll);
            // 
            // groupBoxSmaControls
            // 
            this.groupBoxSmaControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSmaControls.Controls.Add(this.checkBoxSma);
            this.groupBoxSmaControls.Controls.Add(this.trackBarSmaPeriod);
            this.groupBoxSmaControls.Location = new System.Drawing.Point(1031, 137);
            this.groupBoxSmaControls.Name = "groupBoxSmaControls";
            this.groupBoxSmaControls.Size = new System.Drawing.Size(286, 90);
            this.groupBoxSmaControls.TabIndex = 6;
            this.groupBoxSmaControls.TabStop = false;
            this.groupBoxSmaControls.Text = "SMA Controls";
            // 
            // checkBoxSma
            // 
            this.checkBoxSma.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSma.AutoSize = true;
            this.checkBoxSma.Location = new System.Drawing.Point(6, 38);
            this.checkBoxSma.Name = "checkBoxSma";
            this.checkBoxSma.Size = new System.Drawing.Size(40, 23);
            this.checkBoxSma.TabIndex = 2;
            this.checkBoxSma.Text = "SMA";
            this.checkBoxSma.UseVisualStyleBackColor = true;
            this.checkBoxSma.CheckedChanged += new System.EventHandler(this.checkBoxSma_CheckedChanged);
            // 
            // trackBarSmaPeriod
            // 
            this.trackBarSmaPeriod.Location = new System.Drawing.Point(52, 38);
            this.trackBarSmaPeriod.Maximum = 300;
            this.trackBarSmaPeriod.Name = "trackBarSmaPeriod";
            this.trackBarSmaPeriod.Size = new System.Drawing.Size(228, 45);
            this.trackBarSmaPeriod.TabIndex = 1;
            this.trackBarSmaPeriod.TickFrequency = 10;
            this.trackBarSmaPeriod.Value = 20;
            this.trackBarSmaPeriod.Scroll += new System.EventHandler(this.trackBarEma_Scroll);
            // 
            // groupBoxBollControls
            // 
            this.groupBoxBollControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBollControls.Controls.Add(this.checkBoxBoll);
            this.groupBoxBollControls.Controls.Add(this.trackBarDeviation);
            this.groupBoxBollControls.Controls.Add(this.trackBarBollPeriod);
            this.groupBoxBollControls.Location = new System.Drawing.Point(1031, 233);
            this.groupBoxBollControls.Name = "groupBoxBollControls";
            this.groupBoxBollControls.Size = new System.Drawing.Size(286, 134);
            this.groupBoxBollControls.TabIndex = 6;
            this.groupBoxBollControls.TabStop = false;
            this.groupBoxBollControls.Text = "Bollinger Controls";
            // 
            // checkBoxBoll
            // 
            this.checkBoxBoll.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBoll.AutoSize = true;
            this.checkBoxBoll.Location = new System.Drawing.Point(6, 38);
            this.checkBoxBoll.Name = "checkBoxBoll";
            this.checkBoxBoll.Size = new System.Drawing.Size(34, 23);
            this.checkBoxBoll.TabIndex = 2;
            this.checkBoxBoll.Text = "Boll";
            this.checkBoxBoll.UseVisualStyleBackColor = true;
            this.checkBoxBoll.CheckedChanged += new System.EventHandler(this.checkBoxBoll_CheckedChanged);
            // 
            // trackBarDeviation
            // 
            this.trackBarDeviation.Location = new System.Drawing.Point(52, 83);
            this.trackBarDeviation.Maximum = 20;
            this.trackBarDeviation.Name = "trackBarDeviation";
            this.trackBarDeviation.Size = new System.Drawing.Size(228, 45);
            this.trackBarDeviation.TabIndex = 1;
            this.trackBarDeviation.TickFrequency = 10;
            this.trackBarDeviation.Value = 5;
            this.trackBarDeviation.Scroll += new System.EventHandler(this.trackBarEma_Scroll);
            // 
            // trackBarBollPeriod
            // 
            this.trackBarBollPeriod.Location = new System.Drawing.Point(52, 38);
            this.trackBarBollPeriod.Maximum = 20;
            this.trackBarBollPeriod.Name = "trackBarBollPeriod";
            this.trackBarBollPeriod.Size = new System.Drawing.Size(228, 45);
            this.trackBarBollPeriod.TabIndex = 1;
            this.trackBarBollPeriod.TickFrequency = 10;
            this.trackBarBollPeriod.Value = 5;
            this.trackBarBollPeriod.Scroll += new System.EventHandler(this.trackBarEma_Scroll);
            // 
            // groupBoxChart
            // 
            this.groupBoxChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxChart.Controls.Add(this.labelRate);
            this.groupBoxChart.Controls.Add(this.checkBoxCandleStyle);
            this.groupBoxChart.Location = new System.Drawing.Point(1031, 389);
            this.groupBoxChart.Name = "groupBoxChart";
            this.groupBoxChart.Size = new System.Drawing.Size(286, 90);
            this.groupBoxChart.TabIndex = 7;
            this.groupBoxChart.TabStop = false;
            this.groupBoxChart.Text = "Chart Controls";
            // 
            // checkBoxCandleStyle
            // 
            this.checkBoxCandleStyle.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCandleStyle.AutoSize = true;
            this.checkBoxCandleStyle.Location = new System.Drawing.Point(7, 20);
            this.checkBoxCandleStyle.Name = "checkBoxCandleStyle";
            this.checkBoxCandleStyle.Size = new System.Drawing.Size(45, 23);
            this.checkBoxCandleStyle.TabIndex = 0;
            this.checkBoxCandleStyle.Text = "-> Bar";
            this.checkBoxCandleStyle.UseVisualStyleBackColor = true;
            this.checkBoxCandleStyle.CheckedChanged += new System.EventHandler(this.checkBoxCandleStyle_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(96, 40);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(43, 13);
            this.labelRate.TabIndex = 1;
            this.labelRate.Text = "Waiting";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 575);
            this.Controls.Add(this.groupBoxChart);
            this.Controls.Add(this.groupBoxBollControls);
            this.Controls.Add(this.groupBoxSmaControls);
            this.Controls.Add(this.groupBoxEmaControls);
            this.Controls.Add(this.m_ChartControl);
            this.Controls.Add(this.chartToolbarControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxEmaControls.ResumeLayout(false);
            this.groupBoxEmaControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmaPeriod)).EndInit();
            this.groupBoxSmaControls.ResumeLayout(false);
            this.groupBoxSmaControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmaPeriod)).EndInit();
            this.groupBoxBollControls.ResumeLayout(false);
            this.groupBoxBollControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBollPeriod)).EndInit();
            this.groupBoxChart.ResumeLayout(false);
            this.groupBoxChart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Xceed.Chart.ChartToolbarControl chartToolbarControl1;
        private Xceed.Chart.ChartControl m_ChartControl;
        private System.Windows.Forms.GroupBox groupBoxEmaControls;
        private System.Windows.Forms.TrackBar trackBarEmaPeriod;
        private System.Windows.Forms.CheckBox checkBoxEma;
        private System.Windows.Forms.GroupBox groupBoxSmaControls;
        private System.Windows.Forms.CheckBox checkBoxSma;
        private System.Windows.Forms.TrackBar trackBarSmaPeriod;
        private System.Windows.Forms.GroupBox groupBoxBollControls;
        private System.Windows.Forms.CheckBox checkBoxBoll;
        private System.Windows.Forms.TrackBar trackBarBollPeriod;
        private System.Windows.Forms.TrackBar trackBarDeviation;
        private System.Windows.Forms.GroupBox groupBoxChart;
        private System.Windows.Forms.CheckBox checkBoxCandleStyle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelRate;
    }
}

