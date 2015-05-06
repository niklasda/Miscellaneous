using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class ListTests
    {
        [VerifyContract]
        public readonly IContract ListTester = new ListContract<PersonCollection, IPerson>
             {
                 AcceptEqualItems = true,
                 AcceptNullReference = true,
                 IsReadOnly = false,
                 DistinctInstances = 
                     {
                         new Person("a", 1),
                         new Person("b", 2),
                         new Person("c", 3),
                         new Person("d", 4),
                         new Person("e", 5) 
                     }
             };
    }

}
