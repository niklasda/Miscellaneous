using System.Drawing;
using System.IO;
using System.Xml;
using Dahlex.Settings;

namespace Dahlex.Theming
{
    public sealed class ThemeManager
    {
        private Options gameOptions;
        
        public Theme GetTheme(Options options)
        {
            gameOptions = options;
            Theme theme = null;
            if (gameOptions.ThemesFolder != null)
            {
                DirectoryInfo themesDir = new DirectoryInfo(gameOptions.ThemesFolder);
                if (themesDir.Exists)
                {
                    DirectoryInfo themeDir = new DirectoryInfo(themesDir.FullName + @"\" + gameOptions.ThemeName);
                    if (themeDir.Exists)
                    {
                        FileInfo file = new FileInfo(themeDir.FullName + @"\"+ gameOptions.xmlName);
                        if (file.Exists)
                        {
                            theme = getThemeFromXmlFile(file.OpenRead());
                        }
                    }
                }
            }
            return theme;
        }
        
        public Theme GetEmbeddedTheme(Options options, Stream stream)
        {
            gameOptions = options;
            return getThemeFromXmlFile(stream);
        }

        private Theme getThemeFromXmlFile(Stream fileStream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.IgnoreWhitespace = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(fileStream, settings);

            Theme returnTheme = new Theme();
            
            while (reader.Read())
            {

                processFirstLevelElement(reader, ref returnTheme);
            }
            return returnTheme;
        }

        private void processFirstLevelElement(XmlReader reader, ref Theme returnTheme)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name.Equals("DahlexTheme"))
                    {
                        returnTheme.DahlexVersion = getStringAttribute(reader, "version");
                    }
                    else if (reader.Name.Equals("ThemeName"))
                    {
                        reader.Read();
                        returnTheme.ThemeName = getStringValue(reader);
                    }
                    else if (reader.Name.Equals("Author"))
                    {
                        reader.Read();
                        returnTheme.Author = getStringValue(reader);
                    }
                    else if (reader.Name.Equals("BoardHeight"))
                    {
                        reader.Read();
                        returnTheme.BoardHeight = getIntValue(reader);
                    }
                    else if (reader.Name.Equals("BoardWidth"))
                    {
                        reader.Read();
                        returnTheme.BoardWidth = getIntValue(reader);
                    }
                    else if (reader.Name.Equals("Board"))
                    {
                        string levelBoard = getStringAttribute(reader, "level");
                        if (levelBoard.Equals("*"))
                            levelBoard = "-1";
                        int level = int.Parse(levelBoard);
                        ThemeBoard themeBoard = new ThemeBoard(level);
                        getBoardFromXml(reader, ref themeBoard);
                        returnTheme.AddLevelBoard(themeBoard);
                    }
                }
            }
        }

        private void getBoardFromXml(XmlReader reader, ref ThemeBoard returnBoard)
        {
            while (reader.Read())
            {
                processBoardElement(reader, ref returnBoard);

                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if(reader.Name.Equals("Board"))
                        return;
                }
            }
        }

        private void processBoardElement(XmlReader reader, ref ThemeBoard returnBoard)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name.Equals("ImageFolder"))
                    {
                        reader.Read();
                        returnBoard.ImageFolder = getStringValue(reader);
                    }
                    else if (reader.Name.Equals("ImageHeight"))
                    {
                        reader.Read();
                        returnBoard.ImageHeight = getIntValue(reader);
                    }
                    else if (reader.Name.Equals("ImageWidth"))
                    {
                        reader.Read();
                        returnBoard.ImageWidth = getIntValue(reader);
                    }
                    else if (reader.Name.Equals("LineWidth"))
                    {
                        reader.Read();
                        returnBoard.LineWidth = getIntValue(reader);
                    }
                    else if (reader.Name.Equals("LineColor"))
                    {
                        reader.Read();
                        returnBoard.LineColor = Color.FromName(getStringValue(reader));
                    }
                    else if (reader.Name.Equals("BackgroundColor"))
                    {
                        reader.Read();
                        returnBoard.BackgroundColor = Color.FromName(getStringValue(reader));
                    }
                    else if (reader.Name.Equals("StaticLevel"))
                    {
                        ThemeLevel themeLevel = new ThemeLevel(returnBoard.Level);
                        returnBoard.StaticLevel = themeLevel;
                        processStaticLevelElement(reader, ref themeLevel);
                    }
                }
            }
        }

        private void processStaticLevelElement(XmlReader reader, ref ThemeLevel themeLevel)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name.Equals("StaticLevel"))
                    {
                        int levelWidth = getIntAttribute(reader, "width");
                        int levelHeight = getIntAttribute(reader, "height");
                        themeLevel.SetSize(levelWidth, levelHeight);

                        while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("StaticLevel")))
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                if (reader.IsStartElement())
                                {
                                    if (reader.Name.Equals("Row"))
                                    {
                                        int rowOrderNr = getIntAttribute(reader, "orderNr");
                                        while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Row")))
                                        {
                                            reader.Read();
                                            if (reader.NodeType == XmlNodeType.Element)
                                            {
                                                if (reader.IsStartElement())
                                                {
                                                    if (reader.Name.Equals("Column"))
                                                    {
                                                        int columnOrderNr = getIntAttribute(reader, "orderNr");
                                                        reader.Read();

                                                        if (reader.NodeType == XmlNodeType.Element)
                                                        {
                                                            if (reader.IsStartElement())
                                                            {
                                                                if (reader.Name.Equals("Cell"))
                                                                {
                                                                    PieceType cellType = getPieceTypeAttribute(reader, "type");
                                                                    themeLevel.SetCell(rowOrderNr, columnOrderNr, cellType);
                                                                    reader.Read();
                                                                   // Debugger.Break();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string getStringValue(XmlReader reader)
        {
            if (reader.HasValue)
            {
                string val = reader.Value;
                if (val != null)
                    return val;
            }
            return string.Empty;
        }

        private int getIntValue(XmlReader reader)
        {
            if (reader.HasValue)
            {
                string val = reader.Value;
                if (val != null && val != "")
                    return int.Parse(val);
            }
            return 1;
        }

        private string getStringAttribute(XmlReader reader, string attributeName)
        {
            if (reader.HasAttributes)
            {
                string attr = reader.GetAttribute(attributeName);
                if (attr != null)
                    return attr;
            }
            return string.Empty;
        }
        
        private int getIntAttribute(XmlReader reader, string attributeName)
        {
            if (reader.HasAttributes)
            {
                string attr = reader.GetAttribute(attributeName);
                if (attr != null && attr != "")
                    return int.Parse(attr);
            }
            return 1;
        }

        private PieceType getPieceTypeAttribute(XmlReader reader, string attributeName)
        {
            if (reader.HasAttributes)
            {
                string attr = reader.GetAttribute(attributeName);
                if (attr != null && attr != "")
                    return (PieceType)PieceType.Parse(typeof(PieceType), attr);
            }
            return PieceType.None;
        }
    }
}
