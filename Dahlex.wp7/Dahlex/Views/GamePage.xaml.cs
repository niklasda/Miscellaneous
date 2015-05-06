using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Dahlex.Logic;
using Dahlex.Logic.Logger;
using Dahlex.Logic.Settings;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Point = System.Windows.Point;

namespace Dahlex.Views
{
    public partial class GamePage : PhoneApplicationPage, IDahlexView
    {
        public GamePage()
        {
            InitializeComponent();

            _settings = GetSettings2();

            if (_settings.UseSwipesToMove)
            {
                this.ManipulationCompleted += PhoneApplicationPage_ManipulationCompleted;
            }
            else
            {
                this.MouseLeftButtonDown += PhoneApplicationPage_MouseLeftButtonDown;
            }
        }

        private GameController _dg;
        private GameSettings _settings;

        private GameSettings GetSettings2()
        {
            var sm = new SettingsManager();
            var s = sm.LoadLocalSettings();
            return s;
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void PhoneApplicationPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddLineToLog("Click");
            Point posClick = e.GetPosition(cnvMovement);

            //dumpCanvas(cnvMovement);
            IntPoint iPosClick = new IntPoint((int)posClick.X, (int)posClick.Y);

            if (_dg != null && _dg.Status == GameStatus.LevelOngoing)
            {
                MoveDirection dir = _dg.GetDirection(iPosClick);
                if (dir != MoveDirection.Ignore)
                {
                    performRound(dir);
                }
            }
        }

        private void PhoneApplicationPage_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (_dg != null && _dg.Status == GameStatus.LevelOngoing)
            {
                //very small swipe or tap is like clicking the professor in standard move mode
                if (IsTap(e) && IsWithinBounds(e))
                {
                    performRound(MoveDirection.None);
                }
                else
                {
                    var direction = Trig.GetSwipeDirection(e);
                    if (direction != MoveDirection.Ignore)
                        performRound(direction);
                }
            }
        }

        private static bool IsTap(ManipulationCompletedEventArgs e)
        {
            return Trig.IsTooSmallSwipe(e);
        }

        //ugly, just for now to make it work
        private bool IsWithinBounds(ManipulationCompletedEventArgs e)
        {
            return 77 < e.ManipulationOrigin.Y
                   && e.ManipulationOrigin.Y < 615
                   && 0 < e.ManipulationOrigin.X
                   && e.ManipulationOrigin.X < 475;
        }

        /*
        private void dumpCanvas(Canvas cnv)
        {
            foreach (var child in cnv.Children)
            {
                Debug.WriteLine(child.ToString());
            }
        }*/

        private TimeSpan _elapsed = TimeSpan.Zero;
        private void timer_tick(object state, EventArgs e)
        {
            if (_dg.Status == GameStatus.LevelOngoing)
            {
                _elapsed = _elapsed.Add(new TimeSpan(0, 0, 1));
                lblElapsed.Text = _elapsed.ToString();
            }
            else
            {
                _gameTimer.Stop();
            }
        }

        private DispatcherTimer _gameTimer;
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (_gameTimer != null)
            {
                _gameTimer.Stop();
            }
            else
            {
                _gameTimer = new DispatcherTimer();
                _gameTimer.Tick += timer_tick;
                _gameTimer.Interval = new TimeSpan(0, 0, 1);
            }

            _elapsed = TimeSpan.Zero;
            removeTimeLines();
            _gameTimer.Start();

            _dg.StartGame(_settings);
        }

        
        private void removeTimeLines()
        {
            if (storyRobots.Children.Count > 3)
            {
                storyRobots.Stop();
            }

            while (storyRobots.Children.Count > 4)
            {
                storyRobots.Children.RemoveAt(storyRobots.Children.Count - 1);
            }
        }

        private void performRound(MoveDirection dir)
        {
            if (_dg != null)
            {
                if (_dg.Status == GameStatus.LevelOngoing)
                {
                    _dg.MoveHeapsToTemp();
                    if (_dg.MoveProfessorToTemp(dir))
                    {
                        _dg.MoveRobotsToTemp();
                        _dg.CommitTemp();
                        try
                        {
                            storyRobots.Begin();
                        }
                        catch (Exception ex)
                        {
                            AddLineToLog(ex.Message);
                        }
                    }
                    else
                    {
                        AddLineToLog("P. not moved");
                    }
                }

                updateUI(_dg.Status);
            }
        }

        private void vibrate()
        {
            Microsoft.Devices.VibrateController.Default.Start(new TimeSpan(0, 0, 2));
        }

        private void blowBomb()
        {
            if (_dg != null)
            {
                if (_dg.Status == GameStatus.LevelOngoing)
                {
                    _dg.MoveHeapsToTemp();
                    if (_dg.BlowBomb())
                    {
                        vibrate();
                        PlaySound(Sound.Bomb);

                        if (_dg.MoveProfessorToTemp(MoveDirection.None))
                        {
                            _dg.MoveRobotsToTemp();
                            _dg.CommitTemp();
                            try
                            {
                                storyRobots.Begin();
                            }
                            catch (Exception ex)
                            {
                                AddLineToLog(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        AddLineToLog("Cannot bomb");
                    }
                }

                updateUI(_dg.Status);
            }
        }

        private void doTeleport()
        {
            if (_dg != null)
            {
                if (_dg.Status == GameStatus.LevelOngoing)
                {
                    _dg.MoveHeapsToTemp();
                    if (_dg.DoTeleport())
                    {
                        PlaySound(Sound.Teleport);

                        _dg.MoveRobotsToTemp();
                        _dg.CommitTemp();
                        try
                        {
                            storyRobots.Begin();
                        }
                        catch (Exception ex)
                        {
                            AddLineToLog(ex.Message);
                        }
                    }
                    else
                    {
                        AddLineToLog("No more teleports");
                    }
                }

                updateUI(_dg.Status);
            }
        }

        private void updateUI(GameStatus gameStatus)
        {
            if (gameStatus == GameStatus.Full)
            {
                AddLineToLog("Board full");
                btnNextLevel.IsEnabled = false;
            }
            else if (gameStatus == GameStatus.LevelComplete)
            {
                AddLineToLog("Level won");
                btnNextLevel.IsEnabled = true;
                btnNextLevel.Focus();
            }
            else if (gameStatus == GameStatus.LevelOngoing)
            {
                btnNextLevel.IsEnabled = false;
            }
            else if (gameStatus == GameStatus.Lost)
            {
                AddLineToLog("You lost");
                btnStartGame.IsEnabled = true;
                btnStartGame.Focus();
                btnNextLevel.IsEnabled = false;
                //    tElapsedTime.Enabled = false;
            }
            else if (gameStatus == GameStatus.Won)
            {
                AddLineToLog("You won");
                btnNextLevel.IsEnabled = false;
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            _dg = new GameController(this);

            btnNextLevel.IsEnabled = false;
            btnStartGame.Focus();

            btnStartGame_Click(null, new RoutedEventArgs());
        }

        public void AddLineToLog(string log)
        {
            log += string.Format(" RC:{0} PC:{1} Images:{2}", storyRobots.Children.Count, storyProf.Children.Count, cnvMovement.Children.Count);
            log += Environment.NewLine;

            GameLogger.AddLineToLog(log);
        }

        private DoubleAnimation findAnimationInStoryBoard(Storyboard sb, string name, string path)
        {
            foreach (Timeline child in sb.Children)
            {
                var da = child as DoubleAnimation;
                if (da != null && Storyboard.GetTargetName(da).Equals(name) && Storyboard.GetTargetProperty(da).Path.Equals(path))
                    return da;
            }
            return null;
        }

        public void Animate(BoardPosition bp, IntPoint oldPos, IntPoint newPos, bool killWhenDone)
        {
            int oLeft = oldPos.X * _settings.SquareSize.Width + _settings.ImageOffset.X; // squareSize, was 30
            int oTop = oldPos.Y * _settings.SquareSize.Height + _settings.ImageOffset.Y; //30;
            int nLeft = newPos.X * _settings.SquareSize.Width + _settings.ImageOffset.X; //30;
            int nTop = newPos.Y * _settings.SquareSize.Height + _settings.ImageOffset.Y; //30;

            if (bp.Type == PieceType.Professor)
            {

                aniProfLeft.From = oLeft;
                aniProfLeft.To = nLeft;

                aniProfTop.From = oTop;
                aniProfTop.To = nTop;
                storyProf.Begin();

                //AddLineToLog(string.Format("AnimP {0}:{1} to {2}:{3}", oLeft, oTop, nLeft, nTop));
            }
            else if (bp.Type == PieceType.Robot)
            {
                //AddLineToLog(string.Format("AnimR {0} to {1}", oldPos.ToString(), newPos.ToString()));

                DoubleAnimation aniL = findAnimationInStoryBoard(storyRobots, bp.ImageName, "(Canvas.Left)");
                if (aniL == null)
                {
                    aniL = new DoubleAnimation();
                    aniL.AutoReverse = aniProfLeft.AutoReverse;
                    aniL.Duration = aniProfLeft.Duration;
                    Storyboard.SetTargetName(aniL, bp.ImageName);
                    Storyboard.SetTargetProperty(aniL, new PropertyPath("(Canvas.Left)"));

                    storyRobots.Children.Add(aniL);
                }

                aniL.From = oLeft;
                aniL.To = nLeft;


                DoubleAnimation aniT = findAnimationInStoryBoard(storyRobots, bp.ImageName, "(Canvas.Top)");
                if (aniT == null)
                {
                    aniT = new DoubleAnimation();
                    aniT.AutoReverse = aniProfTop.AutoReverse;
                    aniT.Duration = aniProfTop.Duration;
                    Storyboard.SetTargetName(aniT, bp.ImageName);
                    Storyboard.SetTargetProperty(aniT, new PropertyPath("(Canvas.Top)"));

                    storyRobots.Children.Add(aniT);
                }
                aniT.From = oTop;
                aniT.To = nTop;

                if (killWhenDone)
                {
                    aniT.Completed += ani_Completed;
                    aniL.Completed += ani_Completed;
                    AddLineToLog(string.Format("AK {0}", bp.ImageName));
                }

            }
        }

        private void ani_Completed(object sender, EventArgs e)
        {
            DoubleAnimation ani = (DoubleAnimation)sender;

            ani.From = ani.To;
            string name = Storyboard.GetTargetName(ani);

            AddLineToLog(string.Format("DisA {0} {1} ", ani.From, name));

            ani.Completed -= ani_Completed;
        }

        public void Clear(bool all)
        {
            var drawer = new BoardDrawing(cnvMovement, _settings);

            drawer.Clear(all);
        }

        public void DrawBoard(IBoard board, int xSize, int ySize)
        {
            var drawer = new BoardDrawing(cnvMovement, _settings);
            drawer.DrawBoard(board, xSize, ySize);
        }

        public void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount, int maxLevel)
        {
            lblLevel.Text = string.Format("Lvl: {0}/{1} ", level, maxLevel);

            lblBombs.Text = string.Format("Bombs: {0}  Teleports: {1}  Dahlex: {2}  Moves: {3}", bombCount, teleportCount, robotCount, moveCount);
        }

        public void RemoveImage(string imageName)
        {
            var drawer = new BoardDrawing(cnvMovement, _settings);
            drawer.RemoveImage(imageName);
        }

        private void btnBomb_Click(object sender, RoutedEventArgs e)
        {
            blowBomb();
        }

        private void btnTeleport_Click(object sender, RoutedEventArgs e)
        {
            doTeleport();
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {

            if (_dg != null)
            {
                if (_dg.Status == GameStatus.LevelComplete)
                {
                    storyRobots.Stop();
                    _dg.StartNextLevel();

                    _gameTimer.Start();
                }
                updateUI(_dg.Status);
            }
        }

        public void PlaySound(Sound effect)
        {
            if (!_settings.LessSound)
            {
                FrameworkDispatcher.Update();

                switch (effect)
                {
                    case Sound.Bomb:
                        PlayBombSoundEffect();
                        break;
                    case Sound.Teleport:
                        PlayTeleportSoundEffect();
                        break;
                    case Sound.Crash:
                        PlayCrashSoundEffect();
                        break;
                }
            }
        }

        /// <summary>
        /// http://soundbible.com/1467-Grenade-Explosion.html
        /// </summary>
        private void PlayBombSoundEffect()
        {
            const string bombMp3 = "Sounds/Grenade.wav";
            SoundEffect effect = SoundEffect.FromStream(TitleContainer.OpenStream(bombMp3));
            effect.Play();
        }

        /// <summary>
        /// http://soundbible.com/1361-Dying-Robot.html
        /// </summary>
        private void PlayCrashSoundEffect()
        {
            const string crashMp3 = "Sounds/Crash.wav";
            SoundEffect effect = SoundEffect.FromStream(TitleContainer.OpenStream(crashMp3));
            effect.Play();
        }

        /// <summary>
        /// http://soundbible.com/1088-Magical.html
        /// </summary>
        private void PlayTeleportSoundEffect()
        {
            const string teleMp3 = "Sounds/Magical.wav";
            SoundEffect effect = SoundEffect.FromStream(TitleContainer.OpenStream(teleMp3));
            effect.Play();
        }

        /// <summary>
        /// http://soundcloud.com/nrdvrgr/nordvargr-drakh-the-betrayal-of-light
        /// </summary>
        private void bgElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (!_settings.LessSound)
            {
                var mp3 = (MediaElement) sender;
                mp3.Position = TimeSpan.Zero;
                mp3.Play();
            }
        }

        private void bgElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            AddLineToLog(string.Format("MediaFail {0}", e.ErrorException.Message));
        }

        private void bgElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mp3 = (MediaElement)sender;
            mp3.Position = TimeSpan.Zero;
            mp3.Play();
        }
    }
}