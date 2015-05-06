using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ClassLibrary1.News
{
    public class ArgsStuff
    {
        



        public string MyMethod(string name, int age = 30)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "name must not be null, empth or only white spaces");
            }

            return string.Format("Name:{0} Age:{1}", name, age);
        }





        public string TestDynamicStuff()
        {
            dynamic ns = new ArgsStuff();
            string tag = ns.MyNewMethodWithAnyArgs(age: 35, name: "Niklas");
            return tag;
        }





        [ImportMany(typeof(MyPart))]
        private IEnumerable<Lazy<MyPart>> subParts;

        public int MefStuff()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddPart(this);
            container.Compose(batch);

            int count = 0;
            foreach (var subPart in subParts)
            {
                count++;
                MyPart part = subPart.Value;
            }

            return count;
        }

    }

    [Export(typeof(MyPart))]
    public class MyPart
    {
        public readonly string Name;

        public MyPart()
        {
            Name = "Niklas";
        }
    }
}
