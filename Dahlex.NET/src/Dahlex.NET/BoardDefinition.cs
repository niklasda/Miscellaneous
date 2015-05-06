using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dahlex
{
    public class BoardDefinition
    {
        private Size boardSize;
        private Size squareSize;

        public Size BoardSize
        {
            get { return boardSize; }
        }

        public Size SquareSize
        {
            get { return squareSize; }
        }

        public BoardDefinition(Size pBoardSize, Size pSquareSize)
        {
            boardSize = pBoardSize;
            squareSize = pSquareSize;
        }
        
        public override string ToString()
        {
            return boardSize.Height +"x"+ boardSize.Width;
        }
    }
}
