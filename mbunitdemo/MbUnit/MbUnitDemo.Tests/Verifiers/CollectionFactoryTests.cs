using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Factories)]
    public class CollectionFactoryTests<[Factory(typeof(Factories.MyFactory), "TypeGen")] T>
        where T : IPerson, new()
    {
        [VerifyContract]
        public readonly IContract CollectionTester = new CollectionContract<PersonCollection, IPerson>
        {
            AcceptEqualItems = true,
            AcceptNullReference = true,
            IsReadOnly = false,
            DistinctInstances = 
               {
                   new T { Name = "a", Age = 1 },
                   new T { Name = "b", Age = 2 },
                   new T { Name = "c", Age = 3 },
                   new T { Name = "d", Age = 4 },
                   new T { Name = "e", Age = 5 } 
               }
        };


    }
}