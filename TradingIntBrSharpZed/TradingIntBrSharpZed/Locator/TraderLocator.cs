using StructureMap;
using StructureMap.Graph;

namespace IBHelper.Locator
{
    public class TraderLocator
    {
        public static IContainer Initialize()
        {
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });

                //_.For<IFoo>().Use<Foo>();
                // _.For<IBar>().Use<Bar>();
            });

            return container;
        } 
    }
}