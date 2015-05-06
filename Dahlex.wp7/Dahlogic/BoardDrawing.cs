using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Dahlex.Logic.Settings;

namespace Dahlex.Logic
{
    public class BoardDrawing
    {
        private Canvas _cnvMovement;
        private GameSettings _settings;

        public BoardDrawing(Canvas canvasMovement, GameSettings settings)
        {
            _cnvMovement = canvasMovement;
            _settings = settings;
        }

        public void Clear(bool all)
        {
            if (all)
            {
                _cnvMovement.Children.Clear();
            }
        }

        private Image findImageInCanvas(Canvas cnv, string name)
        {
            foreach (UIElement child in cnv.Children)
            {
                var img = child as Image;
                if (img != null && img.Name.Equals(name))
                {
                    return img;
                }
            }

            return null;
        }

        private void removeImage(string imgName)
        {
            var image = findImageInCanvas(_cnvMovement, imgName);

            if (image != null)
            {
                image.Visibility = Visibility.Collapsed;
            }
        }

        private void addImage(string imgName, BoardImage boardImage, IntPoint pt, BoardPosition cp)
        {
            Image piece = new Image();
            piece.Name = imgName;
            //piece.Width = 30;
            //piece.Height = 30;
            piece.SetValue(Canvas.TopProperty, (double)pt.Y);
            piece.SetValue(Canvas.LeftProperty, (double)pt.X);
            piece.Source = boardImage.PositionImage;

            if (cp.Type == PieceType.Professor)
            {
                var image = findImageInCanvas(_cnvMovement, imgName);

                if (image == null)
                {
                    _cnvMovement.Children.Add(piece);
                }
            }
            else if (cp.Type == PieceType.Heap)
            {
                var image = findImageInCanvas(_cnvMovement, imgName);
                if (image == null)
                {
                    _cnvMovement.Children.Add(piece);
                }
            }
            else
            {
                var image = findImageInCanvas(_cnvMovement, imgName);
                if (image == null)
                {
                    _cnvMovement.Children.Add(piece);
                }
            }
        }

        public void DrawBoard(IBoard board, int xSize, int ySize)
        {
            int xOffset = _settings.ImageOffset.X; // 1;
            int yOffset = _settings.ImageOffset.Y; //1;
            int gridPenWidth = _settings.LineWidth.X; //;

            for (int x = 0; x < board.GetPositionWidth(); x++)
            {
                for (int y = 0; y < board.GetPositionHeight(); y++)
                {
                    BoardPosition cp = board.GetPosition(x, y);
                    if (cp != null)
                    {
                        BoardImage boardImage = null;
                        var pt = new IntPoint(x * (xSize + gridPenWidth) + xOffset, y * (ySize + gridPenWidth) + yOffset);

                        string imgName;
                        if (cp.Type == PieceType.Heap)
                        {
                            imgName = cp.ImageName;
                            BitmapImage pic = LoadImage("heap_01.png");

                            boardImage = new BoardImage(pic, PieceType.Heap);
                            addImage(imgName, boardImage, pt, cp);
                        }
                        else if (cp.Type == PieceType.Professor)
                        {
                            imgName = cp.ImageName;
                            BitmapImage pic = LoadImage("planet.png");

                            boardImage = new BoardImage(pic, PieceType.Professor);
                            addImage(imgName, boardImage, pt, cp);
                        }
                        else if (cp.Type == PieceType.Robot)
                        {
                            imgName = cp.ImageName;

                            BitmapImage pic = LoadImage("robot_02.png");

                            pic.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                            boardImage = new BoardImage(pic, PieceType.Robot);
                            addImage(imgName, boardImage, pt, cp);
                        }
                        else if (cp.Type == PieceType.None)
                        {
                            imgName = cp.ImageName;
                            removeImage(imgName);
                            //    var pic = new BitmapImage(((BitmapImage)images.imgRobot.Source).UriSource);
                            //    boardImage = new BoardImage(pic, PieceType.Robot);
                            //    addImage(imgName, boardImage, pt, cp);
                        }
                        else
                        {

                        }
                        if (boardImage != null)
                        {
                        }
                        else if (cp.Type != PieceType.None)
                        {
                            throw new Exception("Invalid Type of BoardPosition");
                        }
                    }
                }
            }
        }

        public BitmapImage LoadImage(string relativeUriString)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resName = "Dahlex.Logic.Images." + relativeUriString;
            using (Stream str = assembly.GetManifestResourceStream(resName))
            {
                var bi = new BitmapImage();
                bi.SetSource(str);

                return bi;
            }
        }

        public void RemoveImage(string imageName)
        {
            removeImage(imageName);
        }
    }
}