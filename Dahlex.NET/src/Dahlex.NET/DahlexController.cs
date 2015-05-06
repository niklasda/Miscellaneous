using System;
using System.Drawing;
using System.IO;
using Dahlex.Animation;
using Dahlex.HighScores;
using Dahlex.Settings;
using Dahlex.Theming;

namespace Dahlex
{
    public sealed class DahlexController
    {
        private IDahlexView boardView;
        private Size boardSize;
        private Size squareSize;
        private DateTime startTime;
        private IBoard board;
        private GameStatus gameStatus;
        private int level;
        private int maxLevel;
        private int bombCount;
        private int teleportCount;
        private int robotCount;
        private int moveCount;
        private Options gameOptions;
        private Theme gameTheme;
        private AnimationManager aniMan = new AnimationManager();

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public GameStatus Status
        {
            get { return gameStatus; }
        }

        public DahlexController(IDahlexView view, BoardDefinition boardDef, Options options, Theme theme)
        {
            boardView = view;
            boardSize = boardDef.BoardSize;
            squareSize = boardDef.SquareSize;
            gameOptions = options;
            gameTheme = theme;
            maxLevel = (boardSize.Height*boardSize.Height)/4;
            
            board = new BoardJagged(boardSize);

            startTime = DateTime.Now;
            gameStatus = GameStatus.None;
        }

        private Point getFreePosition()
        {
            Point p;
            do
            {
                p = Randomizer.GetRandomPosition(boardSize.Width, boardSize.Height);
            } while (board.GetPosition(p.X, p.Y) != null);

            return new Point(p.X, p.Y);
        }

        public void StartGame()
        {
            gameStatus = GameStatus.LevelOngoing;

            level = gameOptions.StartLevel;
            bombCount = gameOptions.StartBombs-1;
            teleportCount = gameOptions.StartTeleports-1;
            createProfessor();
            initLevel(level, false);
        }

        public void NextLevel()
        {
            if (level == (boardSize.Height*boardSize.Height)/4)
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

            if (!empty)
            {
                createRobots(robotCount);
                createHeaps(thisLevel);
            }
            Redraw();
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


        internal void Redraw()
        {
            ThemeBoard themeBoard = gameTheme.GetLevelBoard(level);
            //          ThemeBoard themeBoard = getBoard(gameTheme, level);
            boardView.Clear();

            boardView.DrawGrid(boardSize.Width, boardSize.Height, squareSize.Width, squareSize.Height, themeBoard.LineWidth, themeBoard.LineColor, themeBoard.BackgroundImage);
            boardView.DrawBoard(board, squareSize.Width, squareSize.Height);
            
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
                if ((oldProfessorPosition.X + 1) < boardSize.Width)
                {
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.South)
            {
                if ((oldProfessorPosition.Y + 1) < boardSize.Height)
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
                if ((oldProfessorPosition.Y) > 0 && (oldProfessorPosition.X + 1) < boardSize.Width)
                {
                    newProfessorPosition.Y--;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthEast)
            {
                if ((oldProfessorPosition.Y + 1) < boardSize.Height && (oldProfessorPosition.X + 1) < boardSize.Width)
                {
                    newProfessorPosition.Y++;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthWest)
            {
                if ((oldProfessorPosition.Y + 1) < boardSize.Height && (oldProfessorPosition.X) > 0)
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

            AnimationMove move = null;
            
            if (newBp == null)
            {
                board.SetTempPosition(newPosition.X, newPosition.Y, oldBp);
       
                boardView.AddLineToLog("move " + oldBp.Type + " to " + newPosition.ToString());
                move = new AnimationMove(oldPosition, newPosition, oldBp.Type, oldBp.Type);
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Robot)
            {
                boardView.AddLineToLog("Robot-robot collision on " + newPosition.ToString());
                move = new AnimationMove(oldPosition, newPosition, PieceType.Robot, PieceType.Heap);

                newBp.ConvertToHeap();
                robotCount -= 2;
                if(robotCount==0)
                {
                    gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Heap)
            {
                boardView.AddLineToLog("Robot-heap collision on " + newPosition.ToString());
                move = new AnimationMove(oldPosition, newPosition, PieceType.Robot, PieceType.Heap);

                newBp.ConvertToHeap();
                robotCount--;
                if (robotCount == 0)
                {
                    gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp != null && newBp.Type == PieceType.Professor)
            {
                boardView.AddLineToLog("Robot killed professor on " + newPosition.ToString());
                move = new AnimationMove(oldPosition, newPosition, PieceType.Robot, PieceType.Heap);

                newBp.ConvertToHeap();
                gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp != null && newBp.Type == PieceType.Robot)
            {
                boardView.AddLineToLog("Professor hit robot on " + newPosition.ToString());
                move = new AnimationMove(oldPosition, newPosition, PieceType.Professor, PieceType.Heap);

                newBp.ConvertToHeap();
                gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp != null && newBp.Type == PieceType.Heap)
            {
                if (gameOptions.ToxicHeaps)
                {
                    boardView.AddLineToLog("Professor went into heap on " + newPosition.ToString());
                    move = new AnimationMove(oldPosition, newPosition, PieceType.Professor, PieceType.Heap);

                    newBp.ConvertToHeap();
                    gameStatus = GameStatus.Lost;
                    AddHighScore();
                }
                else
                {
                    boardView.AddLineToLog("Professor blocked by heap on " + newPosition.ToString());
                    move = new AnimationMove(oldPosition, oldPosition, PieceType.Professor, PieceType.Professor);

                    board.SetTempPosition(oldPosition.X, oldPosition.Y, board.GetPosition(oldPosition.X, oldPosition.Y));
                }
            }
            aniMan.Push(move);
            
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

        internal bool BlowBomb()
        {
            int robotCountBefore = robotCount;
            
            if (bombCount > 0)
            {
                Point prof = getProfessor(false);

                for (int x = Math.Max(prof.X - 1, 0); x <= Math.Min(prof.X + 1, boardSize.Width - 1); x++)
                {
                    for (int y = Math.Max(prof.Y - 1, 0); y <= Math.Min(prof.Y + 1, boardSize.Height - 1); y++)
                    {
                        if (board.GetPosition(x, y) != null)
                        {
                            BoardPosition cp = board.GetPosition(x, y);

                            if (cp.Type == PieceType.Robot)
                            {
                                if(gameOptions.BombToHeap)
                                {
                                    board.SetTempPosition(x, y, cp);
                                    cp.ConvertToHeap();
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

        internal bool DoTeleport()
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
            
     //       BoardPosition pPos = BoardPosition.CreateProfessorBoardPosition();
       //     positions[profPos.X, profPos.Y] = pPos;  
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
            aniMan.Clear();
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
            aniMan.Animate(boardView);
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
         //   Options opt = new Options();
            HighScoreManager man = new HighScoreManager(gameOptions);
            
            man.AddHighScore(level, level, bombCount, teleportCount, moveCount, startTime, boardSize);
            man.SaveLocalHighScores();
        }
    }
}
