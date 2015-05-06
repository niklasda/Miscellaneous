using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class ExceptionTests
    {
        [VerifyContract]
        public readonly IContract AgeExceptionTester = new ExceptionContract<AgeException>
            {
                ImplementsSerialization = false,       // Optional (default is true)
                ImplementsStandardConstructors = true  // Optional (default is true)
            };
    }
}