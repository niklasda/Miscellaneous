
namespace Dahlex.Logic
{
    public enum Sound { Bomb, Teleport, Crash, Win, Loose };

    public enum PieceType { None, Heap, Professor, Robot };

    public enum MoveDirection { Ignore, None, North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest };

    public enum GameStatus { None, LevelOngoing, LevelComplete, Won, Lost, Full };

    public enum FileExtensionGroup { Theme, Image };

    /// <summary>
    /// Our own Intger base size
    /// </summary>
    public class IntSize
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary>
        /// Construct using width, height
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public IntSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    /// <summary>
    /// Our own Integer based point
    /// </summary>
    public struct IntPoint
    {
        public int X;
        public int Y;

        /// <summary>
        /// Construct using x, y
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public IntPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public new string ToString()
        {
            return string.Format("X:{0}, Y:{1}", X, Y);
        }
    }
}