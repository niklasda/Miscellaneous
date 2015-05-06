using System;
using System.Collections.Generic;

namespace XceedBoll
{
    public class NotifyingList<T> : List<T>
    {
        public event EventHandler<EventArgs> ItemAdded;

        public new void Add(T rd)
        {
            base.Add(rd);

            if (ItemAdded != null)
            {
                ItemAdded(this, EventArgs.Empty);
            }
        }
    }
}