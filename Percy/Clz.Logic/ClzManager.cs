using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Automation;
using AutoPercy.Logic;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.TreeItems;
using White.Core.UIItems.WindowItems;

namespace Clz.Logic
{
    public class ClzManager
    {
        private static ClzManager _instance;
        private Application _clz;
        private IDictionary<string, string> _appSettings;

        private ClzManager()
        {
        }

        public IDictionary<string, string> AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    var appSettings = ConfigurationManager.AppSettings;

                    _appSettings = new Dictionary<string, string>(3);
                    _appSettings.Add("Clz.Path", appSettings.Get("Clz.Path"));
                    _appSettings.Add("Clz.Exe", appSettings.Get("Clz.Exe"));
                }

                return _appSettings;
            }
        }

        public static ClzManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClzManager();
                }

                return _instance;
            }
        }

        public void StartApp()
        {
            string folder = AppSettings["Clz.Path"];
            string exe = AppSettings["Clz.Exe"];

            string path = Path.Combine(folder, exe);

            _clz = Application.Launch(path);
        }

        private Window getWindowByTitleMatch(string title)
        {
            var windows = _clz.GetWindows();
            foreach (var window in windows)
            {
                if(window.Title.StartsWith(title))
                {
                    return window;
                }
            }

            return null;
        }

        public void OpenBookOne(string lang)
        {
            var mainWindow = getWindowByTitleMatch("Collectorz.com Book Collector");

            var tree = mainWindow.Get<Tree>(SearchCriteria.ByControlType(ControlType.Tree).AndIndex(0));
            tree.Nodes[0].Click();

            var treeNode = tree.SelectedNode;
            foreach (TreeNode node in treeNode.Nodes)
            {
                if(node.Text.StartsWith("Svenska"))
                {
                    node.DoubleClick();
                }
            }
        }

        public void EditNextBook()
        {
            var window = getWindowByTitleMatch("Edit Book:");
            var box = window.Get<Button>(SearchCriteria.ByText("Next"));
            box.Click();
        }

        public void SearchForCoverOnCurrent()
        {
            var window = getWindowByTitleMatch("Edit Book:");
            var page = window.Get<TabPage>(SearchCriteria.ByText("Covers"));
            page.Click();

            var box = window.Get<Button>(SearchCriteria.ByText("Find Online"));
            box.Click();
        }

        public void GoogleCurrent()
        {
            var window = getWindowByTitleMatch("Edit Book:");

            string wtitle = window.Title;
            string t2 = wtitle.Substring(11, wtitle.Length - 11);

            int lastDash = t2.LastIndexOf(" - ");
            string author = t2.Substring(lastDash+3, t2.Length - lastDash-3);
            string title = t2.Substring(0, lastDash);

            PercyManager.Instance.PercyTitle(author, title);
        }
    }
}
