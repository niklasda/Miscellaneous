using System.Drawing;

namespace Dahlex
{
    public sealed class BoardJagged : IBoard
    {
        private BoardPosition[][] positions;
        private BoardPosition[][] tempPositions;
        
        private Size boardSize;

        public BoardJagged(Size pBoardSize)
        {
            boardSize = pBoardSize;
            
            positions = new BoardPosition[boardSize.Width][];
            tempPositions = new BoardPosition[boardSize.Width][];

            for (int x = 0; x < boardSize.Width; x++)
            {
                positions[x] = new BoardPosition[boardSize.Height];
            }
            for (int tempx = 0; tempx < boardSize.Width; tempx++)
            {
                tempPositions[tempx] = new BoardPosition[boardSize.Height];
            }
        }

        public BoardPosition GetPosition(int x, int y)
        {
            return positions[x][y];
        }
        public void SetPosition(int x, int y, BoardPosition pos)
        {
            positions[x][y] = pos;
        }
        public void ResetPosition(int x, int y)
        {
            positions[x][y] = null;
        }
        public int GetPositionHeight()
        {
            return boardSize.Height;
        }
        public int GetPositionWidth()
        {
            return boardSize.Width;
        }
        public Point GetProfessor()
        {
            return getProfessor(positions);            
        }

        public BoardPosition GetTempPosition(int x, int y)
        {
            return tempPositions[x][y];
        }
        public void SetTempPosition(int x, int y, BoardPosition pos)
        {
            tempPositions[x][y] = pos;
        }
        public void ResetTempPosition(int x, int y)
        {
            tempPositions[x][y] = null;
        }
        public Point GetProfessorFromTemp()
        {
            return getProfessor(tempPositions);
        }


        private Point getProfessor(BoardPosition[][] bps)
        {
            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    if (bps[x][y] != null)
                    {
                        BoardPosition cp = bps[x][y];

                        if (cp.Type == PieceType.Professor)
                        {
                            return new Point(x, y);
                        }
                    }
                }
            }

            return Point.Empty;
        }
    }
}
