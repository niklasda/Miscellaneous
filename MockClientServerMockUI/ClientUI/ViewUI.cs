using System;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;

namespace Mockdemo.ClientUI
{
    public partial class ViewUI : Form, IViewUI
    {
        public ViewUI()
        {
            InitializeComponent();
        }

        private void bGet_Click(object sender, EventArgs e)
        {
            VersionManager ctrl = new VersionManager(true);
            ctrl.PrintVersionNumber(this);
        }

        private void bDraw_Click(object sender, EventArgs e)
        {
            UiRenderer uir = new UiRenderer();
            uir.DrawString(this, "Demo", Color.Blue, 2, 2);
        }


                
        
        // included as bad example
        private Graphics GetTextBoxGraphics()
        {
            if(Visible)
            {
                return tbVersion.CreateGraphics();
            }
            else
            {
                return null;
            }
        }


        public void AppendToTextBox(double d)
        {
            tbVersion.AppendText(d.ToString());
        }

        public void AppendToTextBox(string s)
        {
            tbVersion.AppendText(s);
        }
        
        public void DrawInTextBox(string p, Font f, Color color, int px, int py)
        {
            using (Graphics g = GetTextBoxGraphics())
            {
                g.DrawString("Demo", f, new SolidBrush(color), new PointF(px, py));
            }
        }        
    

        
        
        
        
        private void tbVersion_TextChanged(object sender, EventArgs e)
        {
            TextBox me = (TextBox)sender;
            int length = me.Text.Length;

            FontManager fm = new FontManager();
            Font f = fm.GetFont(length);

            Graphics g = tbVersion.CreateGraphics();
            g.DrawString("Demo", f, new SolidBrush(Color.Blue), new PointF(2.0f, 2.0f));
        }

        // just a dummy, dont use
        public void PrintVersionNumber(string ver)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

    }
}