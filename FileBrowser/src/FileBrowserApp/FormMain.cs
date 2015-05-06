using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EV.Windows.Forms;
using ShellDll;

namespace Nida.Dfb
{
    public partial class FormMain : Form, IBrowserContainer
    {
        public FormMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            m_sortMgr = new ListViewSortManager(browserLeft.fileView,
                                                new Type[]
                                                    { typeof (ListViewFileFolderSort),typeof (ListViewTextCaseInsensitiveSort),
                                                        typeof (ListViewDateSort)
                                                    }
                );
            m_sortMgr = new ListViewSortManager(browserRight.fileView,
                                                new Type[]
                                                    { typeof (ListViewFileFolderSort),typeof (ListViewTextCaseInsensitiveSort),
                                                        typeof (ListViewDateSort)
                                                    }
                );
        }

        private string[] _args;

        public FormMain(string[] args) : this()
        {
            _args = args;
        }

        private ListViewSortManager m_sortMgr;
        private Browser lastClickedBrowser;
        
        private readonly string bookmarksFolder = Application.StartupPath + @"\bookmarks\";
        private readonly string toolsFolder = Application.StartupPath + @"\tools\";
        //private readonly string batFolder = Application.StartupPath + @"\bat\";

        private string comparerApp = @"D:\Program Files\Beyond Compare 2\BC2.exe";
        private string renamerApp = @"D:\Tools\Renamer\ReNamer.exe";
        private string notepadApp = "notepad.exe";
        private string cmdApp = "cmd.exe";

        private Browser LastClickedBrowser
        {
            get
            {
                if (lastClickedBrowser == null)
                {
                    lastClickedBrowser = browserLeft;
                }
                return lastClickedBrowser;
            }
        }

        public void SetActiveBrowser(Browser b)
        {
            lastClickedBrowser = b;
        }

        private void singlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSingle frm = new FormSingle();
            frm.Show();
        }

        private void browserLeft_ContextMenuMouseHover(object sender, ContextMenuMouseHoverEventArgs e)
        {
            helpInfoLabelLeft.Text = e.ContextMenuItemInfo;
        }

        private void browserLeft_SelectedFolderChanged(object sender, SelectedFolderChangedEventArgs e)
        {
            Icon icon = ShellImageList.GetIcon(e.Node.ImageIndex, true);

            if (icon != null)
            {
                currentDirInfoLeft.Image = icon.ToBitmap();
                Icon = icon;
            }
            else
            {
                currentDirInfoLeft.Image = null;
                Icon = null;
            }

            currentDirInfoLeft.Text = e.Node.Text;
            Text = string.Format("{0} - {1}", "DFB", e.Node.Text);
        }

        private void browserRight_ContextMenuMouseHover(object sender, ContextMenuMouseHoverEventArgs e)
        {
            helpInfoLabelRight.Text = e.ContextMenuItemInfo;
        }

        private void browserRight_SelectedFolderChanged(object sender, SelectedFolderChangedEventArgs e)
        {
            Icon icon = ShellImageList.GetIcon(e.Node.ImageIndex, true);

            if (icon != null)
            {
                currentDirInfoRight.Image = icon.ToBitmap();
                Icon = icon;
            }
            else
            {
                currentDirInfoRight.Image = null;
                Icon = null;
            }

            currentDirInfoRight.Text = e.Node.Text;
            Text = string.Format("{0} - {1}", "DFB", e.Node.Text);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            loadSettings();
            loadTools();
            loadBookmarks();
            browserLeft.SetParentContainer(this);
            browserRight.SetParentContainer(this);

            parseArgs();
        }

        private void parseArgs()
        {
            if(_args != null)
            {
                foreach(string arg in _args)
                {
                    if(arg.StartsWith("/E,"))
                    {
                        string path = arg.Replace("/E,", "");
                        LastClickedBrowser.SelectPath(path, true);
                    }                    
                    if(arg.StartsWith("/EL,"))
                    {
                        string path = arg.Replace("/EL,", "");
                        //lastClickedBrowser = browserLeft;
                        browserLeft.SelectPath(path, true);
                    }                    
                    if(arg.StartsWith("/ER,"))
                    {
                        string path = arg.Replace("/ER,", "");
                        //lastClickedBrowser = browserRight;
                        browserRight.SelectPath(path, true);
                    }
                }
            }
        }

        private void loadTools()
        {
            if (Directory.Exists(toolsFolder))
            {
                string[] files = Directory.GetFiles(toolsFolder, "*.lnk");

                foreach (string file in files)
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        ToolStripItem item = toolsToolStripMenuItem.DropDownItems.Add(info.Name.Replace(".lnk",""));
                        item.Tag = file;
                        item.Click += new EventHandler(tool_Click);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                Directory.CreateDirectory((toolsFolder));
            }
        }

        private void loadBookmarks()
        {
            if (Directory.Exists(bookmarksFolder))
            {
                string[] files = Directory.GetFiles(bookmarksFolder, "*.url");

                foreach (string file in files)
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);

                        StreamReader rd = info.OpenText();
                        string heading = rd.ReadLine();
                        string url = rd.ReadLine().Replace("URL=", "");
                        string url2 = rd.ReadLine();
                        string title;

                        if(url2.StartsWith("URL2="))
                        {
                            url2 = url2.Replace("URL2=", "");
                            title = rd.ReadLine().Replace("TITLE=", "");
                        }
                        else
                        {
                            title = url2;
                            title = title.Replace("TITLE=", "");
                            url2 = null;
                        }

                        ToolStripItem item = bookmarksToolStripMenuItem.DropDownItems.Add(title);
                        if(url2!=null)
                        {
                            item.Tag = new string[2] {url, url2};
                        }
                        else
                        {
                            item.Tag = url;
                        }
                        item.Click += new EventHandler(bookmark_Click);
 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                Directory.CreateDirectory((bookmarksFolder));
            }
        }

        void tool_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem) sender;
                Process.Start(item.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        
        
        void bookmark_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem) sender;
                if(item.Tag is string)
                {
                    LastClickedBrowser.SelectPath(item.Tag.ToString(), true);
                }
                else if ( item.Tag is string[])
                {
                    string[] urls = item.Tag as string[];
                    if(urls != null)
                    {
                        browserLeft.SelectPath(urls[0], true);
                        browserRight.SelectPath(urls[1], true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
                
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }

        private void addToBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string bookmark = LastClickedBrowser.SelectedNode.Text;
           
            string realPath = LastClickedBrowser.GetRealPath();
            
            ToolStripItem item = bookmarksToolStripMenuItem.DropDownItems.Add(bookmark);
            item.Tag = realPath;
            item.Click += new EventHandler(bookmark_Click);

            saveBookmark(realPath, null, bookmark);
        }

        private void addDualBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string bookmarkLeft = browserLeft.SelectedNode.Text;
            string bookmarkRight = browserRight.SelectedNode.Text;
            string bookamrk = bookmarkLeft +" <-> "+ bookmarkRight;

            string realPathLeft = browserLeft.GetRealPath();
            
            string realPathRight = browserRight.GetRealPath();
            
            ToolStripItem item = bookmarksToolStripMenuItem.DropDownItems.Add(bookmarkLeft +" <-> "+ bookmarkRight);
            item.Tag = new string[2] {realPathLeft, realPathRight};
            item.Click += new EventHandler(bookmark_Click);

            saveBookmark(realPathLeft, realPathRight, bookamrk);
        }

        private void saveBookmark(string urlNameLeft, string urlNameRight, string name)
        {
            string niceUrlNameLeft = urlNameLeft.Replace(@"\", "_");
            niceUrlNameLeft = niceUrlNameLeft.Replace(@":", "_");

            string niceUrlName;
            if (urlNameRight != null)
            {
                string niceUrlNameRight;
                niceUrlNameRight = urlNameRight.Replace(@"\", "_");
                niceUrlNameRight = niceUrlNameRight.Replace(@":", "_");
            
                niceUrlName = niceUrlNameLeft + "_" + niceUrlNameRight;
            }
            else
            {
                niceUrlName = niceUrlNameLeft;
            }

            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(string.Format("{0}{1}.url", bookmarksFolder, niceUrlName));
                sw = fi.CreateText();
                sw.WriteLine("[InternetShortcut]");
                sw.Write("URL=");
                sw.WriteLine(urlNameLeft);
                if (urlNameRight != null)
                {
                    sw.Write("URL2=");
                    sw.WriteLine(urlNameRight);
                }
                sw.Write("TITLE=");
                sw.WriteLine(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void leftPaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel1Collapsed = !splitContainerMain.Panel1Collapsed;
            leftPaneToolStripMenuItem.Checked = !leftPaneToolStripMenuItem.Checked;
        }

        private void rightPaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
            rightPaneToolStripMenuItem.Checked = !rightPaneToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetSplittersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainerMain.Panel2.Controls.Count == 2)
            {
                splitContainerMain.SplitterDistance = splitContainerMain.Size.Width/2;
                Browser leftBrowser = splitContainerMain.Panel1.Controls[1] as Browser;
                leftBrowser.SplitterDistance = leftBrowser.Size.Width/3;

                Browser rightBrowser = splitContainerMain.Panel2.Controls[1] as Browser;
                rightBrowser.SplitterDistance = rightBrowser.Size.Width/3;
            }
        }

        private void openBookmarksFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastClickedBrowser.SelectPath(bookmarksFolder, true);  
        }

        private void openOriginalExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string realPath = LastClickedBrowser.GetRealPath();

            Process.Start("explorer.exe", string.Format("/E,{0}", realPath));
        }

        private void openToolFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            LastClickedBrowser.SelectPath(toolsFolder, true);  
        }


        private void loadSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["Comparer"] != null)
            {
                comparerApp = config.AppSettings.Settings["Comparer"].Value;
            }            
            if (config.AppSettings.Settings["Renamer"] != null)
            {
                renamerApp = config.AppSettings.Settings["Renamer"].Value;
            }            
            if (config.AppSettings.Settings["Notepad"] != null)
            {
                notepadApp = config.AppSettings.Settings["Notepad"].Value;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAndSetOptions();
        }

        private void openAndSetOptions()
        {
            FormOptions frm = new FormOptions(comparerApp, renamerApp, notepadApp);
            if(frm.ShowDialog()== DialogResult.OK)
            {
                comparerApp = frm.GetComparer();
                renamerApp = frm.GetRenamer();
                notepadApp = frm.GetNotepad();

                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    
                    if (config.AppSettings.Settings["Comparer"] != null)
                    {
                        config.AppSettings.Settings["Comparer"].Value = comparerApp;
                    }
                    else 
                    { 
                        config.AppSettings.Settings.Add("Comparer", comparerApp);
                    }
                   

                    if (config.AppSettings.Settings["Renamer"] != null)
                    {
                        config.AppSettings.Settings["Renamer"].Value = renamerApp;
                    }
                    else 
                    { 
                        config.AppSettings.Settings.Add("Renamer", renamerApp);
                    }
                 

                    if (config.AppSettings.Settings["Notepad"] != null)
                    {
                        config.AppSettings.Settings["Notepad"].Value = notepadApp;
                    }
                    else 
                    { 
                        config.AppSettings.Settings.Add("Notepad", notepadApp);
                    }
                    
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string leftFolder = browserLeft.GetRealPath();
            string rightFolder = browserRight.GetRealPath();

            try
            {
                Process.Start(comparerApp, string.Format("{0} {1}", leftFolder, rightFolder));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                openAndSetOptions();
            }
        }

        private void renamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lastClickedBrowser != null)
            {
                ListView.SelectedListViewItemCollection items = lastClickedBrowser.fileView.SelectedItems;
                StringBuilder names = new StringBuilder();
                if (items != null)
                {
                    foreach (ListViewItem item in items)
                    {
                        ShellItem si = item.Tag as ShellItem;
                        if (si != null)
                        {
                            names.Append(si.Path);
                            names.Append(" ");
                        }
                    }
                }

                try
                {
                    Process.Start(renamerApp, string.Format("{0}", names.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    openAndSetOptions();
                }
            }
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastClickedBrowser != null)
            {
                ListView.SelectedListViewItemCollection items = lastClickedBrowser.fileView.SelectedItems;
                if (items != null)
                {
                    foreach (ListViewItem item in items)
                    {
                        ShellItem si = item.Tag as ShellItem;
                        if(si!=null)
                        {
                            try
                            {
                                Process.Start(notepadApp, string.Format("{0}", si.Path));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                openAndSetOptions();
                            }
                        }
                    }
                }
            }
        }

        private void newDFBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.ExecutablePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void copyRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rightFolder = browserRight.GetRealPath();

            ListView.SelectedListViewItemCollection items = browserLeft.fileView.SelectedItems;
            if (items != null)
            {
                foreach (ListViewItem item in items)
                {
                    ShellItem si = item.Tag as ShellItem;
                    if (si != null)
                    {
                        try
                        {
                            ShellCopy sc = new ShellCopy();
                            sc.ShellFileCopy(si.Path, string.Format(@"{0}\{1}", rightFolder, si.Text), Handle);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        private void copyLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string leftFolder = browserLeft.GetRealPath();

            ListView.SelectedListViewItemCollection items = browserRight.fileView.SelectedItems;
            if (items != null)
            {
                foreach (ListViewItem item in items)
                {
                    ShellItem si = item.Tag as ShellItem;
                    if (si != null)
                    {
                        try
                        {
                            ShellCopy sc = new ShellCopy();
                            sc.ShellFileCopy(si.Path, string.Format(@"{0}\{1}", leftFolder, si.Text), Handle);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(notepadApp, string.Format("{0}", @"..\..\todo.txt"));
        }

        private void dOSPromptHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastClickedBrowser != null)
            {
                string folder = lastClickedBrowser.GetRealPath();

                Process.Start(cmdApp, "/K CD "+ folder);
            }
        }
    }
}
