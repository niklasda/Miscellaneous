using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Custom;

namespace Clz.Logic
{
    [ControlTypeMapping(CustomUIItemType.Pane)]
    internal class PaneItem : CustomUIItem
    {
        public PaneItem(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, actionListener)
        {
        }

        protected PaneItem()
        {
        }
    }
}