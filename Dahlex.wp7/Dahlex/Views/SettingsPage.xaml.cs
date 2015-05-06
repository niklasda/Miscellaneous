using System;
using System.Windows;
using Dahlex.Logic.Settings;
using Microsoft.Phone.Controls;

namespace Dahlex.Views
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            loadSettings();
        }

        private GameSettings _settings = new GameSettings();
        private const string _contentTextOff = "Off";
        private const string _contentTextOn="On";

        private void loadSettings()
        {
            var man = new SettingsManager();
            _settings = man.LoadLocalSettings();

            tsLessSound.IsChecked = _settings.LessSound;
            tsSwipeToMove.IsChecked = _settings.UseSwipesToMove;
            //tsBombToHeap.IsChecked = _settings.BombToHeap;
            if (!string.IsNullOrEmpty(_settings.PlayerName))
            {
                txtPlayerName.Text = _settings.PlayerName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tsLessSound.IsChecked.HasValue)
            {
                _settings.LessSound = tsLessSound.IsChecked.Value;
            }

            if (tsSwipeToMove.IsChecked.HasValue)
            {
                _settings.UseSwipesToMove = tsSwipeToMove.IsChecked.Value;
            }

            _settings.BombToHeap = false;

            _settings.PlayerName = txtPlayerName.Text;

            var man = new SettingsManager();
            man.SaveLocalSettings(_settings);

            NavigationService.GoBack();
        }

        private void tsLessSound_Checked(object sender, RoutedEventArgs e)
        {
            tsLessSound.Content = _contentTextOn;
        }

        private void tsToxicHeaps_Unchecked(object sender, RoutedEventArgs e)
        {
            tsLessSound.Content = _contentTextOff;
        }

        private void tsSwipes_Checked(object sender, RoutedEventArgs e)
        {
            tsSwipeToMove.Content = _contentTextOn;
        }
        private void tsSwipes_Unchecked(object sender, RoutedEventArgs e)
        {
            tsSwipeToMove.Content = _contentTextOff;
        }
    }
}