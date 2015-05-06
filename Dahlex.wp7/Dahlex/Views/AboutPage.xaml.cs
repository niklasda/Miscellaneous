using System;
using System.Windows;
using Dahlex.Logic.Logger;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;

namespace Dahlex.Views
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            long deviceTotalMemory = (long)DeviceExtendedProperties.GetValue("DeviceTotalMemory");
            long applicationCurrentMemoryUsage = (long)DeviceExtendedProperties.GetValue("ApplicationCurrentMemoryUsage");
            long applicationPeakMemoryUsage = (long) DeviceExtendedProperties.GetValue("ApplicationPeakMemoryUsage");

            lblInstructions.Text = "Coded by Niklas Dahlman" + Environment.NewLine +
                "Graphics by Peter Kleine." + Environment.NewLine +
                "Swiping by Erik Chrissopoulos." + Environment.NewLine +
                "Bomb sound by." + Environment.NewLine +
                "Crash sound by." + Environment.NewLine +
                "Teleport sound by." + Environment.NewLine +
                "Background noise by Nordvargr." + Environment.NewLine +
                "" + Environment.NewLine +
                "OS: " + Environment.OSVersion + Environment.NewLine +
                "CLR: " + Environment.Version + Environment.NewLine +
                "Device: " + string.Format("{0:#,#,#} Mb", deviceTotalMemory/1024/1024) +
                " - App: " + string.Format("{0:#,#,#} Mb", applicationCurrentMemoryUsage / 1024 / 1024) + 
                " - Peak: " + string.Format("{0:#,#,#} Mb", applicationPeakMemoryUsage/1024/1024) + Environment.NewLine;
        }

        private void btnShowLog_Click(object sender, RoutedEventArgs e)
        {
            string log = GameLogger.TheLog;
            if(string.IsNullOrEmpty(log.Trim()))
            {
                log = "no log yet!";
            }

            MessageBox.Show(log, "Dahlex log", MessageBoxButton.OK);
        }

        private void btnHomepage_Click(object sender, RoutedEventArgs e)
        {
            var task = new WebBrowserTask();
            task.URL = "http://nida.se";
            task.Show();
        }
    }
}