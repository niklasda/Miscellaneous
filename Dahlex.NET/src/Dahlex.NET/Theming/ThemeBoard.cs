
using System;
using System.Drawing;

namespace Dahlex.Theming
{
    public class ThemeBoard
    {
        private int _level;
        private string _imageFolder;
        private int _imageHeight;
        private int _imageWidth;
        private int _lineWidth;
        private Color _lineColor;
        private string _backgroundImageName;
        private Image _backgroundImage;
        private Color _backgroundColor;
        private ThemeLevel _staticLevel;

        public ThemeBoard(int level)
        {
            Level = level;
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string ImageFolder
        {
            get { return _imageFolder; }
            set { _imageFolder = value; }
        }

        public int ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }

        public int ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        public int LineWidth
        {
            get { return _lineWidth; }
            set { _lineWidth = value; }
        }

        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        public string BackgroundImageName
        {
            get { return _backgroundImageName; }
            set { _backgroundImageName = value; }
        }

        public Image BackgroundImage
        {
            get { return _backgroundImage; }
            set { _backgroundImage = value; }
        }

        public ThemeLevel StaticLevel
        {
            get { return _staticLevel;  }
            set { _staticLevel = value; }
        }

        public Image GetBackgroundImage()
        {
            if(_backgroundImageName!=null)
            {
                return Image.FromFile(_backgroundImageName);
            }
            return null;
        }
    }
}