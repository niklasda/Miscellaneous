using System;
using System.Reflection;
using System.Windows.Forms;
using MbUnitWinForms.Exceptions;

namespace MbUnitWinForms.Testers.New
{
    /// <summary>
    /// A variation of the MbUnitForms ToolStripMenuItemTester that has a new ctor
    /// </summary>
    public class ToolStripMenuItemTester2 : ToolStripMenuItemTester
    {
        readonly private ToolStripMenuItem _item;

        public ToolStripMenuItemTester2(string name, Form form)
            : base(name, form)
        {
        }

        public ToolStripMenuItemTester2(string name, string formName)
            : base(name, formName)
        {
        }

        public ToolStripMenuItemTester2(string name)
            : base(name)
        {
        }

        public ToolStripMenuItemTester2(ToolStripMenuItem item)
            : base(string.Empty)
        {
            _item = item;
        }

        /// <summary>
        /// Access underlying control
        /// </summary>
        public new ToolStripMenuItem Properties
        {
            get { return _item; }
        }

        ///<summary>
        /// The label of the tool strip item.
        ///</summary>
        public override string Text
        {
            get { return _item.Text; }
        }

        /// <summary>
        /// Get all Drop Down Items for the current Tool Strip
        /// </summary>
        public ToolStripItemCollection SubItems
        {
            get
            {
                if (_item != null)
                {
                    return _item.DropDownItems;
                }

                ToolStripMenuItem mmu = base.Properties;
                if (mmu == null)
                    throw new NoSuchControlException(name);

                return mmu.DropDownItems;
            }
        }

        /// <summary>
        /// returns the number of items - either 1 or zero - eg. an Exists
        /// </summary>
        public new int Count
        {
            get { return (_item != null) ? 1 : 0; }
        }

        /// <summary>
        /// Click/invoke the Tool Strip
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