using System;
using System.Drawing;
using Dahlex.HighScores;
using Dahlex.Theming;

namespace Dahlex
{
    public sealed class DahlexController
    {
        private IDahlexView boardView;
        private DateTime startTime;
        private IBoard board;
        private GameStatus gameStatus;
        private int level;
        private int maxLevel;
        private int bombCount;
        private int teleportCount;
        private int robotCount;
        private int moveCount;
        private Theme gameTheme;

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public GameStatus Status
        {
            get { return gameStatus; }
        }

        public DahlexController(IDahlexView view, Theme theme)
        {
            boardView = view;
            
            gameTheme = theme;

            startTime = DateTime.Now;
            gameStatus = GameStatus.None;
        }

        private Point getFreePosition()
        {
            Point p;
            do
            {
                p = Randomizer.GetRandomPosition(boardView.GameOptions.BoardSize.Width, boardView.GameOptions.BoardSize.Height);
            } while (board.GetPosition(p.X, p.Y) != null);

            return new Point(p.X, p.Y);
        }

        public void StartGame()
        {
            gameStatus = GameStatus.LevelOngoing;

            level = boardView.GameOptions.StartLevel;
            bombCount = boardView.GameOptions.StartBombs - 1;
            teleportCount = boardView.GameOptions.StartTeleports - 1;

            initLevel(level, false);
        }

        public void NextLevel()
        {
            if (level == maxLevel)
            {
                gameStatus = GameStatus.Won;
            }
            else
            {
                gameStatus = GameStatus.LevelOngoing;
                level++;

                initLevel(level, false);
            }
        }
        
        private void initLevel(int thisLevel, bool empty)
        {
            bombCount++;
            teleportCount++;
            robotCount = thisLevel + 1;

            ThemeBoard themeBoard;
            if (gameTheme != null)
            {
                themeBoard = gameTheme.GetLevelBoard(level);
                setBoardSizeFromTheme(themeBoard);
            }

            board = new BoardJagged(boardView.GameOptions.BoardSize);
            maxLevel = (boardView.GameOptions.BoardSize.Width * boardView.GameOptions.BoardSize.Height) / 4;
            
            if (!empty)
            {
                createProfessor();
                createRobots(robotCount);
                createHeaps(thisLevel);
            }
            Redraw();
        }

        private void setBoardSizeFromTheme(ThemeBoard themeBoard)
        {
            
                if (themeBoard != null)
                {
                    if (themeBoard.StaticLevel!=null)
                    {
                        boardView.GameOptions.BoardSize = themeBoard.StaticLevel.GetSize();
                    }
                    else
                    {
                        boardView.GameOptions.BoardSize = new Size(gameTheme.BoardWidth, gameTheme.BoardWidth);                        
                    }
                    boardView.SetBoardSizeControls();
                }
                //gameOptions.BoardSize = new Size(currentTheme.BoardWidth, currentTheme.BoardHeight);
           // }
            //          ThemeBoard themeBoard = getBoard(gameTheme, level);
        }

        private void createHeaps(int count)
        {
            removeOldPieces(PieceType.Heap);
            for (int i = 0; i < count; i++)
            {
                Point robotPos = getFreePosition();
                BoardPosition rPos = BoardPosition.CreateHeapBoardPosition();
                board.SetPosition(robotPos.X, robotPos.Y, rPos);
            }
        }

        private void removeOldPieces(PieceType typeToRemove)
        {
            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    if (board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = board.GetPosition(x, y);

                        if (cp.Type == typeToRemove)
                        {
                            board.ResetPosition(x, y);;
                        }
                    }
                }
            }
        }

        private void createProfessor()
        {
            Point profPos = getFreePosition();
            BoardPosition pPos = BoardPosition.CreateProfessorBoardPosition();
            board.SetPosition(profPos.X, profPos.Y, pPos);
        }

        private void createRobots(int count)
        {
            removeOldPieces(PieceType.Heap);
            for (int i = 0; i < count; i++)
            {
                Point robotPos = getFreePosition();
                BoardPosition rPos = BoardPosition.CreateRobotBoardPosition();
                board.SetPosition(robotPos.X, robotPos.Y, rPos);
            }
        }

        public void Redraw()
        {
            ThemeBoard themeBoard = null;
            if (gameTheme != null)
            {
                themeBoard = gameTheme.GetLevelBoard(level);
                setBoardSizeFromTheme(themeBoard);
            }

            boardView.Clear();

            boardView.DrawGrid(boardView.GameOptions.BoardSize.Width, boardView.GameOptions.BoardSize.Height, boardView.GameOptions.SquareSize.Width, boardView.GameOptions.SquareSize.Height, themeBoard);
            boardView.DrawBoard(board, boardView.GameOptions.SquareSize.Width, boardView.GameOptions.SquareSize.Height);
            
            boardView.ShowStatus(level, bombCount, teleportCount, robotCount, moveCount, maxLevel);
        }

        public bool MoveProfessorToTemp(MoveDirection dir)
        {
            Point oldProfessorPosition = getProfessor(false);
            Point newProfessorPosition = oldProfessorPosition;

            if (dir == MoveDirection.North)
            {
                if ((oldProfessorPosition.Y) > 0)
                {
                    newProfessorPosition.Y--;
                }
            }
            else if (dir == MoveDirection.East)
            {
                if ((oldProfessorPosition.X + 1) < boardView.GameOptions.BoardSize.Width)
                {
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.South)
            {
                if ((oldProfessorPosition.Y + 1) < boardView.GameOptions.BoardSize.Height)
                {
                    newProfessorPosition.Y++;
                }
            }
            else if (dir == MoveDirection.West)
            {
                if ((oldProfessorPosition.X) > 0)
                {
                    newProfessorPosition.X--;
                }
            }
            else if (dir == MoveDirection.NorthEast)
            {
                if ((oldProfessorPosition.Y) > 0 && (oldProfessorPosition.X + 1) < boardView.GameOptions.BoardSize.Width)
                {
                    newProfessorPosition.Y--;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthEast)
            {
                if ((oldProfessorPosition.Y + 1) < boardView.GameOptions.BoardSize.Height && (oldProfessorPosition.X + 1) < boardView.GameOptions.BoardSize.Width)
                {
                    newProfessorPosition.Y++;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthWest)
            {
                if ((oldProfessorPosition.Y + 1) < boardView.GameOptions.BoardSize.Height && (oldProfessorPosition.X) > 0)
                {
                    newProfessorPosition.Y++;
                    newProfessorPosition.X--;
                }
            }
            else if (dir == MoveDirection.NorthWest)
            {
                if ((oldProfessorPosition.Y) > 0 && (oldProfessorPosition.X) > 0)
                {
                    newProfessorPosition.Y--;
                    newProfessorPosition.X--;
                }
            }
            else if (dir == MoveDirection.None)
            {
            }
            else
            {
                throw new ApplicationException("No direction specified in move");
            }

            if (!oldProfessorPosition.Equals(newProfessorPosition) || (dir == MoveDirection.None))
            {
                moveCharacter(oldProfessorPosition, newProfessorPosition);
                moveCount++;
                return true;
            }

            return false;
        }

        private void moveCharacter(Point oldPosition, Point newPosition)
        {
            BoardPosition oldBp = board.GetPosition(oldPosition.X, oldPosition.Y);
            BoardPosition newBp = board.GetTempPosition(newPosition.X, newPosition.Y);

            if (newBp == null)
            {
                board.SetTempPosition(newPosition.X, newPosition.Y, oldBp);
       
                boardView.AddLineToLog("move " + oldBp.Type + " to " + newPosition.ToString());
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Robot)
            {
                boardView.AddLineToLog("Robot-robot collision on " + newPosition.ToString());

                newBp.ConvertToHeap(null);
                robotCount -= 2;
                if(robotCount==0)
                {
                    gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Heap)
            {
                boardView.AddLineToLog("Robot-heap collision on " + newPosition.ToString());

                newBp.ConvertToHeap(newBp.ImageIndex);
                robotCount--;
                if (robotCount == 0)
                {
                    gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Professor)
            {
                boardView.AddLineToLog("Robot killed professor on " + newPosition.ToString());

                newBp.ConvertToHeap(null);
                gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp != null && newBp.Type == PieceType.Robot)
            {
                boardView.AddLineToLog("Professor hit robot on " + newPosition.ToString());

                newBp.ConvertToHeap(null);
                gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp != null && newBp.Type == PieceType.Heap)
            {
                if (boardView.GameOptions.ToxicHeaps)
                {
                    boardView.AddLineToLog("Professor went into heap on " + newPosition.ToString());

                    newBp.ConvertToHeap(newBp.ImageIndex    );
                    gameStatus = GameStatus.Lost;
                    AddHighScore();
                }
                else
                {
                    boardView.AddLineToLog("Professor blocked by heap on " + newPosition.ToString());

                    board.SetTempPosition(oldPosition.X, oldPosition.Y, board.GetPosition(oldPosition.X, oldPosition.Y));
                }
            }
        }

        private Point getProfessor(bool fromTemp)
        {
            if(fromTemp)
            {
                return board.GetProfessorFromTemp();
            }
            else
            {
                return board.GetProfessor();
            }
        }

        public bool BlowBomb()
        {
            int robotCountBefore = robotCount;
            
            if (bombCount > 0)
            {
                Point prof = getProfessor(false);

                for (int x = Math.Max(prof.X - 1, 0); x <= Math.Min(prof.X + 1, boardView.GameOptions.BoardSize.Width - 1); x++)
                {
                    for (int y = Math.Max(prof.Y - 1, 0); y <= Math.Min(prof.Y + 1, boardView.GameOptions.BoardSize.Height - 1); y++)
                    {
                        if (board.GetPosition(x, y) != null)
                        {
                            BoardPosition cp = board.GetPosition(x, y);

                            if (cp.Type == PieceType.Robot)
                            {
                                if (boardView.GameOptions.BombToHeap)
                                {
                                    board.SetTempPosition(x, y, cp);
                                    cp.ConvertToHeap(null);
                                }
                                else
                                {
                                    board.ResetPosition(x, y);
                                }
                                
                                robotCount--;
                                if (robotCount == 0)
                                {
                                    gameStatus = GameStatus.LevelComplete;
                                }
                            }
                        }
                    }
                }
            }
            
            if (robotCountBefore!=robotCount)
            {
                bombCount--;
                return true;
            }
            
            return false;
        }

        public bool DoTeleport()
        {
            if (teleportCount > 0)
            {
                Point oldProfPos = getProfessor(false);

                Point newProfPos = getFreePosition();

                moveCharacter(oldProfPos, newProfPos);

                teleportCount--;
                return true;
            }
            return false;
        }

        public void MoveRobotsToTemp()
        {
            Point prof = getProfessor(true);

            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    if (board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = board.GetPosition(x, y);
                        Point current = new Point(x, y);

                        if (cp.Type == PieceType.Robot)
                        {
                            Point diff = new Point(Math.Sign(prof.X - current.X), Math.Sign(prof.Y - current.Y));
                            Point newPoint = new Point(current.X + diff.X, current.Y + diff.Y);

                            moveCharacter(current, newPoint);
                        }
                    }
                }
            }
        }

        public void MoveHeapsToTemp()
        {
            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    if (board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = board.GetPosition(x, y);

                        if (cp.Type == PieceType.Heap)
                        {
                            Point point = new Point(x, y);

                            moveCharacter(point, point);
                        }
                    }
                }
            }
        }
         
        public void CommitTemp()
        {
            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    board.SetPosition(x, y, board.GetTempPosition(x, y));
                    board.ResetTempPosition(x, y);
                }
            }
            Redraw();            
        }

        public void AddHighScore()
        {
            HighScoreManager man = new HighScoreManager(boardView.GameOptions);

            man.AddHighScore(level, level, bombCount, teleportCount, moveCount, startTime, boardView.GameOptions.BoardSize);
            man.SaveLocalHighScores();
        }
    }
}
