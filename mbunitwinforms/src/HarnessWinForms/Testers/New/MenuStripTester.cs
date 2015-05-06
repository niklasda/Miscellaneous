using System;
using System.Windows.Forms;
using MbUnitWinForms.Exceptions;

namespace MbUnitWinForms.Testers.New
{
    public class MenuStripTester : ControlTester<MenuStrip, MenuStripTester>
    {
        public MenuStripTester(string name, string formName)
            : base(name, formName)
        {
        }

        public MenuStripTester(string name, Form form)
            : base(name, form)
        {
        }

        public MenuStripTester(string name)
            : base(name)
        {
        }

        public MenuStripTester(ControlTester<MenuStrip, MenuStripTester> tester, int index)
            : base(tester, index)
        {
        }

        public MenuStripTester()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the menu item
        /// </summary>
        public ToolStripItemCollection MenuItems
        {
            get
            {
                MenuStrip mmu = base.Properties;
                if (mmu == null)
                    throw new NoSuchControlException(name);

                return mmu.Items;
            }
        }

        /// <summary>
        /// GetItemByPosition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="subrow"></param>
        /// <returns></returns>
        public ToolStripMenuItem GetItemByPosition(int column, int row, int subrow)
        {
            var menu = (ToolStripMenuItem) MenuItems[column];
            ToolStripItem item = menu.DropDownItems[row];
            var menuItem = item as ToolStripMenuItem;
            if (menuItem != null)
            {
                ToolStripItem subItem = menuItem.DropDownItems[subrow];
                var subMenuItem = subItem as ToolStripMenuItem;
                return subMenuItem;
            }
            return menuItem;
        }

        /// <summary>
        /// Search For Item in the menu
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        public ToolStripMenuItem SearchForItem(string caption)
        {
            return searchForItemInternal(MenuItems, caption);
        }

        private ToolStripMenuItem searchForItemInternal(ToolStripItemCollection menuItems, string caption)
        {
            caption = caption.Replace("&", "");
            foreach (ToolStripItem item in menuItems)
            {
                var menuItem = item as ToolStripMenuItem;

                if (menuItem == null)
                {
                    continue;
                }

                if (menuItem.Text.Replace("&", "").Equals(caption))
                {
                    return menuItem;
                }

                ToolStripMenuItem found = searchForItemInternal(menuItem.DropDownItems, caption);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}