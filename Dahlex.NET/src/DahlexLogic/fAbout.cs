using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Dahlex
{
    public partial class fAbout : Form
    {
        private fAbout()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lAppName.Text = Application.ProductName +" v"+ Application.ProductVersion;
            lVersion.Text = Application.ProductVersion;
            lWindowsVersion.Text = Environment.OSVersion.ToString();
            lUser.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            lFxVersion.Text = Environment.Version.ToString();

            if (Attribute.IsDefined(GetType().Assembly, typeof(AssemblyCopyrightAttribute)))
            {
                AssemblyCopyrightAttribute adAttr = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(GetType().Assembly, typeof(AssemblyCopyrightAttribute));
                lAppCopyright.Text = adAttr.Copyright;
            }
            if (Attribute.IsDefined(GetType().Assembly, typeof(AssemblyConfigurationAttribute)))
            {
                AssemblyConfigurationAttribute adAttr = (AssemblyConfigurationAttribute)Attribute.GetCustomAttribute(GetType().Assembly, typeof(AssemblyConfigurationAttribute));
                lAppName.Text += " " + adAttr.Configuration;
            }

            FileInfo fi = new FileInfo(GetType().Assembly.Location);
            lVersion.Text = fi.CreationTime.ToShortDateString();
        }
        
        private static fAbout about = new fAbout();
        public static void ShowMe()
        {
            if (!about.Visible)
            {
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            about.Hide();
        }
    }
}