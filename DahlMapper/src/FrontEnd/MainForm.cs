using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Netron.Lithium;
namespace FrontEnd
{
	/// <summary>
	/// A simple host to demonstrate the various functions of the Lithium control
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Fields
		private System.Windows.Forms.MenuItem mnuSaveAs;
		private System.Windows.Forms.MenuItem mnuOpen;
        private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuCenterRoot;
		private System.Windows.Forms.MenuItem mnuCollapseAll;
		private System.Windows.Forms.MenuItem mnuExpandAll;
		private System.Windows.Forms.MenuItem mnuForceLayout;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuDash1;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpHelp;
        private System.Windows.Forms.MenuItem mnuDash5;
		private System.Windows.Forms.MenuItem mnuTheNetronProject;
		private System.Windows.Forms.MenuItem mnuDash2;
        private System.Windows.Forms.MenuItem mnuDash3;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.Panel rightPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel mainPanel;
		private Netron.Lithium.LithiumControl lithiumControl;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.TabControl rightTabControl;
        private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.ContextMenu lithiumMenu;
		private System.Windows.Forms.MenuItem cmnuCenterRoot;
		private System.Windows.Forms.MenuItem cmnuNewDiagram;
		private System.Windows.Forms.MenuItem cmnuDash1;
		private System.Windows.Forms.MenuItem cmnuAddChild;
		private System.Windows.Forms.MenuItem cmnuDelete;
		private System.Windows.Forms.MenuItem cmnuDash2;
		private System.Windows.Forms.MenuItem mnuAddChild;
        private System.Windows.Forms.TabPage tabProperties;
		private System.Windows.Forms.MenuItem mnuLayoutDirection;
		private System.Windows.Forms.MenuItem mnuVerticalDirection;
        private System.Windows.Forms.MenuItem mnuHorizontalDirection;

		#endregion
        private MenuItem menuItem2;
        private MenuItem menuItem4;
        private GroupBox groupBox1;
        private Button bRemoveSelected;
        private Button bInsertSibling;
        private Button bInsertParent;
        private Button bAddChild;
        private IContainer components;

		#region construtor
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

//			this.lithiumControl. AddOTM();			

            this.lithiumControl.NewDiagram();

		//	MakeExample();
			this.lithiumControl.Root.Expand();
			this.lithiumControl.DrawTree();
			}

		#endregion

		#region Methods
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuOpen = new System.Windows.Forms.MenuItem();
            this.mnuSaveAs = new System.Windows.Forms.MenuItem();
            this.mnuDash1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuCenterRoot = new System.Windows.Forms.MenuItem();
            this.mnuAddChild = new System.Windows.Forms.MenuItem();
            this.mnuDash3 = new System.Windows.Forms.MenuItem();
            this.mnuCollapseAll = new System.Windows.Forms.MenuItem();
            this.mnuExpandAll = new System.Windows.Forms.MenuItem();
            this.mnuDash2 = new System.Windows.Forms.MenuItem();
            this.mnuForceLayout = new System.Windows.Forms.MenuItem();
            this.mnuLayoutDirection = new System.Windows.Forms.MenuItem();
            this.mnuVerticalDirection = new System.Windows.Forms.MenuItem();
            this.mnuHorizontalDirection = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuHelpHelp = new System.Windows.Forms.MenuItem();
            this.mnuDash5 = new System.Windows.Forms.MenuItem();
            this.mnuTheNetronProject = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightTabControl = new System.Windows.Forms.TabControl();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bRemoveSelected = new System.Windows.Forms.Button();
            this.bInsertSibling = new System.Windows.Forms.Button();
            this.bInsertParent = new System.Windows.Forms.Button();
            this.bAddChild = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lithiumControl = new Netron.Lithium.LithiumControl();
            this.lithiumMenu = new System.Windows.Forms.ContextMenu();
            this.cmnuNewDiagram = new System.Windows.Forms.MenuItem();
            this.cmnuDash1 = new System.Windows.Forms.MenuItem();
            this.cmnuCenterRoot = new System.Windows.Forms.MenuItem();
            this.cmnuAddChild = new System.Windows.Forms.MenuItem();
            this.cmnuDash2 = new System.Windows.Forms.MenuItem();
            this.cmnuDelete = new System.Windows.Forms.MenuItem();
            this.rightPanel.SuspendLayout();
            this.rightTabControl.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.menuItem3,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem4,
            this.mnuOpen,
            this.mnuSaveAs,
            this.mnuDash1,
            this.mnuExit});
            this.mnuFile.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "New map";
            this.menuItem2.Click += new System.EventHandler(this.mnuNewDiagram_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Index = 2;
            this.mnuOpen.Text = "Open map...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Index = 3;
            this.mnuSaveAs.Text = "Save map as...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // mnuDash1
            // 
            this.mnuDash1.Index = 4;
            this.mnuDash1.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 5;
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCenterRoot,
            this.mnuAddChild,
            this.mnuDash3,
            this.mnuCollapseAll,
            this.mnuExpandAll,
            this.mnuDash2,
            this.mnuForceLayout,
            this.mnuLayoutDirection});
            this.menuItem3.Text = "Map";
            // 
            // mnuCenterRoot
            // 
            this.mnuCenterRoot.Index = 0;
            this.mnuCenterRoot.Text = "Center root";
            this.mnuCenterRoot.Click += new System.EventHandler(this.mnuCenterRoot_Click);
            // 
            // mnuAddChild
            // 
            this.mnuAddChild.Index = 1;
            this.mnuAddChild.Text = "Add child";
            this.mnuAddChild.Click += new System.EventHandler(this.mnuAddChild_Click);
            // 
            // mnuDash3
            // 
            this.mnuDash3.Index = 2;
            this.mnuDash3.Text = "-";
            // 
            // mnuCollapseAll
            // 
            this.mnuCollapseAll.Index = 3;
            this.mnuCollapseAll.Text = "Collapse all";
            this.mnuCollapseAll.Click += new System.EventHandler(this.mnuCollapseAll_Click);
            // 
            // mnuExpandAll
            // 
            this.mnuExpandAll.Index = 4;
            this.mnuExpandAll.Text = "Expand all";
            this.mnuExpandAll.Click += new System.EventHandler(this.mnuExpandAll_Click);
            // 
            // mnuDash2
            // 
            this.mnuDash2.Index = 5;
            this.mnuDash2.Text = "-";
            // 
            // mnuForceLayout
            // 
            this.mnuForceLayout.Checked = true;
            this.mnuForceLayout.Index = 6;
            this.mnuForceLayout.Text = "Force layout";
            this.mnuForceLayout.Click += new System.EventHandler(this.mnuForceLayout_Click);
            // 
            // mnuLayoutDirection
            // 
            this.mnuLayoutDirection.Index = 7;
            this.mnuLayoutDirection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuVerticalDirection,
            this.mnuHorizontalDirection});
            this.mnuLayoutDirection.Text = "Layout direction";
            // 
            // mnuVerticalDirection
            // 
            this.mnuVerticalDirection.Index = 0;
            this.mnuVerticalDirection.Text = "Vertical";
            this.mnuVerticalDirection.Click += new System.EventHandler(this.mnuVerticalDirection_Click);
            // 
            // mnuHorizontalDirection
            // 
            this.mnuHorizontalDirection.Checked = true;
            this.mnuHorizontalDirection.Index = 1;
            this.mnuHorizontalDirection.Text = "Horizontal";
            this.mnuHorizontalDirection.Click += new System.EventHandler(this.mnuHorizontalDirection_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 2;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHelpHelp,
            this.mnuDash5,
            this.mnuTheNetronProject});
            this.mnuHelp.Text = "Help";
            // 
            // mnuHelpHelp
            // 
            this.mnuHelpHelp.Index = 0;
            this.mnuHelpHelp.Text = "Lithium Help";
            this.mnuHelpHelp.Click += new System.EventHandler(this.mnuHelpHelp_Click);
            // 
            // mnuDash5
            // 
            this.mnuDash5.Index = 1;
            this.mnuDash5.Text = "-";
            // 
            // mnuTheNetronProject
            // 
            this.mnuTheNetronProject.Index = 2;
            this.mnuTheNetronProject.Text = "The Netron Project";
            this.mnuTheNetronProject.Click += new System.EventHandler(this.mnuTheNetronProject_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 489);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(900, 22);
            this.statusBar.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.rightTabControl);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(700, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(200, 489);
            this.rightPanel.TabIndex = 3;
            // 
            // rightTabControl
            // 
            this.rightTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.rightTabControl.Controls.Add(this.tabProperties);
            this.rightTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTabControl.Location = new System.Drawing.Point(0, 0);
            this.rightTabControl.Name = "rightTabControl";
            this.rightTabControl.SelectedIndex = 0;
            this.rightTabControl.Size = new System.Drawing.Size(200, 489);
            this.rightTabControl.TabIndex = 0;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.groupBox1);
            this.tabProperties.Controls.Add(this.propertyGrid);
            this.tabProperties.Location = new System.Drawing.Point(4, 25);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Size = new System.Drawing.Size(192, 460);
            this.tabProperties.TabIndex = 0;
            this.tabProperties.Text = "Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bRemoveSelected);
            this.groupBox1.Controls.Add(this.bInsertSibling);
            this.groupBox1.Controls.Add(this.bInsertParent);
            this.groupBox1.Controls.Add(this.bAddChild);
            this.groupBox1.Location = new System.Drawing.Point(4, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 226);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // bRemoveSelected
            // 
            this.bRemoveSelected.Location = new System.Drawing.Point(29, 168);
            this.bRemoveSelected.Name = "bRemoveSelected";
            this.bRemoveSelected.Size = new System.Drawing.Size(126, 23);
            this.bRemoveSelected.TabIndex = 7;
            this.bRemoveSelected.Text = "Remove selected";
            this.bRemoveSelected.UseVisualStyleBackColor = true;
            this.bRemoveSelected.Click += new System.EventHandler(this.bRemoveSelected_Click);
            // 
            // bInsertSibling
            // 
            this.bInsertSibling.Location = new System.Drawing.Point(29, 96);
            this.bInsertSibling.Name = "bInsertSibling";
            this.bInsertSibling.Size = new System.Drawing.Size(126, 23);
            this.bInsertSibling.TabIndex = 6;
            this.bInsertSibling.Text = "Insert sibling";
            this.bInsertSibling.UseVisualStyleBackColor = true;
            this.bInsertSibling.Click += new System.EventHandler(this.bInsertSibling_Click);
            // 
            // bInsertParent
            // 
            this.bInsertParent.Location = new System.Drawing.Point(29, 66);
            this.bInsertParent.Name = "bInsertParent";
            this.bInsertParent.Size = new System.Drawing.Size(126, 23);
            this.bInsertParent.TabIndex = 5;
            this.bInsertParent.Text = "Insert Parent";
            this.bInsertParent.UseVisualStyleBackColor = true;
            this.bInsertParent.Click += new System.EventHandler(this.bInsertParent_Click);
            // 
            // bAddChild
            // 
            this.bAddChild.Location = new System.Drawing.Point(29, 36);
            this.bAddChild.Name = "bAddChild";
            this.bAddChild.Size = new System.Drawing.Size(93, 23);
            this.bAddChild.TabIndex = 4;
            this.bAddChild.Text = "Add Child";
            this.bAddChild.UseVisualStyleBackColor = true;
            this.bAddChild.Click += new System.EventHandler(this.bAddChild_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(192, 213);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(697, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 489);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lithiumControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(697, 489);
            this.mainPanel.TabIndex = 5;
            // 
            // lithiumControl
            // 
            this.lithiumControl.AutoScroll = true;
            this.lithiumControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lithiumControl.BranchHeight = 120;
            this.lithiumControl.ConnectionType = Netron.Lithium.ConnectionType.Bezier;
            this.lithiumControl.ContextMenu = this.lithiumMenu;
            this.lithiumControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lithiumControl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lithiumControl.LayoutDirection = Netron.Lithium.TreeDirection.Horizontal;
            this.lithiumControl.LayoutEnabled = true;
            this.lithiumControl.Location = new System.Drawing.Point(0, 0);
            this.lithiumControl.Name = "lithiumControl";
            this.lithiumControl.Size = new System.Drawing.Size(697, 489);
            this.lithiumControl.TabIndex = 3;
            this.lithiumControl.Text = "lithiumControl1";
            this.lithiumControl.WordSpacing = 20;
            this.lithiumControl.Click += new System.EventHandler(this.lithiumControl_Click);
            this.lithiumControl.OnShowProps += new Netron.Lithium.ShowProps(this.lithiumControl_OnShowProps);
            this.lithiumControl.OnNewNode += new Netron.Lithium.ShapeData(this.lithiumControl_OnNewNode);
            this.lithiumControl.OnDeleteNode += new Netron.Lithium.ShapeData(this.lithiumControl_OnDeleteNode);
            // 
            // lithiumMenu
            // 
            this.lithiumMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmnuNewDiagram,
            this.cmnuDash1,
            this.cmnuCenterRoot,
            this.cmnuAddChild,
            this.cmnuDash2,
            this.cmnuDelete});
            // 
            // cmnuNewDiagram
            // 
            this.cmnuNewDiagram.Index = 0;
            this.cmnuNewDiagram.Text = "New diagram";
            this.cmnuNewDiagram.Click += new System.EventHandler(this.mnuNewDiagram_Click);
            // 
            // cmnuDash1
            // 
            this.cmnuDash1.Index = 1;
            this.cmnuDash1.Text = "-";
            // 
            // cmnuCenterRoot
            // 
            this.cmnuCenterRoot.Index = 2;
            this.cmnuCenterRoot.Text = "Center root";
            this.cmnuCenterRoot.Click += new System.EventHandler(this.mnuCenterRoot_Click);
            // 
            // cmnuAddChild
            // 
            this.cmnuAddChild.Index = 3;
            this.cmnuAddChild.Text = "Add child";
            this.cmnuAddChild.Click += new System.EventHandler(this.mnuAddChild_Click);
            // 
            // cmnuDash2
            // 
            this.cmnuDash2.Index = 4;
            this.cmnuDash2.Text = "-";
            // 
            // cmnuDelete
            // 
            this.cmnuDelete.Index = 5;
            this.cmnuDelete.Text = "Delete";
            this.cmnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(900, 511);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DahlMap v1.0";
            this.rightPanel.ResumeLayout(false);
            this.rightTabControl.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Makes a simple demo diagram (not scientifically correct)
		/// </summary>
        //private void MakeExample()
        //{
        //    this.lithiumControl.Root.Text = "Ecosystem";
        //    ShapeBase root = this.lithiumControl.Root;

        //    ShapeBase ert = root.AddChild("Earth");
        //    ShapeBase com = root.AddChild("Community");
			
        //    ShapeBase pop = com.AddChild("Population");
        //    ShapeBase org = com.AddChild("Organism");
        //    ShapeBase bac = com.AddChild("Bacteria");
        //    ShapeBase vir = com.AddChild("Virus");
			
        //    com.Expand();

        //    ShapeBase euk = bac.AddChild("Eukaryotes");
        //    ShapeBase arch = bac.AddChild("Archea");
        //    ShapeBase pro = euk.AddChild("Protista");
        //    ShapeBase fla = pro.AddChild("Flagellates");
        //    ShapeBase amo = pro.AddChild("Amoeba");
        //    ShapeBase alg = pro.AddChild("Algae");
        //    ShapeBase par = pro.AddChild("Parasites");


        //    ShapeBase anim = pop.AddChild("Animals");
        //    ShapeBase pla = pop.AddChild("Plants");
        //    ShapeBase ins = pop.AddChild("Insects");
			
        //    ShapeBase ant = ins.AddChild("Ants");

        //    ShapeBase mus = pop.AddChild("Mushrooms");
			

        //    //re-order and center a bit to please the eyes
        //    root.Move(new Point(20-root.X, Convert.ToInt32(this.lithiumControl.Height/2)-root.Y));
        //    bac.Collapse(true);

        //    //as well as some coloring
        ////	this.mnuColorLevels_Click(null, EventArgs.Empty);
        //    colorLevels();

        //}

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

		#region Menu handlers

		#region Open/save
		/// <summary>
		/// Menu handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			OpenDiagram();
		}
		/// <summary>
		/// Menu handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveDiagram();			
		}
		/// <summary>
		/// Opens a diagram
		/// </summary>
		private void OpenDiagram()
		{
			OpenFileDialog fileChooser= new OpenFileDialog();
			fileChooser.Filter = "Diagram file (*.gxl)|*.gxl";
			DialogResult result =fileChooser.ShowDialog();
			string filename;			
			if(result==DialogResult.Cancel) return;
			filename=fileChooser.FileName;
	//		if (filename=="" || filename==null)
	//			MessageBox.Show("Invalid file name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	//		else
	//		{
				this.lithiumControl.OpenGraph(filename);
	//			MessageBox.Show("Project opened from '" + filename + "'");
	//		}
			this.lithiumControl.CenterRoot();

		}

		/// <summary>
		/// Saves a diagram
		/// </summary>
		private void SaveDiagram()
		{
			SaveFileDialog fileChooser=new SaveFileDialog();
			fileChooser.Filter = "Diagram file (*.gxl)|*.gxl";
			DialogResult result =fileChooser.ShowDialog();
			string filename;
			fileChooser.CheckFileExists=false;
			if(result==DialogResult.Cancel) return;
			filename=fileChooser.FileName;
	//		if (filename=="" || filename==null)
	//			MessageBox.Show("Invalid file name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	//		else
	//		{
				this.lithiumControl.SaveGraphAs(filename);				
				//MessageBox.Show("The diagram was saved to '" + filename  + "'","Diagram saved",MessageBoxButtons.OK,MessageBoxIcon.Information);

	//		}
		}
		#endregion

		private void mnuLayout_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.DrawTree();
		}

		private void mnuAddRandom_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.AddRandomNode();
		}

		private void mnuShift_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.MoveDiagram(new Point(20,0));
		}
		
		private void mnuCenterRoot_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.CenterRoot();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			DialogResult res = MessageBox.Show(this, "Save before exit?", "Save diagram", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if(res==DialogResult.Cancel)
				return;
			if(res==DialogResult.Yes)
			{
				SaveDiagram();
			}
			Application.Exit();
		}
		
		private void mnuNewDiagram_Click(object sender, System.EventArgs e)
		{
			DialogResult res = MessageBox.Show(this, "Save before exit?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if(res==DialogResult.Cancel)
				return;
			if(res==DialogResult.Yes)
			{
				SaveDiagram();
			}
			this.lithiumControl.NewDiagram();
			
		}

		private void mnuRandomDiagram_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.NewDiagram();

			int graphSize = 20; //a few thousand nodes still works fine if you have enough RAM
			for(int k=0; k<graphSize; k++)
			{
				this.lithiumControl.AddRandomNode("Node " + k);
			}

		}

		private void mnuCollapseAll_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.CollapseAll();
		}

		private void mnuForceLayout_Click(object sender, System.EventArgs e)
		{
			mnuForceLayout.Checked = !mnuForceLayout.Checked;
			lithiumControl.LayoutEnabled = mnuForceLayout.Checked;

		}

		private void mnuDelete_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.Delete();
		}

		private void mnuAddChild_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.AddChild();
            colorLevels();
		}

		private void mnuExpandAll_Click(object sender, System.EventArgs e)
		{
			this.lithiumControl.ExpandAll();
		}
		
		private void mnuHelpHelp_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://netron.sourceforge.net/ewiki/netron.php?id=LithiumControl");
		}

		private void mnuGotoGraphLib_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://netron.sourceforge.net/ewiki/netron.php?id=NetronGraphLib");
		}

		private void mnuGotoNetronLight_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://www.codeproject.com/cs/miscctrl/NetronLight.asp");
		}

		private void mnuTheNetronProject_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://netron.sf.net");
		}

		private void mnuHorizontalDirection_Click(object sender, System.EventArgs e)
		{
			if(mnuHorizontalDirection.Checked) return	;	
			mnuVerticalDirection.Checked = false;
			mnuHorizontalDirection.Checked = true;
			CheckDirection();
		}
		private void mnuVerticalDirection_Click(object sender, System.EventArgs e)
		{
				if(mnuVerticalDirection.Checked) return;		
			mnuVerticalDirection.Checked = true;
			mnuHorizontalDirection.Checked = false;
			CheckDirection();
		}


		#region Examples of the visitor interface
		private void mnuColorLevels_Click(object sender, System.EventArgs e)
		{
			
			Output("");
			Output("Breadth first traversal of the diagram and coloring of levels.");

            colorLevels();
			

		}

        private void colorLevels()
        {
            ColoringVisitor visitor = new ColoringVisitor();
            lithiumControl.BreadthFirstTraversal(visitor);
        }

		private void mnuDFTInfo_Click(object sender, System.EventArgs e)
		{
			Output("");
			Output("Depth first traversal of the diagram.");
			Output("----------------");
			InfoVisitor visitor = new InfoVisitor();
			visitor.OnInfo+=new Messager(visitor_OnInfo);
			lithiumControl.DepthFirstTraversal(visitor);
			Output("----------------");
		}
		
		private void mnuXMLExport_Click(object sender, System.EventArgs e)
		{
			Output("");
			Output("XML output example using the PrePost visitor interface.");
			Output("Copy/paste the XML to file and edit in browser or an XML-editor to view the tree-like structure");
			Output("----------------");
			XmlVisitor visitor = new XmlVisitor();
			visitor.OnInfo+=new Messager(visitor_OnInfo);
			lithiumControl.DepthFirstTraversal(visitor);
			Output("----------------");
		}
		private void mnuBFTInfo_Click(object sender, System.EventArgs e)
		{
			Output("");
			Output("Breadth first traversal of the diagram.");
			Output("----------------");
			InfoVisitor visitor = new InfoVisitor();
			visitor.OnInfo+=new Messager(visitor_OnInfo);
			lithiumControl.BreadthFirstTraversal(visitor);
			Output("----------------");
		}

		#endregion

		#endregion

		#region Diverse event handlers
		/// <summary>
		/// Occurse when a visitor sends out some info
		/// </summary>
		/// <param name="message"></param>
		private void visitor_OnInfo(string message)
		{
			Output(message);
		}


		/// <summary>
		/// Changes the layout direction
		/// </summary>
		private void CheckDirection()
		{
			if(mnuHorizontalDirection.Checked)
				this.lithiumControl.LayoutDirection = TreeDirection.Horizontal;
			else
				this.lithiumControl.LayoutDirection = TreeDirection.Vertical;
		}

		/// <summary>
		/// Occurs when the lithium control broadcasts info
		/// </summary>
		/// <param name="ent"></param>
		private void lithiumControl_OnShowProps(object ent)
		{
			ShowProps(ent);
		}
		/// <summary>
		/// Occurs when some properties have to be shown
		/// </summary>
		/// <param name="obj"></param>
		private void ShowProps(object obj)
		{
			this.propertyGrid.SelectedObject = obj;
			rightTabControl.SelectedTab = tabProperties;
		}
		/// <summary>
		/// Generic output to the output box
		/// </summary>
		/// <param name="text"></param>
		private void Output(string text)
		{
		//	this.outputBox.Text += text + Environment.NewLine;
		//	//move down to the new postioning so things stay in view
		//	this.outputBox.SelectionLength = this.outputBox.Text.Length;
		//	this.outputBox.ScrollToCaret();
		//	rightTabControl.SelectedTab = tabOutput;
		}


		/// <summary>
		/// Occurs when a new node is added to the diagram
		/// </summary>
		/// <param name="shape"></param>
		private void lithiumControl_OnNewNode(Netron.Lithium.ShapeBase shape)
		{
			Output("New node: " + shape.Text);
            colorLevels();
		}
		/// <summary>
		/// Occurs when a node is removed from the diagram
		/// </summary>
		/// <param name="shape"></param>
		private void lithiumControl_OnDeleteNode(Netron.Lithium.ShapeBase shape)
		{
			Output("Shape '"  + shape.Text +"' deleted");
		}

		#endregion

        //private void mnuClassReference_Click(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Lithium.chm");
        //    }
        //    catch
        //    {
        //        MessageBox.Show("The 'Lithium.chm' ships with this application but was not found in its original location.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

		

		
		#endregion

        private void lithiumControl_Click(object sender, EventArgs e)
        {

            colorLevels();

        }

        private void bAddChild_Click(object sender, EventArgs e)
        {
            
            this.lithiumControl.AddChild();
            colorLevels();
        }

        private void bInsertParent_Click(object sender, EventArgs e)
        {
            this.lithiumControl.InsertParent();
            colorLevels();

        }

        private void bInsertSibling_Click(object sender, EventArgs e)
        {
            this.lithiumControl.AddSibling();
            colorLevels();

        }

        private void bRemoveSelected_Click(object sender, EventArgs e)
        {
            this.lithiumControl.Delete();
            colorLevels();

        }


	}
}
