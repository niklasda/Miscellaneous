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

        public ThemeLevel StaticLevel
        {
            get { return _staticLevel;  }
            set { _staticLevel = value; }
        }

        public override string ToString()
        {
            if(_level==-1)
            {
                return "The rest";
            }
            else
            {
                return string.Format("Level {0}", _level);
            }
        }
    }
}