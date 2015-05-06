
using System.Drawing;

namespace Dahlex
{
    //public interface IDahlexView2
    //{
    //    void AddLineToLog(string log);
    //    void DrawGrid(int width, int height, int xSize, int ySize);
    //    void DrawBoard(BoardPosition[,] positions, int xSize, int ySize);
    //    void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount);
    //    void Clear();
    //}

    public interface IDahlexView
    {
        void AddLineToLog(string log);
        void DrawGrid(int width, int height, int xSize, int ySize, int lineWidth, Color lineColor, Image bgImage);
        void DrawBoard(IBoard board, int xSize, int ySize);
        void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount, int maxLevel);
        Graphics GetGraphics();
        void Clear();
    }
}
