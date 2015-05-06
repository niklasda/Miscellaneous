
namespace Dahlex.Logic
{
    public sealed class BoardMatrix : IBoard
    {
        private readonly BoardPosition[,] _positions;
        private readonly BoardPosition[,] _tempPositions;

        private readonly IntSize _boardSize;

        public BoardMatrix(IntSize pBoardSize)
        {
            _boardSize = pBoardSize;
            
            _positions = new BoardPosition[_boardSize.Width, _boardSize.Height];
            _tempPositions = new BoardPosition[_boardSize.Width, _boardSize.Height];
        }

        public BoardPosition GetPosition(int x, int y)
        {
            return _positions[x, y];
        }
        public void SetPosition(int x, int y, BoardPosition pos)
        {
            _positions[x, y] = pos;
        }
        public void ResetPosition(int x, int y)
        {
            _positions[x, y] = null;
        }
        public int GetPositionHeight()
        {
            return _boardSize.Height;
        }
        public int GetPositionWidth()
        {
            return _boardSize.Width;
        }
        public IntPoint GetProfessor()
        {
            return getProfessor(_positions);            
        }

        public BoardPosition GetTempPosition(int x, int y)
        {
            return _tempPositions[x, y];
        }
        public void SetTempPosition(int x, int y, BoardPosition pos)
        {
            _tempPositions[x, y] = pos;
        }
        public void ResetTempPosition(int x, int y)
        {
            _tempPositions[x, y] = null;
        }
        public IntPoint GetProfessorFromTemp()
        {
            return getProfessor(_tempPositions);
        }

        private IntPoint getProfessor(BoardPosition[,] bps)
        {
            for (int x = 0; x < _boardSize.Width; x++)
            {
                for (int y = 0; y < _boardSize.Height; y++)
                {
                    if (bps[x,y] != null)
                    {
                        BoardPosition cp = bps[x,y];

                        if (cp.Type == PieceType.Professor)
                        {
                            return new IntPoint(x, y);
                        }
                    }
                }
            }

            return new IntPoint(-1, -1);
        }
    }
}