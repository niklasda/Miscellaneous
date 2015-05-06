using System;
using System.Windows;

namespace Dahlex.Logic
{
    public static class Randomizer
    {
        private static readonly Random _rnd = new Random();
        
        /// <summary>
        /// Returns a random point with 
        /// 0 &lt;= x &lt; xMax and
        /// 0 &lt;= y &lt; yMax
        /// <seealso cref="Point"/>
        /// </summary>
        /// <param name="xMax">upper x bound (not inclusive)</param>
        /// <param name="yMax">upper y bound (not inclusive)</param>
        /// <returns></returns>
        public static IntPoint GetRandomPosition(int xMax, int yMax)
        {
            int x = _rnd.Next(0, xMax);
            int y = _rnd.Next(0, yMax);

            return new IntPoint(x, y);
        }

        public static MoveDirection GetRandomDirection()
        {
            const int max = 9;
            int v = _rnd.Next(1, max);
            switch(v)
            {
                case 1:
                    return MoveDirection.East;
                case 2:
                    return MoveDirection.None;
                case 3:
                    return MoveDirection.North;
                case 4:
                    return MoveDirection.NorthEast;
                case 5:
                    return MoveDirection.NorthWest;
                case 6:
                    return MoveDirection.South;
                case 7:
                    return MoveDirection.SouthEast;
                case 8:
                    return MoveDirection.SouthWest;
                case 9:
                    return MoveDirection.West;
                default:
                    return MoveDirection.None;
            }

        }
    }
}