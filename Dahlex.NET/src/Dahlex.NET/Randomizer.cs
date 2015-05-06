using System;
using System.Drawing;

namespace Dahlex
{
    public static class Randomizer
    {
        static Random rnd = new Random();
        
        /// <summary>
        /// Returns a random point with 
        /// 0 &lt;= x &lt; xMax and
        /// 0 &lt;= y &lt; yMax
        /// <seealso cref="Point"/>
        /// </summary>
        /// <param name="xMax">upper x bound (not inclusive)</param>
        /// <param name="yMax">upper y bound (not inclusive)</param>
        /// <returns></returns>
        public static Point GetRandomPosition(int xMax, int yMax)
        {
            int x = rnd.Next(0, xMax);
            int y = rnd.Next(0, yMax);

            return new Point(x, y);
        }

        public static MoveDirection GetRandomDirection()
        {
            Array values = Enum.GetValues(typeof (MoveDirection));
            int max = values.Length;
            int v = rnd.Next(1, max);
            object o = values.GetValue(v);
            MoveDirection dir = (MoveDirection)o;

            return dir;
        }
    }
}
