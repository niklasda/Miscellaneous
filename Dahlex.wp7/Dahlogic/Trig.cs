using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Dahlex.Logic
{
    public static class Trig
    {
        private static readonly int _deltaLimit=5;

        public static bool IsTooSmallSwipe(ManipulationCompletedEventArgs e)
        {
            return Math.Abs(e.TotalManipulation.Translation.X) <= _deltaLimit 
                && Math.Abs( e.TotalManipulation.Translation.Y) <= _deltaLimit;
        }
       
        public static MoveDirection GetSwipeDirection(ManipulationCompletedEventArgs e)
        {
            return IsTooSmallSwipe(e) ? MoveDirection.Ignore : GetTranslationDirection(e.TotalManipulation.Translation.X, e.TotalManipulation.Translation.Y);
        }

        public static MoveDirection GetTranslationDirection(double dx, double dy)
        {

            var angle = Math.Atan2(dy, dx);

            if (-Math.PI / 8 <= angle && angle < Math.PI / 8)
            {
                return MoveDirection.East;
            }
            if (Math.PI / 8 <= angle && angle < 3 * Math.PI / 8)
            {
                return MoveDirection.SouthEast;
            }
            if (3 * Math.PI / 8 <= angle && angle < 5 * Math.PI / 8)
            {
                return MoveDirection.South;
            }
            if (5 * Math.PI / 8 <= angle && angle < 7 * Math.PI / 8)
            {
                return MoveDirection.SouthWest;
            }
            if (7 * Math.PI / 8 <= angle && angle < Math.PI)
            {
                return MoveDirection.West;
            }
            if (-Math.PI<= angle && angle < -7*Math.PI/8)
            {
                return MoveDirection.West;
            }
            if (-7 * Math.PI / 8 <= angle && angle < -5 * Math.PI / 8)
            {
                return MoveDirection.NorthWest;
            }
            if (-5 * Math.PI / 8 <= angle && angle < -3 * Math.PI / 8)
            {
                return MoveDirection.North;
            }
            if (-3 * Math.PI / 8 <= angle && angle < - Math.PI / 8)
            {
                return MoveDirection.NorthEast;
            }

            return MoveDirection.Ignore;
        }

    }
}
