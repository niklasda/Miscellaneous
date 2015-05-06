using System;
using System.Windows.Forms;
using MbUnitWinForms.Exceptions;

namespace MbUnitWinForms.Testers.New
{
    /// <summary>
    /// class to handle the ToolsStrip (like Menu Items) Information
    /// </summary>
    public class ToolStripTester : ControlTester<ToolStrip, ToolStripTester>
    {
        public ToolStripTester(string name, string formName)
            : base(name, formName)
        {
        }

        public ToolStripTester(string name, Form form)
            : base(name, form)
        {
        }

        public ToolStripTester(string name)
            : base(name)
        {
        }

        public ToolStripTester(ControlTester<ToolStrip, ToolStripTester> tester, int index)
            : base(tester, index)
        {
        }

        public ToolStripTester()
        {
        }

        /// <summary>
        /// Get all tool Items
        /// </summary>
        public ToolStripItemCollection ToolItems
        {
            get
            {
                ToolStrip mmu = base.Properties;
                if (mmu == null)
                    throw new NoSuchControlException(name);

                return mmu.Items;
            }
        }

        /// <summary>
        /// Search for an item using caption
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        public ToolStripItem SearchForItem(string caption)
        {
            caption = caption.Replace("&", "");
            foreach (ToolStripItem item in ToolItems)
            {
                if (item.Text.Replace("&", "").Equals(caption))
                {
                    return item;
                }
            }
            return null;
        }
    }
}