
using System;
using System.Drawing;
using System.Windows.Forms;
using Dahlex.Settings;
using Dahlex.Theming;

namespace Dahlex
{
    [CLSCompliant(true)]
    public interface IDahlexView
    {
        void AddLineToLog(string log);
        void DrawGrid(int width, int height, int xSize, int ySize, ThemeBoard board);
        void DrawBoard(IBoard board, int xSize, int ySize);
        void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount, int maxLevel);
        Graphics GetGraphics();
        Control GetControlAt(Point p);
        void Clear();
        Options GameOptions {get;}
        void SetBoardSizeControls();
        
    }
}
