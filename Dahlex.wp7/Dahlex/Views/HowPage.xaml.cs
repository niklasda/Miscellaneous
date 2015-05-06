using System;
using System.Windows;
using Dahlex.Logic.Logger;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;

namespace Dahlex.Views
{
    public partial class HowPage : PhoneApplicationPage
    {
        public HowPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            lblInstructions.Text = "Turn-based platform game." + Environment.NewLine +
                                   "The robots move straight towards the planet striving to annihilate it." + Environment.NewLine +
                                   "Move the planet so the robots are sucked into black holes (heaps) or collide with each other." +
                                   Environment.NewLine +
                                   "Tap or swipe, depending on your settings, to move the planet." + Environment.NewLine +
                                   "Tap the planet and it will stand still while the robots move towards it." + Environment.NewLine +
                                   "Tap 'Bomb' to blow a bomb, killing all adjecent robots." + Environment.NewLine +
                                   "Tap 'Tele' to teleport the planet, then the robots will move towards it." + Environment.NewLine +
                                   "If 'Bomb' is pressed the planet will not move, but robots will." +
                                   Environment.NewLine +
                                   "" + Environment.NewLine;


        }

    }
}