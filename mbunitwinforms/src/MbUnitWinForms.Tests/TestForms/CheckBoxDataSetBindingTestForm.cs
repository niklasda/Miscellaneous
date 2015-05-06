#region Copyright (c) 2003-2005, Luke T. Maxon

/********************************************************************************************************************
'
' Copyright (c) 2003-2005, Luke T. Maxon
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, are permitted provided
' that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this list of conditions and the
' 	following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
' 	the following disclaimer in the documentation and/or other materials provided with the distribution.
' 
' * Neither the name of the author nor the names of its contributors may be used to endorse or 
' 	promote products derived from this software without specific prior written permission.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
' IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'*******************************************************************************************************************/

#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MbUnitWinForms.Tests
{
    /// <summary>
    /// Summary description for CheckBoxDataSetBindingTestForm.
    /// </summary>
    public class CheckBoxDataSetBindingTestForm : Form
    {
        private Button btnView;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private CheckBox myCheckBox;
        private DataSet myDataSet;

        public CheckBoxDataSetBindingTestForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void CheckBoxDataSetBindingTestForm_Load(object sender, EventArgs e)
        {
            myDataSet.Tables.Add("TableName");
            myDataSet.Tables[0].Columns.Add("ColumnName");
            DataRow row = myDataSet.Tables[0].NewRow();
            myDataSet.Tables[0].Rows.Add(row);
            myDataSet.Tables[0].Rows[0]["ColumnName"] = "False";

            myCheckBox.DataBindings.Add(new Binding("Checked", myDataSet, "TableName.ColumnName"));
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myDataSet.Tables[0].Rows[0].ItemArray[0].ToString(), myCheckBox.Checked.ToString());
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myCheckBox = new CheckBox();
            this.btnView = new Button();
            this.myDataSet = new DataSet();
            ((ISupportInitialize) (this.myDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // myCheckBox
            // 
            this.myCheckBox.Location = new Point(64, 64);
            this.myCheckBox.Name = "myCheckBox";
            this.myCheckBox.TabIndex = 0;
            this.myCheckBox.Text = "";
            // 
            // btnView
            // 
            this.btnView.Location = new Point(72, 136);
            this.btnView.Name = "btnView";
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View Dataset Value";
            this.btnView.Click += new EventHandler(this.btnView_Click);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "NewDataSet";
            this.myDataSet.Locale = new CultureInfo("en-US");
            // 
            // CheckBoxDataSetBindingTestForm
            // 
            this.AutoScaleDimensions = new SizeF(5, 13);
            this.ClientSize = new Size(292, 273);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.myCheckBox);
            this.Name = "CheckBoxDataSetBindingTestForm";
            this.Text = "CheckBoxDataSetBindingTestForm";
            this.Load += new EventHandler(this.CheckBoxDataSetBindingTestForm_Load);
            ((ISupportInitialize) (this.myDataSet)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}