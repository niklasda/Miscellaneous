using System;
using System.Drawing;
using System.Windows.Forms;
using Dahlex;
using Dahlex.Settings;
using Dahlex.Theming;
using DahlexLogic;

namespace DahlexThemeEditor
{
    public partial class fLevelDesigner : Form
    {
        public fLevelDesigner()
        {
            InitializeComponent();
        }

        private ThemeBoard board;
        private Options gameOptions;
        private Graphics gridGfx;
        private Pen gridPen;

        public fLevelDesigner(ThemeBoard themeBoard, Options options)
            : this()
        {
            board = themeBoard;
            gameOptions = options;
        }

        private void fLevelDesigner_Load(object sender, EventArgs e)
        {
            
            Text = string.Format("Level Designer - {0}", board.ToString());
            gridGfx = pBoardDesign.CreateGraphics();
            gridPen = new Pen(Color.Black);
            gridPen.Width = 1;
            redraw();
        }

        private void redraw()
        {
            BoardDrawing drawing = new BoardDrawing(gridGfx, gridPen, gameOptions, pBoardDesign, DrawingMode.Editor);
            drawing.Clear();

            if(board.StaticLevel!=null)
            {
                drawing.DrawGrid(board.StaticLevel.Board.GetPositionHeight(), board.StaticLevel.Board.GetPositionHeight(), board.ImageHeight, board.ImageHeight, board);
                drawing.DrawBoard(board.StaticLevel.Board, board.ImageWidth, board.ImageHeight, true);
            }
            else
            {
                drawing.DrawGrid(gameOptions.BoardSize.Width, gameOptions.BoardSize.Height, board.ImageHeight, board.ImageHeight, board);
           //     drawing.DrawBoard(board.StaticLevel.Board, board.ImageHeight, board.ImageHeight, true);
                
            }
        }
        
        public ThemeBoard GetBoard()
        {
            return board;
        }

        private void pBoardDesign_Paint(object sender, PaintEventArgs e)
        {
            redraw();
        }

        private void pBoardDesign_Resize(object sender, EventArgs e)
        {
            gridGfx = pBoardDesign.CreateGraphics();
        }
    }
}