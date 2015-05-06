using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class ComparableTests
    {
        [VerifyContract]
        public readonly IContract ComparableTester = new ComparisonContract<ComparablePerson>
         {
             ImplementsOperatorOverloads = false, // Optional (default is true)
             // EquivalenceClasses must be in ascending order
             // ComparablePerson compares only age
             EquivalenceClasses =
                 {
                     { new ComparablePerson("a", 1), new ComparablePerson("a", 1) },
                     { new ComparablePerson("b", 2), new ComparablePerson("bb", 2) },
                      new ComparablePerson("c", 3) ,
                      new ComparablePerson("d", 4) ,
                      new ComparablePerson("e", 5) 
                 }
         };
    }
}