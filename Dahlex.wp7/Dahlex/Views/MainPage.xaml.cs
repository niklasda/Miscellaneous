using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Dahlex.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            var theUri = new Uri("/Views/GamePage.xaml", UriKind.Relative);
            NavigationService.Navigate(theUri);
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {
            var theUri = new Uri("/Views/SettingsPage.xaml", UriKind.Relative);
            NavigationService.Navigate(theUri);
        }

        private void buttonScores_Click(object sender, RoutedEventArgs e)
        {
            var theUri = new Uri("/Views/ScoresPage.xaml", UriKind.Relative);
            NavigationService.Navigate(theUri);
        } 
        
        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            var theUri = new Uri("/Views/AboutPage.xaml", UriKind.Relative);
            NavigationService.Navigate(theUri);
        }

        private void buttonHow_Click(object sender, RoutedEventArgs e)
        {
            var theUri = new Uri("/Views/HowPage.xaml", UriKind.Relative);
            NavigationService.Navigate(theUri);
        }
    }
}