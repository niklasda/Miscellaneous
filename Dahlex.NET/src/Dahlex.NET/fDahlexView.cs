using System;
using System.Drawing;
using System.Windows.Forms;
using Dahlex.Settings;
using Dahlex.Theming;
using DahlexLogic;

namespace Dahlex
{
    public sealed partial class fDahlexView : Form, IDahlexView
    {
        private DahlexController currentGame;
        private Theme currentTheme;
        private Graphics gridGfx;
        private Pen gridPen;
        private Options gameOptions = OptionsManager.GetOptions();
        
        public fDahlexView()
        {
            InitializeComponent();
        }

        public Options GameOptions
        {
            get { return gameOptions; }
        }

        private void startGame()
        {
            if (currentTheme == null)
            {
                MessageBox.Show("No theme!");
            }

            int h = (int)numHeight.Value;
            int w = (int)numWidth.Value;
            gameOptions.BoardSize = new Size(w, h);
            currentGame = new DahlexController(this, currentTheme);

            startFirstLevel();

            tElapsedTime.Enabled = true;
        }

        private void startFirstLevel()
        {
            pBoard.Controls.Clear();
            currentGame.StartGame();
        }
        
        private void startNextLevel()
        {
            pBoard.Controls.Clear();
            currentGame.NextLevel();
        }

        public Graphics GetGraphics()
        {
            return gridGfx;
        }

        public Control GetControlAt(Point p)
        {
            return pBoard.GetChildAtPoint(p);
        }
        
        public void Clear()
        {
            BoardDrawing drawer = new BoardDrawing(gridGfx, gridPen, gameOptions, pBoard, DrawingMode.Game);
            drawer.Clear();
        }
        
        public void DrawGrid(int width, int height, int xSize, int ySize, ThemeBoard board)
        {
            BoardDrawing drawer = new BoardDrawing(gridGfx, gridPen, gameOptions, pBoard, DrawingMode.Game);
            drawer.DrawGrid(width, height, xSize, ySize, board);
        }

        public void DrawBoard(IBoard board, int xSize, int ySize)
        {
            BoardDrawing drawer = new BoardDrawing(gridGfx, gridPen, gameOptions, pBoard, DrawingMode.Game);
            drawer.DrawBoard(board, xSize, ySize, false);
        }

        public void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount, int maxLevel)
        {
            lLevel.Text = string.Format("Level: {0}/{1}", level, maxLevel);
            lBombs.Text = string.Format("Bombs: {0}", bombCount);
            lTeleports.Text = string.Format("Teleports: {0}", teleportCount);
            lRobots.Text = string.Format("Dahlex: {0}", robotCount);
            lMoves.Text = string.Format("Moves: {0}", moveCount);
        }


        private void updateUI(GameStatus gameStatus)
        {
            if (gameStatus == GameStatus.Full)
            {
                AddLineToLog("Board full");
                bNextLevel.Enabled = false;
                tElapsedTime.Enabled = false;
            }
            else if (gameStatus == GameStatus.LevelComplete)
            {
                AddLineToLog("Level won");
                bNextLevel.Enabled = true;
                bNextLevel.Select();
            }
            else if (gameStatus == GameStatus.LevelOngoing)
            {
                bNextLevel.Enabled = false;
            }
            else if (gameStatus == GameStatus.Lost)
            {
                AddLineToLog("You lost");
                bStart.Enabled = true;
                bStart.Select();
                bNextLevel.Enabled = false;
                tElapsedTime.Enabled = false;
            }
            else if (gameStatus == GameStatus.Won)
            {
                AddLineToLog("You won");
                bNextLevel.Enabled = false;
                tElapsedTime.Enabled = false;
            }
        }       
        
        private void performRound(MoveDirection dir)
        {
            if (currentGame != null)
            {
                if (currentGame.Status == GameStatus.LevelOngoing)
                {
                    currentGame.MoveHeapsToTemp();
                    if (currentGame.MoveProfessorToTemp(dir))
                    {
                        currentGame.MoveRobotsToTemp();
                        currentGame.CommitTemp();
                    }
                    else
                    {
                        AddLineToLog("Professor not moved");
                    }
                }
                
                updateUI(currentGame.Status);
            }
        }

        private void blowBomb()
        {
            if (currentGame != null)
            {
                if (currentGame.Status == GameStatus.LevelOngoing)
                {
                    currentGame.MoveHeapsToTemp();
                    if (currentGame.BlowBomb())
                    {
                        if (currentGame.MoveProfessorToTemp(MoveDirection.None))
                        {
                            currentGame.MoveRobotsToTemp();
                            currentGame.CommitTemp();
                        }
                    }
                    else
                    {
                        AddLineToLog("Cannot bomb");
                    }
                }
                updateUI(currentGame.Status);
            }
        }

        private void doTeleport()
        {
            if (currentGame != null)
            {
                if (currentGame.Status == GameStatus.LevelOngoing)
                {
                    currentGame.MoveHeapsToTemp();
                    if (currentGame.DoTeleport())
                    {
                        currentGame.MoveRobotsToTemp();
                        currentGame.CommitTemp();
                    }
                    else
                    {
                        AddLineToLog("No more teleports");
                    }
                }
                updateUI(currentGame.Status);
            }
        } 
        
        private void pBoard_Paint(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
            {
                currentGame.Redraw();
            }
        }

        public void AddLineToLog(string log)
        {
            tbLog.AppendText(log + Environment.NewLine);
        }

        private void pBoard_Resize(object sender, EventArgs e)
        {
            gridGfx = pBoard.CreateGraphics();
        }        
        
        private void fDahlex_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName;
            
            gridGfx = pBoard.CreateGraphics();
            gridPen = new Pen(Color.Black);

            ThemeManager themeManager = new ThemeManager();
            currentTheme = themeManager.GetTheme(gameOptions);

            if(currentTheme!=null)
            {
                gameOptions.BoardSize = new Size(currentTheme.BoardWidth, currentTheme.BoardHeight);
            }

            SetBoardSizeControls();
        }

        public void SetBoardSizeControls()
        {
            if (gameOptions.BoardSize.Width <= numWidth.Maximum && gameOptions.BoardSize.Width >= numWidth.Minimum)
            {
                numWidth.Value = gameOptions.BoardSize.Width;
            }
            if (gameOptions.BoardSize.Height <= numHeight.Maximum && gameOptions.BoardSize.Height >= numHeight.Minimum)
            {
                numHeight.Value = gameOptions.BoardSize.Height;
            }
        }

        private void tElapsedTime_Tick(object sender, EventArgs e)
        {
            if(currentGame!=null)
            {
               
                lElapsedTime.Text = (new DateTime( (DateTime.Now - currentGame.StartTime).Ticks)  ).ToString("mm:ss");
            }
            else
            {
                tElapsedTime.Enabled = false;                
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void bNextLevel_Click(object sender, EventArgs e)
        {
            if (currentGame != null)
            {
                if(currentGame.Status == GameStatus.LevelComplete)
                {
                    startNextLevel();
                }
                else
                {
                    updateUI(currentGame.Status);
                }
            }
        } 
        
        private void bAbout_Click(object sender, EventArgs e)
        {
            fAbout.ShowMe();
        }
        
        private void bHelp_Click(object sender, EventArgs e)
        {
            fHelp.ShowMe();
        }

        private void bHighScores_Click(object sender, EventArgs e)
        {
            fHighScores.ShowMe(gameOptions);
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            fOptions options = new fOptions();
            if (options.ShowMe(gameOptions) == DialogResult.OK)
            {
                gameOptions = options.GetOptions();

                ThemeManager themeManager = new ThemeManager();
                currentTheme = themeManager.GetTheme(gameOptions);
                if (currentTheme == null)
                {
                    MessageBox.Show("Failed to load theme!");
                    numHeight.Value = gameOptions.BoardSize.Height;
                    numWidth.Value = gameOptions.BoardSize.Width;
                }
                else
                {
                    numHeight.Value = currentTheme.BoardHeight;
                    numWidth.Value = currentTheme.BoardWidth;
                }
            }
        }

        private void bSouth_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.South);
        }

        private void bNorth_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.North);
        }

        private void bEast_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.East);
        }

        private void bWest_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.West);
        }

        private void nNorthWest_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.NorthWest);
        }

        private void bNorthEast_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.NorthEast);
        }

        private void bSouthWest_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.SouthWest);
        }

        private void bSouthEast_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.SouthEast);
        }

        private void bStand_Click(object sender, EventArgs e)
        {
            performRound(MoveDirection.None);
        }

        private void bBomb_Click(object sender, EventArgs e)
        {
            blowBomb();
        }

        private void bTeleport_Click(object sender, EventArgs e)
        {
            doTeleport();
        }
        
        private void tRandomPlayer_Tick(object sender, EventArgs e)
        {
            if (!randomStarted)
            {
                startGame();
                randomStarted = true;
            }
            else
            {
                if (currentGame.Status == GameStatus.LevelOngoing)
                {
                    MoveDirection randomDirection = Randomizer.GetRandomDirection();
                    performRound(randomDirection);
                }
                else
                {
                    randomStarted = false;
                }
            }
        }
        
        private bool randomStarted = false;
        private void bTest_Click(object sender, EventArgs e)
        {
            tRandomPlayer.Enabled = true;
        }
    }
}