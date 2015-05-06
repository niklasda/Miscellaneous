using System;
using Dahlex.Logic.HighScores;
using Dahlex.Logic.Settings;

/*
 * TODO local highscore in isolated storag
 * TODO make page resizable so it can run on a phone
 * TODO check if silverlight will be in windows mobile 7
 * TODO serialization of highscores
 * TODO cleanup animations and images, and fix the leak, 3-way collision or bombing
 * IDEA save professor location and heaps (not generating new ones) to next level
 * */

namespace Dahlex.Logic
{
    public class GameController
    {
        private readonly IDahlexView _boardView;
        private GameSettings _settings;

        private GameStatus _gameStatus;
        private int _level;
        private int _bombCount;
        private int _teleportCount;
        private int _robotCount;
        private int _moveCount;

        private IntSize _boardSize; // number of squares
        private IntSize _squareSize;  // in pixels
        private IBoard _board;
        private int _maxLevel;
        private bool _lessSound;
        private bool _bombToHeap;
        private DateTime _startTime;

        public GameController(IDahlexView view)
        {
            _boardView = view;
          //  _settings = settings;
        }

        public GameStatus Status
        {
            get { return _gameStatus; }
        }

        public void StartGame(GameSettings settings)
        {
            _settings = settings;
            _startTime = DateTime.Now;
            _gameStatus = GameStatus.LevelOngoing;

            _level = 1;
            _bombCount = 0;
            _teleportCount = 0;

            _boardSize = _settings.BoardSize;// new IntSize(16, 18); // w, h
            _squareSize = _settings.SquareSize; // new IntSize(28, 28);
            _lessSound = _settings.LessSound;
            _bombToHeap = _settings.BombToHeap;

            initLevel(_level, false);
        }

        public void StartNextLevel()
        {
            if (_level == _maxLevel)
            {
                _gameStatus = GameStatus.Won;
            }
            else
            {
                _gameStatus = GameStatus.LevelOngoing;
                _level++;

                initLevel(_level, false);
            }
        }

        private void initLevel(int thisLevel, bool empty)
        {
            _bombCount++;
            _teleportCount++;
            _robotCount = thisLevel + 1;


            _board = new BoardMatrix(_boardSize);
            _maxLevel = (_boardSize.Width * _boardSize.Height) / 4;

            if (!empty)
            {
                createProfessor();
                createRobots(_robotCount);
                createHeaps(thisLevel);
            }
            Redraw(true);
        }

        private void createProfessor()
        {
            IntPoint profPos = getFreePosition();
            BoardPosition pPos = BoardPosition.CreateProfessorBoardPosition();
            _board.SetPosition(profPos.X, profPos.Y, pPos);
        }

        private void createRobots(int count)
        {
            removeOldPieces(PieceType.Heap);  // todo why, and why heaps
            for (int i = 0; i < count; i++)
            {
                IntPoint robotPos = getFreePosition();
                BoardPosition rPos = BoardPosition.CreateRobotBoardPosition(i);
                _board.SetPosition(robotPos.X, robotPos.Y, rPos);
            }
        }

        private void createHeaps(int count)
        {
            removeOldPieces(PieceType.Heap); // todo why
            for (int i = 0; i < count; i++)
            {
                IntPoint robotPos = getFreePosition();
                BoardPosition rPos = BoardPosition.CreateHeapBoardPosition(i);
                _board.SetPosition(robotPos.X, robotPos.Y, rPos);
            }
        }

        private void removeOldPieces(PieceType typeToRemove)
        {
            for (int x = 0; x < _board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < _board.GetPositionHeight(); y++)
                {
                    if (_board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = _board.GetPosition(x, y);

                        if (cp.Type == typeToRemove)
                        {
                            _board.ResetPosition(x, y); ;
                        }
                    }
                }
            }
        }

        private IntPoint getFreePosition()
        {
            IntPoint p;
            do
            {
                p = Randomizer.GetRandomPosition(_boardSize.Width, _boardSize.Height);
            }
            while (_board.GetPosition(p.X, p.Y) != null);

            return new IntPoint(p.X, p.Y);
        }

        public void MoveHeapsToTemp()
        {
            for (int x = 0; x < _board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < _board.GetPositionHeight(); y++)
                {
                    if (_board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = _board.GetPosition(x, y);

                        if (cp.Type == PieceType.Heap)
                        {
                            IntPoint point = new IntPoint(x, y);

                            moveCharacter(point, point);
                        }
                    }
                }
            }

        }

        private void moveCharacter(IntPoint oldPosition, IntPoint newPosition)
        {
            BoardPosition oldBp = _board.GetPosition(oldPosition.X, oldPosition.Y);
            BoardPosition newBp = _board.GetTempPosition(newPosition.X, newPosition.Y);

            if (newBp == null || newBp.Type == PieceType.None)
            {
                _board.SetTempPosition(newPosition.X, newPosition.Y, oldBp);
                _boardView.Animate(oldBp, oldPosition, newPosition, false);
                _boardView.AddLineToLog("M. " + oldBp.Type + " to " + newPosition.ToString());
            }
            else if (oldBp.Type == PieceType.Robot && newBp.Type == PieceType.Robot)
            {
                _boardView.AddLineToLog("Robot-robot collision on " + newPosition.ToString());
                _boardView.Animate(oldBp, oldPosition, newPosition, true);
                _boardView.Animate(newBp, newPosition, newPosition, true);
                //       _boardView.RemoveAnimate(oldBp);
                //         _boardView.RemoveAnimate(newBp);

                _boardView.PlaySound(Sound.Crash);

                newBp.ConvertToHeap();
                _robotCount -= 2;
                if (_robotCount == 0)
                {
                    _gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp.Type == PieceType.Heap)
            {
                _boardView.AddLineToLog("Robot-heap collision on " + newPosition.ToString());
                _boardView.Animate(oldBp, oldPosition, newPosition, true);
                //     _boardView.RemoveAnimate(oldBp);
                //var root = (PhoneApplicationFrame)Application.Current.RootVisual;
                //var dependencyObject = root.Parent;
               
                _boardView.PlaySound(Sound.Crash);

                newBp.ConvertToHeap();
                _robotCount--;
                if (_robotCount == 0)
                {
                    _gameStatus = GameStatus.LevelComplete;
                }
            }
            else if (oldBp.Type == PieceType.Robot && newBp.Type == PieceType.Professor)
            {
                _boardView.AddLineToLog("Robot killed professor on " + newPosition.ToString());
                _boardView.Animate(oldBp, oldPosition, newPosition, true);

                _boardView.PlaySound(Sound.Crash);

                newBp.ConvertToHeap();
                _gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp.Type == PieceType.Robot)
            {
                _boardView.AddLineToLog("Professor hit robot on " + newPosition.ToString());
                _boardView.Animate(oldBp, oldPosition, newPosition, true);

                _boardView.PlaySound(Sound.Crash);

                newBp.ConvertToHeap();
                _gameStatus = GameStatus.Lost;
                AddHighScore();
            }
            else if (oldBp.Type == PieceType.Professor && newBp.Type == PieceType.Heap)
            {
                /*if (_toxicHeaps)
                {
                    _boardView.AddLineToLog("Professor went into heap on " + newPosition.ToString());
                    _boardView.Animate(oldBp, oldPosition, newPosition, true);

                    _boardView.PlaySound(Sound.Crash);

                    newBp.ConvertToHeap();
                    _gameStatus = GameStatus.Lost;
                    AddHighScore();
                }
                else
                {*/
                    _boardView.AddLineToLog("Professor blocked by heap on " + newPosition.ToString());

                    _board.SetTempPosition(oldPosition.X, oldPosition.Y, _board.GetPosition(oldPosition.X, oldPosition.Y));
                /*}*/
            }
        }

        private IntPoint getProfessor(bool fromTemp)
        {
            if (fromTemp)
            {
                return _board.GetProfessorFromTemp();
            }
            else
            {
                return _board.GetProfessor();
            }
        }

        public bool MoveProfessorToTemp(MoveDirection dir)
        {
            IntPoint oldProfessorPosition = getProfessor(false);
            IntPoint newProfessorPosition = oldProfessorPosition;

            if (dir == MoveDirection.North)
            {
                if ((oldProfessorPosition.Y) > 0)
                {
                    newProfessorPosition.Y--;
                }
            }
            else if (dir == MoveDirection.East)
            {
                if ((oldProfessorPosition.X + 1) < _boardSize.Width)
                {
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.South)
            {
                if ((oldProfessorPosition.Y + 1) < _boardSize.Height)
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
                if ((oldProfessorPosition.Y) > 0 && (oldProfessorPosition.X + 1) < _boardSize.Width)
                {
                    newProfessorPosition.Y--;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthEast)
            {
                if ((oldProfessorPosition.Y + 1) < _boardSize.Height && (oldProfessorPosition.X + 1) < _boardSize.Width)
                {
                    newProfessorPosition.Y++;
                    newProfessorPosition.X++;
                }
            }
            else if (dir == MoveDirection.SouthWest)
            {
                if ((oldProfessorPosition.Y + 1) < _boardSize.Height && (oldProfessorPosition.X) > 0)
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
                throw new Exception("No direction specified in move");
            }

            if (!oldProfessorPosition.Equals(newProfessorPosition) || (dir == MoveDirection.None))
            {
                moveCharacter(oldProfessorPosition, newProfessorPosition);
                _moveCount++;
                return true;
            }

            return false;
        }

        public void MoveRobotsToTemp()
        {
            IntPoint prof = getProfessor(true);

            for (int x = 0; x < _board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < _board.GetPositionHeight(); y++)
                {
                    if (_board.GetPosition(x, y) != null)
                    {
                        BoardPosition cp = _board.GetPosition(x, y);
                        IntPoint current = new IntPoint(x, y);

                        if (cp.Type == PieceType.Robot)
                        {
                            IntPoint diff = new IntPoint(Math.Sign(prof.X - current.X), Math.Sign(prof.Y - current.Y));
                            IntPoint newPoint = new IntPoint(current.X + diff.X, current.Y + diff.Y);

                            moveCharacter(current, newPoint);
                        }
                    }
                }
            }
        }

        public void CommitTemp()
        {
            for (int x = 0; x < _board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < _board.GetPositionHeight(); y++)
                {
                    var tempPosition = _board.GetTempPosition(x, y);

                    _board.SetPosition(x, y, tempPosition);
                    _board.ResetTempPosition(x, y);
                }
            }
            Redraw(false);
        }

        private void AddHighScore()
        {
            var man = new HighScoreManager();

        	string name = _settings.PlayerName;
            man.AddHighScore(name, _level, _bombCount, _teleportCount, _moveCount, _startTime, _boardSize);
            man.SaveLocalHighScores();
        }

        public void Redraw(bool clear)
        {
            if (clear)
                _boardView.Clear(true);

           // _boardView.DrawGrid(_boardSize.Width, _boardSize.Height, _squareSize.Width, _squareSize.Height);
            _boardView.DrawBoard(_board, _squareSize.Width - 1, _squareSize.Height - 1);

            _boardView.ShowStatus(_level, _bombCount, _teleportCount, _robotCount, _moveCount, _maxLevel);
        }

        public bool BlowBomb()
        {
            int robotCountBefore = _robotCount;

            if (_bombCount > 0)
            {
                IntPoint prof = getProfessor(false);

                for (int x = Math.Max(prof.X - 1, 0); x <= Math.Min(prof.X + 1, _boardSize.Width - 1); x++)
                {
                    for (int y = Math.Max(prof.Y - 1, 0); y <= Math.Min(prof.Y + 1, _boardSize.Height - 1); y++)
                    {
                        if (_board.GetPosition(x, y) != null)
                        {
                            BoardPosition bp = _board.GetPosition(x, y);

                            if (bp.Type == PieceType.Robot)
                            {
                                _boardView.AddLineToLog(string.Format("Bombing robot {0}", (new IntPoint(x, y)).ToString()));
                                _boardView.Animate(bp, new IntPoint(x, y), new IntPoint(x, y), true);
                                //                                _boardView.RemoveAnimate(bp);
                                if (_bombToHeap)
                                {
                                    _board.SetTempPosition(x, y, bp);
                                    bp.ConvertToHeap();
                                }
                                else
                                {
                                    _board.SetTempPosition(x, y, bp);
//                                    _board.ResetPosition(x, y);
                                    bp.ConvertToNone();
                                    _boardView.RemoveImage(bp.ImageName);
                                }

                                _robotCount--;
                                if (_robotCount == 0)
                                {
                                    _gameStatus = GameStatus.LevelComplete;
                                }
                            }
                        }
                    }
                }
            }

            if (robotCountBefore != _robotCount)
            {
                _bombCount--;
                return true;
            }

            return false;
        }

        public bool DoTeleport()
        {
            if (_teleportCount > 0)
            {
                IntPoint oldProfPos = getProfessor(false);
                IntPoint newProfPos = getFreePosition();

                _boardView.AddLineToLog(string.Format("T. from {0} to {1}", oldProfPos.ToString(), newProfPos.ToString()));

                moveCharacter(oldProfPos, newProfPos);

                _teleportCount--;
                return true;
            }
            return false;
        }

        public MoveDirection GetDirection(IntPoint iPosClickPx)
        {
            IntPoint iProfPos = getProfessor(false);
            IntPoint iPosClick = new IntPoint((int)Math.Floor(iPosClickPx.X / _squareSize.Width), (int)Math.Floor(iPosClickPx.Y / _squareSize.Height));

            if (iPosClick.X < 0 || iPosClick.Y < 0 || iPosClick.X > _boardSize.Width || iPosClick.Y > _boardSize.Height)
            {
                return MoveDirection.Ignore;
            }


            if (iPosClick.X == iProfPos.X && iPosClick.Y == iProfPos.Y)
            {
                return MoveDirection.None;
            }
            else if (iPosClick.X == iProfPos.X && iPosClick.Y > iProfPos.Y)
            {
                return MoveDirection.South;
            }
            else if (iPosClick.X == iProfPos.X && iPosClick.Y < iProfPos.Y)
            {
                return MoveDirection.North;
            }
            else if (iPosClick.X > iProfPos.X && iPosClick.Y == iProfPos.Y)
            {
                return MoveDirection.East;
            }
            else if (iPosClick.X < iProfPos.X && iPosClick.Y == iProfPos.Y)
            {
                return MoveDirection.West;
            }
            else if (iPosClick.X > iProfPos.X && iPosClick.Y > iProfPos.Y)
            {
                return MoveDirection.SouthEast;
            }
            else if (iPosClick.X < iProfPos.X && iPosClick.Y < iProfPos.Y)
            {
                return MoveDirection.NorthWest;
            }
            else if (iPosClick.X > iProfPos.X && iPosClick.Y < iProfPos.Y)
            {
                return MoveDirection.NorthEast;
            }
            else if (iPosClick.X < iProfPos.X && iPosClick.Y > iProfPos.Y)
            {
                return MoveDirection.SouthWest;
            }
            return MoveDirection.None;
        }
    }
}
