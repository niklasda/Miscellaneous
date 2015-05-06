// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteropTester.cs" company="Saxo Bank A/S">
//   Tlb Tester
// </copyright>
// <summary>
//   Defines the InteropTester type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ComFinder;

namespace ComLister
{
    /// <summary>
    /// Interop Tester Form
    /// </summary>
    public partial class ComListerForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteropTester"/> class.
        /// </summary>
        public ComListerForm()
        {
            InitializeComponent();
        }

        private const string dependencyWalkrtPath = @"..\..\..\refs\DependencyWalker\depends.exe";
        private const string whosLockingPath = @"..\..\..\refs\WhosLocking\WhoSLocking.exe";

        private IList<ComInfo> _latestList;

        private void showTheList(IList<ComInfo> list)
        {
            var sortedList = new SortedList<string, ComInfo>();
            foreach (var info in list)
            {
                if (string.IsNullOrEmpty(info.Caption))
                {
                    info.Caption = "<nullorempty>";
                }

                if (sortedList.ContainsKey(info.Caption))
                {
                    sortedList.Add(info.Caption + info.ComponentId, info);
                }
                else
                {
                    sortedList.Add(info.Caption, info);
                }
            }

            gridComs.Rows.Clear();
            gridComs.Columns.Clear();

            //gridComs.Columns.Add("AppID", "AppID");
            gridComs.Columns.Add("Caption", "Caption");
            //gridComs.Columns.Add("ComponentId", "ComponentId");
            gridComs.Columns.Add("Description", "Description");
            gridComs.Columns.Add("InProcServer32", "InProcServer32");
            gridComs.Columns.Add("LocalServer32", "LocalServer32");
            gridComs.Columns.Add("ProgId", "ProgId");
            gridComs.Columns.Add("ThreadingModel", "ThreadingModel");
            // gridComs.Columns.Add("TypeLibraryId", "TypeLibraryId");
            gridComs.Columns.Add("Version", "Version");
            //  gridComs.Columns.Add("VersionIdependentProgId", "VersionIdependentProgId");

            foreach (var info in list)
            {
                int index = gridComs.Rows.Add(
                    //    info.AppID, 
                    info.Caption,
                    //   info.ComponentId, 
                    info.Description,
                    info.InprocServer32,
                    info.LocalServer32,
                    info.ProgId,
                    info.ThreadingModel,
                    //   info.TypeLibraryId, 
                    info.Version);
                //   info.VersionIndependentProgId);
                gridComs.Rows[index].Tag = info;
            }

            lblCount.Text = "#: " + list.Count;
        }

        private void printSelected(ComInfo info)
        {
            txtInteropLog.Clear();
            if (info != null)
            {
                txtInteropLog.AppendText("AppID: " + info.AppID + Environment.NewLine);
                txtInteropLog.AppendText("Caption: " + info.Caption + Environment.NewLine);
                txtInteropLog.AppendText("ComponentId: " + info.ComponentId + Environment.NewLine);
                txtInteropLog.AppendText("Description: " + info.Description + Environment.NewLine);
                txtInteropLog.AppendText("InprocServer32: " + info.InprocServer32 + Environment.NewLine);
                txtInteropLog.AppendText("LocalServer32: " + info.LocalServer32 + Environment.NewLine);
                txtInteropLog.AppendText("ProgId: " + info.ProgId + Environment.NewLine);
                txtInteropLog.AppendText("ThreadingModel: " + info.ThreadingModel + Environment.NewLine);
                txtInteropLog.AppendText("TypeLibraryId: " + info.TypeLibraryId + Environment.NewLine);
                txtInteropLog.AppendText("Version: " + info.Version + Environment.NewLine);
                txtInteropLog.AppendText("VersionIndependentProgId: " + info.VersionIndependentProgId + Environment.NewLine);

                string file = findAPath(info, true, true);
                if (File.Exists(file))
                {
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(file);
                    txtInteropLog.AppendText("File version: " + fvi.FileVersion);
                }
                else
                {
                    txtInteropLog.AppendText("File not found: " + file);
                }
            }
        }

        private void gridComs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ComInfo info = getSelectedCom();
            printSelected(info);
        }

        private void gridComs_SelectionChanged(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            printSelected(info);
        }

        private ComInfo getSelectedCom()
        {
            if (gridComs.SelectedCells.Count == 1)
            {
                ComInfo info = (ComInfo)gridComs.Rows[gridComs.SelectedCells[0].RowIndex].Tag;
                return info;
            }

            if (gridComs.SelectedRows.Count == 1)
            {
                ComInfo info = (ComInfo)gridComs.SelectedRows[0].Tag;
                return info;
            }

            return null;
        }

        private string findAPath(ComInfo info, bool useLocal, bool useInProc)
        {
            string filePath = string.Empty;
            if (!string.IsNullOrEmpty(info.InprocServer32) && useInProc)
            {
                filePath = info.InprocServer32;
            }
            else if (!string.IsNullOrEmpty(info.LocalServer32) && useLocal)
            {
                filePath = info.LocalServer32;
            }

            filePath = Environment.ExpandEnvironmentVariables(filePath);

            if (filePath.LastIndexOf("\"") > 0 && filePath.Length > (filePath.LastIndexOf("\"") + 1))
            {
                int pos = filePath.LastIndexOf("\"");
                filePath = filePath.Substring(0, pos);
            }

            return filePath;
        }

        private void startProc(string file, string args)
        {
            try
            {
                Process.Start(file, args);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                txtInteropLog.Text = ex.ToString();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            IList<ComInfo> list = new List<ComInfo>();
            string filter = txtFilter.Text;
            if (_latestList != null)
            {
                foreach (ComInfo info in _latestList)
                {
                    if (info.Caption.ToLower().Contains(filter.ToLower()))
                    {
                        list.Add(info);
                    }
                }
            }

            showTheList(list);
        }

        private void btnHideSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (_latestList != null)
            {
                if (btnHideSystem.Checked)
                {
                    IList<ComInfo> list = new List<ComInfo>();
                    string filter = txtFilter.Text;
                    foreach (ComInfo info in _latestList)
                    {
                        bool skip = false;
                        if (
                            info.InprocServer32 != null &&
                            (info.InprocServer32.ToLower().Contains("windows")
                             || info.InprocServer32.ToLower().Contains("microsoft")
                             || info.InprocServer32.ToLower().Contains("micros~")
                             || info.InprocServer32.ToLower().Contains(@"common files\system")
                             || info.InprocServer32.ToLower().Contains(@"common~1\system")
                             || !info.InprocServer32.Contains(":")
                            /*|| info.InprocServer32.ToLower().Contains("%systemroot%")*/)
                            )
                        {
                            skip = true;
                        }

                        if (
                            info.LocalServer32 != null &&
                            (info.LocalServer32.ToLower().Contains("windows")
                             || info.LocalServer32.ToLower().Contains("microsoft")
                             || info.LocalServer32.ToLower().Contains("micros~")
                             || info.LocalServer32.ToLower().Contains(@"common files\system")
                             || info.LocalServer32.ToLower().Contains(@"common~1\system")
                             || !info.LocalServer32.Contains(":")
                            /*|| info.LocalServer32.ToLower().Contains("%systemroot%")*/)
                            )
                        {
                            skip = true;
                        }

                        if (string.IsNullOrEmpty(info.LocalServer32) && string.IsNullOrEmpty(info.InprocServer32))
                        {
                            skip = true;
                        }

                        if (!skip)
                        {
                            list.Add(info);
                        }
                    }

                    showTheList(list);
                }
                else
                {
                    showTheList(_latestList);
                }
            }
        }

        private void listCOMObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComFind find = new ComFind();
            txtInteropLog.Clear();
            var list = find.GetCom();
            _latestList = list;

            showTheList(list);
        }

        private void listCOMPlusObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComFind find = new ComFind();
            txtInteropLog.Clear();
            var list = find.GetComPlus();
            _latestList = list;
            showTheList(list);
        }

        private void openLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, true);

                startProc("explorer.exe", "/e,/select," + filePath);
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, true);

                startProc("regsvr32.exe", "\"" + filePath + "\"");
            }
        }

        private void unregisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, true);

                startProc("regsvr32.exe", "/u \"" + filePath + "\"");
            }
        }

        private void showDependenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, true);
                if (!filePath.Contains(":"))
                {
                    filePath = @"%SystemRoot%\System32\" + filePath;
                    filePath = Environment.ExpandEnvironmentVariables(filePath);
                }

                startProc(dependencyWalkrtPath, "\"" + filePath + "\"");
            }
        }

        private void showWhosLockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, true);

                startProc(whosLockingPath, "\"" + filePath + "\"");
            }
        }

        private void startDependencyWalkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startProc(dependencyWalkrtPath, "");
        }

        private void startWhoslockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startProc(whosLockingPath, "");
        }

        private void openSystemRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "%SystemRoot%";
            filePath = Environment.ExpandEnvironmentVariables(filePath);

            startProc("explorer.exe", "/e," + filePath);
        }

        private void openLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, true, false);

                startProc("explorer.exe", "/e,/select," + filePath);
            }
        }

        private void openInProcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComInfo info = getSelectedCom();
            if (info != null)
            {
                string filePath = findAPath(info, false, true);

                startProc("explorer.exe", "/e,/select," + filePath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void variableExpanderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariableExpanderForm form = new VariableExpanderForm();
            form.Show(this);
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnFilter.Select();
                btnFilter_Click(sender, EventArgs.Empty);
            }
        }
    }
}
