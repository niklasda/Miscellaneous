using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SizeMan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormSizeMan : System.Windows.Forms.Form
	{
		#region gui
		private System.Windows.Forms.TreeView tvSizeTree;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mmiFile;
		private System.Windows.Forms.MenuItem miStart;
		private System.Windows.Forms.MenuItem miStop;
		private System.Windows.Forms.MenuItem mmiHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem miMakeTree;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.StatusBar sbCount;
		private System.Windows.Forms.StatusBarPanel sbpCount;
		private System.Windows.Forms.ListView lvFiles;
		private System.Windows.Forms.ColumnHeader chFileName;
		private System.Windows.Forms.ColumnHeader chSize;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBarPanel sbpFileCount;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miEnum;
		private System.Windows.Forms.MenuItem mmiTree;
		private System.Windows.Forms.MenuItem miTreeCount;
		private System.Windows.Forms.MenuItem miShowRight;
		private System.Windows.Forms.MenuItem mmiList;
		private System.Windows.Forms.MenuItem miListCount;
		private System.Windows.Forms.MenuItem miListOpen;

		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormSizeMan()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tvSizeTree = new System.Windows.Forms.TreeView();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mmiFile = new System.Windows.Forms.MenuItem();
			this.miStart = new System.Windows.Forms.MenuItem();
			this.miStop = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miMakeTree = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miEnum = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.mmiHelp = new System.Windows.Forms.MenuItem();
			this.miAbout = new System.Windows.Forms.MenuItem();
			this.lvFiles = new System.Windows.Forms.ListView();
			this.chFileName = new System.Windows.Forms.ColumnHeader();
			this.chSize = new System.Windows.Forms.ColumnHeader();
			this.sbCount = new System.Windows.Forms.StatusBar();
			this.sbpCount = new System.Windows.Forms.StatusBarPanel();
			this.sbpFileCount = new System.Windows.Forms.StatusBarPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.mmiTree = new System.Windows.Forms.MenuItem();
			this.miTreeCount = new System.Windows.Forms.MenuItem();
			this.miShowRight = new System.Windows.Forms.MenuItem();
			this.mmiList = new System.Windows.Forms.MenuItem();
			this.miListCount = new System.Windows.Forms.MenuItem();
			this.miListOpen = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFileCount)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvSizeTree
			// 
			this.tvSizeTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvSizeTree.ImageIndex = -1;
			this.tvSizeTree.Location = new System.Drawing.Point(0, 0);
			this.tvSizeTree.Name = "tvSizeTree";
			this.tvSizeTree.SelectedImageIndex = -1;
			this.tvSizeTree.Size = new System.Drawing.Size(216, 329);
			this.tvSizeTree.Sorted = true;
			this.tvSizeTree.TabIndex = 0;
			this.tvSizeTree.DoubleClick += new System.EventHandler(this.tvSizeTree_DoubleClick);
			this.tvSizeTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSizeTree_AfterSelect);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mmiFile,
																					  this.mmiHelp,
																					  this.mmiTree,
																					  this.mmiList});
			// 
			// mmiFile
			// 
			this.mmiFile.Index = 0;
			this.mmiFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miStart,
																					this.miStop,
																					this.menuItem2,
																					this.miMakeTree,
																					this.menuItem1,
																					this.miEnum,
																					this.menuItem4,
																					this.miExit});
			this.mmiFile.Text = "File";
			// 
			// miStart
			// 
			this.miStart.Index = 0;
			this.miStart.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.miStart.Text = "Start...";
			this.miStart.Click += new System.EventHandler(this.miStart_Click);
			// 
			// miStop
			// 
			this.miStop.Index = 1;
			this.miStop.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.miStop.Text = "Stop...";
			this.miStop.Click += new System.EventHandler(this.miStop_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// miMakeTree
			// 
			this.miMakeTree.Enabled = false;
			this.miMakeTree.Index = 3;
			this.miMakeTree.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
			this.miMakeTree.Text = "Make tree";
			this.miMakeTree.Click += new System.EventHandler(this.miMakeTree_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// miEnum
			// 
			this.miEnum.Index = 5;
			this.miEnum.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
			this.miEnum.Text = "Enumerate drives";
			this.miEnum.Click += new System.EventHandler(this.miEnum_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 6;
			this.menuItem4.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 7;
			this.miExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.miExit.Text = "Exit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// mmiHelp
			// 
			this.mmiHelp.Index = 1;
			this.mmiHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miAbout});
			this.mmiHelp.Text = "Help";
			// 
			// miAbout
			// 
			this.miAbout.Index = 0;
			this.miAbout.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.miAbout.Text = "About";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// lvFiles
			// 
			this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.chFileName,
																					  this.chSize});
			this.lvFiles.FullRowSelect = true;
			this.lvFiles.GridLines = true;
			this.lvFiles.Location = new System.Drawing.Point(0, 0);
			this.lvFiles.Name = "lvFiles";
			this.lvFiles.Size = new System.Drawing.Size(520, 312);
			this.lvFiles.TabIndex = 2;
			this.lvFiles.View = System.Windows.Forms.View.Details;
			// 
			// chFileName
			// 
			this.chFileName.Text = "Name";
			this.chFileName.Width = 295;
			// 
			// chSize
			// 
			this.chSize.Text = "Size";
			this.chSize.Width = 76;
			// 
			// sbCount
			// 
			this.sbCount.Location = new System.Drawing.Point(216, 307);
			this.sbCount.Name = "sbCount";
			this.sbCount.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					   this.sbpCount,
																					   this.sbpFileCount});
			this.sbCount.ShowPanels = true;
			this.sbCount.Size = new System.Drawing.Size(520, 22);
			this.sbCount.TabIndex = 3;
			// 
			// sbpCount
			// 
			this.sbpCount.Text = "Dir#";
			this.sbpCount.Width = 140;
			// 
			// sbpFileCount
			// 
			this.sbpFileCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpFileCount.Text = "File#";
			this.sbpFileCount.Width = 364;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvFiles);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(216, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(520, 307);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(216, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 307);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// mmiTree
			// 
			this.mmiTree.Index = 2;
			this.mmiTree.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miTreeCount,
																					this.miShowRight});
			this.mmiTree.Text = "Tree";
			// 
			// miTreeCount
			// 
			this.miTreeCount.Index = 0;
			this.miTreeCount.Text = "Count";
			// 
			// miShowRight
			// 
			this.miShowRight.Index = 1;
			this.miShowRight.Text = "Show right";
			// 
			// mmiList
			// 
			this.mmiList.Index = 3;
			this.mmiList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miListCount,
																					this.miListOpen});
			this.mmiList.Text = "List";
			// 
			// miListCount
			// 
			this.miListCount.Index = 0;
			this.miListCount.Text = "Count";
			// 
			// miListOpen
			// 
			this.miListOpen.Index = 1;
			this.miListOpen.Text = "Open";
			// 
			// frmSizeMan
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 329);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.sbCount);
			this.Controls.Add(this.tvSizeTree);
			this.Menu = this.mainMenu1;
			this.Name = "frmSizeMan";
			this.Text = "FileSizeTree";
			this.Load += new System.EventHandler(this.frmSizeMan_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFileCount)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.EnableVisualStyles();
				Application.Run(new FormSizeMan());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private bool bStopped = false;
		private string sStartDir = @"C:\";
		private static long iCount = 0;

		private TreeNode calculateNode(string sBaseDir)
		{
			TreeNode oNode = new TreeNode(sBaseDir);
			oNode.Tag = 0;
			try
			{
				DirectoryInfo oInfo = new DirectoryInfo(sBaseDir +@"\");

				DirectoryInfo[] arInfo = oInfo.GetDirectories();

				iCount++;
				sbpCount.Text = "Dir#: "+ iCount.ToString();
				Application.DoEvents();

				if(!bStopped && arInfo.Length>0)
				{
					foreach(DirectoryInfo oInnerInfo in arInfo)
					{
						TreeNode oChildNode = calculateNode(oInnerInfo.FullName);
						
						
						long iSize = long.Parse(oChildNode.Tag.ToString());
						oNode.Tag = long.Parse(oNode.Tag.ToString())+iSize;
						// TODO: add formatting
						oChildNode.Text = oInnerInfo.FullName +" ["+ iSize.ToString() +"] ";
						
						oNode.Nodes.Add( oChildNode );
					}
				}
				else if(!bStopped && arInfo.Length==0)
				{
					FileInfo[] arFileInfos = oInfo.GetFiles();
					
					long iFileSizeSum=0;
					foreach(FileInfo oInnerFileInfo in arFileInfos)
					{
						iFileSizeSum += oInnerFileInfo.Length;
					}
					// TODO: add formatting
					oNode.Text = sBaseDir +" ["+ iFileSizeSum.ToString() +"] ";
					oNode.Tag = iFileSizeSum;
				}
			}
			catch(Exception ex)
			{
				oNode.Nodes.Add(ex.Message);
			}
			return oNode;
		}

		private void miStart_Click(object sender, System.EventArgs e)
		{
			iCount = 0;
			bStopped = false;
			lvFiles.Items.Clear();
			tvSizeTree.Nodes.Clear();

			TreeNode oRootNode = tvSizeTree.Nodes.Add( "root" );
			TreeNode oNode = calculateNode(sStartDir);
			
			long iSize = long.Parse(oNode.Tag.ToString());

			oNode.Text = sStartDir +" ["+ iSize.ToString() +"] ";
			oRootNode.Nodes.Add( oNode );

			oRootNode.Expand();
		}

		private void miStop_Click(object sender, System.EventArgs e)
		{
			bStopped = true;
		}

		private void miMakeTree_Click(object sender, System.EventArgs e)
		{
//			iCount = 0;
//			bStopped = false;
//			lvFiles.Items.Clear();
//			tvSizeTree.Nodes.Clear();
//
//			TreeNode oRootNode = tvSizeTree.Nodes.Add("root");
//			TreeNode oNode = calculateNode(sStartDir, false);
//			
//			long iSize = long.Parse(oNode.Tag.ToString());
//
//			oNode.Text = sStartDir;
//			oRootNode.Nodes.Add(oNode);
//
//			oRootNode.Expand();	
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Hej");
		}

		private void tvSizeTree_DoubleClick(object sender, System.EventArgs e)
		{
			if(tvSizeTree.SelectedNode!=null)
			{
				TreeNode oNode = tvSizeTree.SelectedNode;
				showFilesInFolder(oNode.FullPath, true);
			}
		}

		private void showFilesInFolder(string sFile, bool bRecurse)
		{
			int iFileCount = 0;
			lvFiles.Items.Clear();
			sbpFileCount.Text = "File#: "+ iFileCount;
			
			try
			{
				DirectoryInfo oInfo = new DirectoryInfo(sFile +@"\");
				if(oInfo.Exists)
				{
					lvFiles.BeginUpdate();

					DirectoryInfo[] arDirInfos = oInfo.GetDirectories();
					foreach(DirectoryInfo oDirInfo in arDirInfos)
					{
						ListViewItem oItem = lvFiles.Items.Add(oDirInfo.Name);
						if(bRecurse)
						{
							TreeNode oNode = calculateNode(oDirInfo.FullName);
							long iSize = long.Parse(oNode.Tag.ToString());
							oItem.SubItems.Add("F "+ (iSize/1024).ToString() +" KB");
						}
						else
						{
							oItem.SubItems.Add("Folder");
						}
					}

					FileInfo[] arFileInfos = oInfo.GetFiles();
					foreach(FileInfo oFileInfo in arFileInfos)
					{
						ListViewItem oItem = lvFiles.Items.Add(oFileInfo.Name);
						oItem.SubItems.Add((oFileInfo.Length/1024).ToString() +" KB");
						iFileCount++;
						sbpFileCount.Text = "File#: "+ iFileCount;
					}

					lvFiles.EndUpdate();
				}
				else
				{
					ListViewItem oItem = lvFiles.Items.Add("Missing "+ sFile);
					oItem.SubItems.Add("");
				}
			}
			catch(Exception ex)
			{
				ListViewItem oItem = lvFiles.Items.Add(ex.Message);
				oItem.SubItems.Add("");
			}
		}

		private void tvSizeTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			expandFolderNode(e.Node);
			showFilesInFolder(e.Node.FullPath, false);
			Cursor.Current = Cursors.Default;
		}

		private void expandFolderNode(TreeNode oNode)
		{
			string sFile = oNode.FullPath;

			try
			{
				DirectoryInfo oInfo = new DirectoryInfo(sFile +@"\");
				if(oInfo.Exists)
				{
					DirectoryInfo[] arDirInfos = oInfo.GetDirectories();
			
					oNode.Nodes.Clear();
					tvSizeTree.BeginUpdate();
					foreach(DirectoryInfo oDirInfo in arDirInfos)
					{
						oNode.Nodes.Add(oDirInfo.Name);
					}
					tvSizeTree.EndUpdate();
					oNode.Expand();
				}
			}
			catch//(Exception ex)
			{
				//oNode.Nodes.Add(ex.Message);
			}
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void miEnum_Click(object sender, System.EventArgs e)
		{
			enumDrives();
		}

		private void enumDrives()
		{
			string[] arDrives = Directory.GetLogicalDrives();

			tvSizeTree.Nodes.Clear();
			foreach(string sDrive in arDrives)
			{
				tvSizeTree.Nodes.Add(sDrive);
			}
		}

		private void frmSizeMan_Load(object sender, System.EventArgs e)
		{
			enumDrives();		
		}

	}
}
