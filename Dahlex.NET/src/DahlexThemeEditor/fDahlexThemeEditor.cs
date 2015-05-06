using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dahlex;
using Dahlex.Settings;
using Dahlex.Theming;
using DahlexLogic.Theming;

namespace DahlexThemeEditor
{
    public partial class fDahlexThemeEditor : Form
    {
        public fDahlexThemeEditor()
        {
            InitializeComponent();
            gameOptions = OptionsManager.GetOptions();            
        }

        internal fDahlexThemeEditor(bool autoLoad)
            : this()
        {
            if (autoLoad)
            {
                string fileName = Application.StartupPath + @"\..\..\..\Dahlex.NET\themes\default\theme.xml";
                try
                {
                    loadXml(fileName);
                }
                catch
                {
                }
            }
        }
        
        public fDahlexThemeEditor(bool autoLoad, DirectoryInfo dir)
            : this()
        {
            if (autoLoad)
            {
                string fileName = dir.FullName + @"\theme.xml";
          //      try
            //    {
                    loadXml(fileName);
              //  }
              //  catch(Exception ex)
              //  {
                //    MessageBox.Show(ex.ToString());
              //  }
            }
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAbout.ShowMe();
        }

        private Options gameOptions;
        private Theme loadedTheme;
        private ThemeBoard selectedBoard;
        private string lastFileName;

        private const string imageFileExtension = "png";
        private const string themeFileExtension = "xml";
        private const string themeFileName = "theme";
        
        private string getFileFilter(FileExtensionGroup group)
        {
            if(group == FileExtensionGroup.Theme)
            {
                return string.Format("Theme Files ({0}.{1})|{0}.{1}|Xml Files (*.{1})|*.{1}|All Files (*.*)|*.*", themeFileName, themeFileExtension);
            }
            else
            {
                return string.Format("Image Files (*.{0})|*.{0}|All Files (*.*)|*.*", imageFileExtension);
            }
        }

        private string GetFileNameFromDialog(FileExtensionGroup group)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = getFileFilter(group);
            open.Multiselect = false;
            open.CheckFileExists = true;
            open.InitialDirectory = gameOptions.ThemesFolder;
            if (open.ShowDialog() == DialogResult.OK)
            {
                return open.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private void msmiOpen_Click(object sender, EventArgs e)
        {
            string fileName = GetFileNameFromDialog(FileExtensionGroup.Theme);
            if(fileName.Length>0)
            {
                loadXml(fileName);
            }
        }

        private void loadEmbeddedXml(Stream stream)
        {
            ThemeManager man = new ThemeManager();
            loadedTheme = man.GetEmbeddedTheme(gameOptions, stream);

            showOptions(gameOptions);
            showTheme(loadedTheme);            
        }
        
        private void loadXml(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            DirectoryInfo dir = file.Directory;
            DirectoryInfo themesDir = dir.Parent;
            string themeName = dir.Name;

            gameOptions.ThemesFolder = themesDir.FullName;
            gameOptions.ThemeName = themeName;
            
            ThemeManager man = new ThemeManager();
            loadedTheme = man.GetTheme(gameOptions);

            showOptions(gameOptions);
            showTheme(loadedTheme);

            lastFileName = file.FullName;
        }

        private void showOptions(Options options)
        {
            lThemesFolder.Text = options.ThemesFolder;
        }

        private void showTheme(Theme theme)
        {
            if(theme!=null)
            {
                tbThemeName.Text = theme.ThemeName;
            
                tbThemeAuthor.Text = theme.Author;
                tbThemeVersion.Text = theme.DahlexVersion;
                numBoardWidth.Value = theme.BoardWidth;
                numBoardHeight.Value = theme.BoardHeight;
            
                lbLevels.Items.Clear();
                Dictionary<int, ThemeBoard>.Enumerator boards = theme.GetLevelBoards();
                while(boards.MoveNext())
                {
                    KeyValuePair<int, ThemeBoard> kvp = boards.Current;
                    ThemeBoard board = kvp.Value;

                    lbLevels.Items.Add(board);
                    lbLevels.SelectedIndexChanged += new EventHandler(lbLevels_SelectedIndexChanged);
                }

                showAllImages();
            }
        }

        void lbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            selectedBoard = (ThemeBoard)list.SelectedItem;
            selectBoard(selectedBoard);
        }

        private void selectBoard(ThemeBoard board)
        {
            if(board!=null)
            {
                bDesignLevel.Enabled = true;
                bPickBackgroundColor.Enabled = true;
                bPickLineColor.Enabled = true;
                numImageHeight.Enabled = true;
                numImageWidth.Enabled = true;
                numLineWidth.Enabled = true;
                
                showBoard(board);
            }
        }

        private void lbLevels_DoubleClick(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            selectedBoard = (ThemeBoard)list.SelectedItem;
            selectBoard(selectedBoard);
            fLevelDesigner designer = new fLevelDesigner(selectedBoard, gameOptions);
            if (designer.ShowDialog() == DialogResult.OK)
            {
                selectedBoard = designer.GetBoard();
            }
        }

        
        private void showBoard(ThemeBoard board)
        {
            bDesignLevel.Text = string.Format("&Design {0}...", board.ToString());
            numLineWidth.Value = board.LineWidth;
            numImageHeight.Value = board.ImageHeight;
            numImageWidth.Value = board.ImageWidth;
        
            pbPreviewLineColor.BackColor = board.LineColor;
            pbPreviewBgColor.BackColor = board.BackgroundColor;
         //   numLineWidth.Value = board.ImageFolder;
         //   numLineWidth.Value = board.ImageHeight;
         //   numLineWidth.Value = board.ImageWidth;

        }

        private void msmiSave_Click(object sender, EventArgs e)
        {
            saveAsXml(lastFileName);

        }

        private void msmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = true;
            save.InitialDirectory = gameOptions.ThemesFolder;
            save.DefaultExt = ".xml";
            save.Filter = getFileFilter(FileExtensionGroup.Theme);
            if(save.ShowDialog() == DialogResult.OK)
            {
            //    string fileName = save.FileName;
                saveAsXml(save.FileName);
            }
        }

        private void saveAsXml(string fileName)
        {
            FileInfo f = new FileInfo(fileName);

            if (!f.Exists)
            {
                f.Create();
                ThemeManager tm = new ThemeManager();
                //     tm.SaveTheme(gameOptions, );
            }
            else
            {
                MessageBox.Show("Cannot overwrite");
            }

        }

        private void msmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            //loadedTheme = null;
        }

        private void bPickLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowHelp = true;
            
            dlg.Color = pbPreviewLineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbPreviewLineColor.BackColor = dlg.Color;
                selectedBoard = (ThemeBoard)lbLevels.SelectedItem;
                if (selectedBoard != null)
                {
                    selectedBoard.LineColor = dlg.Color;
                }
            }
        }

        private void bPickBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowHelp = true;

            dlg.Color = pbPreviewBgColor.BackColor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbPreviewBgColor.BackColor = dlg.Color;
                selectedBoard = (ThemeBoard)lbLevels.SelectedItem;
                if (selectedBoard != null)
                {
                    selectedBoard.BackgroundColor = dlg.Color;
                }
            }
        }

        private void bDesignLevel_Click(object sender, EventArgs e)
        {
            fLevelDesigner designer = new fLevelDesigner(selectedBoard, gameOptions);
            if( designer.ShowDialog() == DialogResult.OK)
            {
                selectedBoard = designer.GetBoard(); 
            }
            // todo cancel does not work
        }

        private void msmiCheckIntegrity_Click(object sender, EventArgs e)
        {
           // string xsdFileName = @"C:\Projects\Dahlex.NET\Dahlex.NET\themes\theme.xsd";
            string xsdName = gameOptions.xsdName;
            
            XmlHelper validator = new XmlHelper();
            List<Exception> problems = validator.CheckIntegrity(lastFileName, xsdName);
            
            if(problems.Count>0)
            {
                MessageBox.Show(problems[0].Message);
            }
            else
            {
                MessageBox.Show(string.Format("The file: {0} is valid!", lastFileName)); 
            }
        }


        private void msmiOpenEmbedded_Click(object sender, EventArgs e)
        {
            XmlHelper xml = new XmlHelper();
            Stream stream = xml.GetEmbeddedTheme(gameOptions.xmlName);
            loadEmbeddedXml(stream);

        }

        private void bRefreshThemeImages_Click(object sender, EventArgs e)
        {
//            try
  //          {
                showAllImages();
    //        }
      //      catch(Exception ex)
        //    {
          //      MessageBox.Show(ex.ToString());
            //}
        }

        private void showAllImages()
        {
            showHeapImages();
            showRobotImages();
            showProfessorImages();            
        }
        
        private void showHeapImages()
        {
            lvHeapImages.Items.Clear();
            ilHeaps.Images.Clear();
            Dictionary<int, Bitmap> heapImages = ImageHelper.GetHeapBitmaps(gameOptions);
            foreach (KeyValuePair<int, Bitmap> heapImagePair in heapImages)
            {
                Image heapImage = heapImagePair.Value;
                string key = string.Format("heap_{0}", heapImagePair.Key);
                if (!ilHeaps.Images.ContainsKey(key))
                {
                    ilHeaps.Images.Add(key, heapImage);
                }
                if (!lvHeapImages.Items.ContainsKey(key))
                {
                    lvHeapImages.Items.Add(key, key, key);
                }
            }
        }
        private void showRobotImages()
        {
            lvRobotImages.Items.Clear();
            ilRobots.Images.Clear();
            Dictionary<int, Bitmap> robotImages = ImageHelper.GetRobotBitmaps(gameOptions);
            foreach (KeyValuePair<int, Bitmap> robotImagePair in robotImages)
            {
                Image robotImage = robotImagePair.Value;
                string key = string.Format("robot_{0}", robotImagePair.Key);
                if (!ilRobots.Images.ContainsKey(key))
                {
                    ilRobots.Images.Add(key, robotImage);
                }
                if (!lvRobotImages.Items.ContainsKey(key))
                {
                    lvRobotImages.Items.Add(key, key, key);
                }
            }
        }
        private void showProfessorImages()
        {
            lvProfessorImages.Items.Clear();
            ilProfessors.Images.Clear();
            Dictionary<int, Bitmap> professorImages = ImageHelper.GetProfessorBitmaps(gameOptions);
            foreach (KeyValuePair<int, Bitmap> professorImagePair in professorImages)
            {
                Image professorImage = professorImagePair.Value;
                string key = string.Format("professor_{0}", professorImagePair.Key);
                if (!ilProfessors.Images.ContainsKey(key))
                {
                    ilProfessors.Images.Add(key, professorImage);
                }
                if (!lvProfessorImages.Items.ContainsKey(key))
                {
                    lvProfessorImages.Items.Add(key, key, key);
                }
            }
        }

        private void bExploreThemeFolder_Click(object sender, EventArgs e)
        {
            Process.Start(lThemesFolder.Text);
        }

    
    }
}