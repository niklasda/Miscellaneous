using System;
using System.Configuration;
using System.Drawing;

namespace Dahlex.Settings
{
    [Serializable()]
    public sealed class Options 
    {
        
        public string PlayerName = "Dr. Who";
        public readonly string ComputerName = "Computron";
        public string ThemeName = "default";
        public bool ToxicHeaps = false;
        public bool SmartRobots = false;
        public int StartLevel = 1;
        public int StartBombs = 1;
        public int StartTeleports = 1;
        public bool BombToHeap = false;
        public string ThemesFolder = ConfigurationManager.AppSettings["themesfolder"];

        public readonly string xsdName = "theme.xsd";
        public readonly string xmlName = "theme.xml";
        
   //     public int SquareHeight = 30;
    //    public int SquareWidth = 30;

        public Size SquareSize = new Size(30, 30);
        public Size PictureSize = new Size(30, 30);
        public Size BoardSize = new Size(5,5);

        public readonly string LocalHighScoreFileName = "DahlexNetLocalHighScores.bin";

        public Color DefaultBgColor = Color.WhiteSmoke;
    }
}
