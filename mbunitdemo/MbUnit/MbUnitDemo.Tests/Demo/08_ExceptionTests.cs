using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class ExceptionTests
    {
        [VerifyContract]
        public readonly IContract AgeExceptionTester = 
            new ExceptionContract<AgeException>
                {
                    // Optional (default is true)
                    ImplementsSerialization = false,
                    // Optional (default is true)
                    ImplementsStandardConstructors = true 
                };
    }
}