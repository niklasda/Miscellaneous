using System.Collections.Generic;
using System.Windows;
using Dahlex.Logic.HighScores;
using Microsoft.Phone.Controls;

namespace Dahlex.Views
{
    public partial class ScoresPage : PhoneApplicationPage
    {
        public ScoresPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            dataBindHighScores();
        }

        private void dataBindHighScores()
        {
            var man = new HighScoreManager();
            List<HighScore> scores = man.LoadLocalHighScores();

            lstScores.ItemsSource = scores;
            lstScores.DisplayMemberPath = "Content";
        }
    }
}