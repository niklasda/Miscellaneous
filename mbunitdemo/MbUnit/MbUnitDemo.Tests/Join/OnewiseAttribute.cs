using System;
using System.Collections.Generic;
using Gallio.Framework.Data;
using Gallio.Framework.Pattern;
using MbUnit.Framework;

namespace MbUnitDemo.Tests.Join
{
    [AttributeUsage(PatternAttributeTargets.Test, AllowMultiple = false, Inherited = true)]
    public class OnewiseJoinAttribute : JoinAttribute
    {
        /// <inheritdoc />
        protected override IJoinStrategy GetJoinStrategy()
        {
            return OnewiseJoinStrategy.Instance;
        }
    }

    public class OnewiseJoinStrategy : IJoinStrategy
    {
        private static IJoinStrategy strategy;
        public static IJoinStrategy Instance
        {
            get
            {
                if (strategy == null)
                {
                    strategy = new OnewiseJoinStrategy();
                }
                return strategy;
            }
        }

        public IEnumerable<IList<IDataItem>> Join(IList<IDataProvider> providers, IList<ICollection<DataBinding>> bindingsPerProvider, bool includeDynamicItems)
        {
            IDataProvider provider = providers[0];
            ICollection<DataBinding> bindings = bindingsPerProvider[0];
            IEnumerable<IDataItem> enumerable = provider.GetItems(bindings, includeDynamicItems);

            foreach (IDataItem dataItem in enumerable) // the values 0, 1 in this case
            {
                foreach (DataBinding binding in bindings) // parameters to bind to 'a' in this case
                {
                    ScalarDataItem<object> ival = (ScalarDataItem<object>)dataItem;
                    object value = ival.GetValue(binding); // these value should be in the list below
                }
            }

            IList<IList<IDataItem>> enumList = new List<IList<IDataItem>>();
            IList<IDataItem> list = new List<IDataItem>();

            IDictionary<string, string> meta = new Dictionary<string, string>();

            IList<int> values = new List<int>();
            values.Add(5);

            IDataItem item = new ListDataItem<int>(values, meta, false);

            list.Add(item);
            enumList.Add(list);

            return enumList;
        }
    }
}