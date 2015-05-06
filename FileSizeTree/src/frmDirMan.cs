using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SizeMan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmSizeMan : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tcUnitests;
		private System.Windows.Forms.TabPage tpUnicode;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.TextBox txtStartDir;
		private System.Windows.Forms.TreeView tvSizeTree;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label lblStartDir;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Label lblFuture;
		#region gui

		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public frmSizeMan()
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
			this.tcUnitests = new System.Windows.Forms.TabControl();
			this.tpUnicode = new System.Windows.Forms.TabPage();
			this.lblCount = new System.Windows.Forms.Label();
			this.btnStop = new System.Windows.Forms.Button();
			this.lblStartDir = new System.Windows.Forms.Label();
			this.txtStartDir = new System.Windows.Forms.TextBox();
			this.btnGo = new System.Windows.Forms.Button();
			this.tvSizeTree = new System.Windows.Forms.TreeView();
			this.lblFuture = new System.Windows.Forms.Label();
			this.tcUnitests.SuspendLayout();
			this.tpUnicode.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcUnitests
			// 
			this.tcUnitests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tcUnitests.Controls.Add(this.tpUnicode);
			this.tcUnitests.Location = new System.Drawing.Point(8, 16);
			this.tcUnitests.Name = "tcUnitests";
			this.tcUnitests.SelectedIndex = 0;
			this.tcUnitests.Size = new System.Drawing.Size(528, 368);
			this.tcUnitests.TabIndex = 0;
			// 
			// tpUnicode
			// 
			this.tpUnicode.Controls.Add(this.lblFuture);
			this.tpUnicode.Controls.Add(this.lblCount);
			this.tpUnicode.Controls.Add(this.btnStop);
			this.tpUnicode.Controls.Add(this.lblStartDir);
			this.tpUnicode.Controls.Add(this.txtStartDir);
			this.tpUnicode.Controls.Add(this.btnGo);
			this.tpUnicode.Controls.Add(this.tvSizeTree);
			this.tpUnicode.Location = new System.Drawing.Point(4, 22);
			this.tpUnicode.Name = "tpUnicode";
			this.tpUnicode.Size = new System.Drawing.Size(520, 342);
			this.tpUnicode.TabIndex = 0;
			this.tpUnicode.Text = "FileSizeTree";
			// 
			// lblCount
			// 
			this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCount.Location = new System.Drawing.Point(376, 199);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(104, 23);
			this.lblCount.TabIndex = 5;
			this.lblCount.Text = "0";
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnStop.Location = new System.Drawing.Point(440, 295);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(64, 23);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// lblStartDir
			// 
			this.lblStartDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStartDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblStartDir.Location = new System.Drawing.Point(376, 239);
			this.lblStartDir.Name = "lblStartDir";
			this.lblStartDir.TabIndex = 4;
			this.lblStartDir.Text = "StartDir:";
			// 
			// txtStartDir
			// 
			this.txtStartDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStartDir.Location = new System.Drawing.Point(376, 263);
			this.txtStartDir.Name = "txtStartDir";
			this.txtStartDir.Size = new System.Drawing.Size(128, 20);
			this.txtStartDir.TabIndex = 2;
			this.txtStartDir.Text = "C:\\Program Files";
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGo.Location = new System.Drawing.Point(376, 295);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(56, 23);
			this.btnGo.TabIndex = 0;
			this.btnGo.Text = "Go";
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// tvSizeTree
			// 
			this.tvSizeTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tvSizeTree.ImageIndex = -1;
			this.tvSizeTree.Location = new System.Drawing.Point(16, 16);
			this.tvSizeTree.Name = "tvSizeTree";
			this.tvSizeTree.SelectedImageIndex = -1;
			this.tvSizeTree.Size = new System.Drawing.Size(344, 311);
			this.tvSizeTree.Sorted = true;
			this.tvSizeTree.TabIndex = 0;
			// 
			// lblFuture
			// 
			this.lblFuture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFuture.Location = new System.Drawing.Point(376, 32);
			this.lblFuture.Name = "lblFuture";
			this.lblFuture.Size = new System.Drawing.Size(128, 128);
			this.lblFuture.TabIndex = 6;
			this.lblFuture.Text = "Det vore ju bättre att ladda ett katalogträd och sedan välja var man vill räkna f" +
				"ram storlekarna. Och visa kb eller Mb i stället för bytes.";
			// 
			// frmSizeMan
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 397);
			this.Controls.Add(this.tcUnitests);
			this.Name = "frmSizeMan";
			this.Text = "FileSizeTree";
			this.tcUnitests.ResumeLayout(false);
			this.tpUnicode.ResumeLayout(false);
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
				Application.Run(new frmSizeMan());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

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
				lblCount.Text = "Dir#: "+ iCount.ToString();
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
//				MessageBox.Show(ex.ToString());
			}
			return oNode;
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			bStopped = false;
			tvSizeTree.Nodes.Clear();

			TreeNode oRootNode = tvSizeTree.Nodes.Add( "root" );
			TreeNode oNode = calculateNode(txtStartDir.Text);
			
			long iSize = long.Parse(oNode.Tag.ToString());

			oNode.Text = txtStartDir.Text +" ["+ iSize.ToString() +"] ";
			oRootNode.Nodes.Add( oNode );

			oRootNode.Expand();
		}

		private bool bStopped = false;

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			bStopped = true;
		}

	}
}
