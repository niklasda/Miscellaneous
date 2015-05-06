using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class EquatableTest
    {
        [VerifyContract]
        public readonly IContract EqualityTester = new EqualityContract<EquatablePerson>
           {
               ImplementsOperatorOverloads = false, // Optional (default is true)
               // Tests only on age
               EquivalenceClasses =
                   {
                       { new EquatablePerson("a", 1), new EquatablePerson("a", 1) },
                       { new EquatablePerson("b", 2), new EquatablePerson("bb", 2) },
                       { new EquatablePerson("c", 3), new EquatablePerson("c", 3) },
                       { new EquatablePerson("d", 4), new EquatablePerson("d", 4) },
                       { new EquatablePerson("e", 5), new EquatablePerson("e", 5) }
                   }
           };    
    }
}