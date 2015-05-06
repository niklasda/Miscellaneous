using System;
using System.Reflection;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    public class ToolStripItemTester2 : ToolStripItemTester<ToolStripItem, ToolStripItemTester2>
    {
        readonly private ToolStripItem _item;

        public ToolStripItemTester2(string name, Form form) : base(name, form)
        {
        }

        public ToolStripItemTester2(string name, string formName) : base(name, formName)
        {
        }

        public ToolStripItemTester2(string name) : base(name)
        {
        }

        public ToolStripItemTester2(ToolStripItemTester<ToolStripItem, ToolStripItemTester2> tester, int index)
            : base(tester, index)
        {
        }

        public ToolStripItemTester2(ToolStripItem item)
            : base(string.Empty)
        {
            _item = item;
        }

        /// <summary>
        /// empty ctor
        /// </summary>
        public ToolStripItemTester2()
        {
        }

        /// <summary>
        /// return the number of Tool Strips
        /// </summary>
        public new int Count
        {
            get
            {
                if (_item != null)
                    return 1;
                return 0;
            }
        }

        /// <summary>
        /// Click on the ToolStrip
        /// </summary>
        public override void Click()
        {
            MethodInfo mi = _item.GetType().GetMethod("OnClick",
                                                      BindingFlags.NonPublic | BindingFlags.Public |
                                                      BindingFlags.Instance);
            mi.Invoke(_item, new object[] {EventArgs.Empty});
        }
    }
}