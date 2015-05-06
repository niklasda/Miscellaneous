using System;
using System.Drawing;
using System.Windows.Forms;
using Dahlex;
using Dahlex.Settings;
using Dahlex.Theming;

namespace DahlexLogic
{
    public class BoardDrawing
    {
        private Graphics gridGfx;
        private Pen gridPen;
        private Options gameOptions;
        private Panel pBoard;
        private DrawingMode drawingMode;
        
        public BoardDrawing(Graphics gfx, Pen pen, Options options, Panel panel, DrawingMode mode)
        {
            gridGfx = gfx;
            gridPen = pen;
            gameOptions = options;
            pBoard = panel;
            drawingMode = mode;
        }


        public void Clear()
        {
            gridGfx.Clear(pBoard.BackColor);
        }

        /// <summary>
        /// The the game grid in the current Graphics
        /// </summary>
        /// <param name="width">the width in number of squares</param>
        /// <param name="height">the height in number of squares</param>
        /// <param name="xSize">the width of a square in pixels</param>
        /// <param name="ySize">the height of a square in pixels</param>
        /// <param name="board">the board including some settings</param>
        public void DrawGrid(int width, int height, int xSize, int ySize, ThemeBoard board)
        {
            int lineWidth = 1;
            Color lineColor = Color.Black;
            if (board != null)
            {
                lineWidth = board.LineWidth;
                lineColor = board.LineColor;
            }

            gridPen.Width = lineWidth;
            gridPen.Color = lineColor;
            for (int y = 0; y <= height; y++)
            {
                // horizontal
                Point pt1 = new Point(0, y * (ySize + (int)gridPen.Width));
                Point pt2 = new Point(width * (xSize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width/2), y * (ySize + (int)gridPen.Width));
                gridGfx.DrawLine(gridPen, pt1, pt2);
            }

            for (int x = 0; x <= width; x++)
            {
                // vertical
                Point pt1 = new Point(x * (xSize + (int)gridPen.Width), 0);
                Point pt2 = new Point(x * (xSize + (int)gridPen.Width), height * (ySize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width/2));
                gridGfx.DrawLine(gridPen, pt1, pt2);
            }

            BoardDrawingEditor bde = new BoardDrawingEditor(gameOptions);
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Point pt = new Point(x * (xSize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width / 2), y * (ySize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width/2));
                    Control ctrl = pBoard.GetChildAtPoint(pt);
                    if (!(ctrl is PictureBox))
                    {
                        PictureBox pb = new PictureBox();
                        if(board!=null)
                        {
                            pb.BackColor = board.BackgroundColor;
                        }
                        else
                        {
                            pb.BackColor = gameOptions.DefaultBgColor;
                        }
                        pb.Location = pt;
                        pb.Size = new Size(xSize, ySize);
                        if(drawingMode == DrawingMode.Editor)
                        {
                            pb.ContextMenu = bde.GetContextMenu(new Point(x, y));
                        }
                        pBoard.Controls.Add(pb);
                    }
                }
            }

            pBoard.Width = width * (xSize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width / 2);
            pBoard.Height = height * (ySize + (int)gridPen.Width) + (int)Math.Ceiling(gridPen.Width / 2);
        }

        /// <summary>
        /// draw the pieces on the board in the current Graphics
        /// </summary>
        /// <param name="board">the board with piece positions</param>
        /// <param name="xSize">the with of a piece</param>
        /// <param name="ySize">the height of a piece</param>
        /// <param name="designMode"></param>
        public void DrawBoard(IBoard board, int xSize, int ySize, bool designMode)
        {
            //return;
            pBoard.Tag = board;
            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    BoardPosition cp = board.GetPosition(x, y);
                    if (cp != null)
                    {
                        Bitmap bitMap;
                        BoardImage boardImage = null;


                        if (cp.Type == PieceType.Heap)
                        {
                            boardImage = ImageHelper.GetHeapBitmap(gameOptions, cp.ImageIndex);
                            cp.ImageIndex = boardImage.ImageIndex;
                        }
                        else if (cp.Type == PieceType.Professor)
                        {
                            boardImage = ImageHelper.GetProfessorBitmap(gameOptions, cp.ImageIndex);
                            cp.ImageIndex = boardImage.ImageIndex;
                        }
                        else if (cp.Type == PieceType.Robot)
                        {
                            boardImage = ImageHelper.GetRobotBitmap(gameOptions, cp.ImageIndex);
                            cp.ImageIndex = boardImage.ImageIndex;
                        }


                        if (boardImage != null)
                        {
                            bitMap = boardImage.PositionImage;
                            Point pt = new Point(x * (xSize + (int)gridPen.Width) + 10, y * (ySize + (int)gridPen.Width) + 10);
                            Control ctrl = pBoard.GetChildAtPoint(pt);
                            if (ctrl is PictureBox)
                            {
                                PictureBox pb = ctrl as PictureBox;
                                pb.Image = bitMap;
                            }
                        }
                        else if (cp.Type != PieceType.None)
                        {
                            throw new ApplicationException("Invalid Type of BoardPosition");
                        }
                    }
                    else if (cp == null)
                    {
                        Point pt = new Point(x * (xSize + (int)gridPen.Width) + 10, y * (ySize + (int)gridPen.Width) + 10);
                        Control ctrl = pBoard.GetChildAtPoint(pt);
                        if (ctrl is PictureBox)
                        {
                            PictureBox pb = ctrl as PictureBox;
                            if(pb.Image!=null)
                            {
                                pb.Image = null;
                            }
                        }
                    }
                }
            }
        }
    }
}
