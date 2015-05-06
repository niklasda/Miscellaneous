using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dahlex.Theming
{
    public class ThemeLevel
    {
        private int level;
        private Size size;
        IBoard board;
        
        public ThemeLevel(int level)
        {
            this.level = level;
        }

        public void SetCell(int row, int col, PieceType type)
        {
            BoardPosition pos = new BoardPosition(type);
            board.SetPosition(col-1, row-1, pos);
        }

        public void SetSize(int width, int height)
        {
            size = new Size(width, height);
            board = new BoardMatrix(size);
        }
    }
}
