using System;
using System.Collections.Generic;

namespace Dahlex.Theming
{
    public sealed class Theme
    {
        private string themeName;
        private string author;
        private string dahlexVersion;
        private int boardHeight;
        private int boardWidth;
        
        private Dictionary<int, ThemeBoard> levelBoards = new Dictionary<int, ThemeBoard>();

        public void AddLevelBoard(ThemeBoard board)
        {
            if(!levelBoards.ContainsKey(board.Level))
            {
                levelBoards.Add(board.Level, board);
            }
            else
            {
                throw new ApplicationException(string.Format("Level {0} already has a board", board.Level));
            }
        }
        
        public Dictionary<int, ThemeBoard>.Enumerator GetLevelBoards()
        {
            return levelBoards.GetEnumerator();
        }
        
        public string ThemeName
        {
            get { return themeName; }
            set { themeName = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string DahlexVersion
        {
            get { return dahlexVersion; }
            set { dahlexVersion = value; }
        }

        public int BoardWidth
        {
            get { return boardWidth; }
            set { boardWidth = value; }
        }

        public int BoardHeight
        {
            get { return boardHeight; }
            set { boardHeight = value; }
        }

        public ThemeBoard GetLevelBoard(int level)
        {
            if(levelBoards.ContainsKey(level))
            {
                return levelBoards[level];
            }
            else if(levelBoards.ContainsKey(-1))
            {
                return levelBoards[-1];
            }
            return null;
        }
    }
}
