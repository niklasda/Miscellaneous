using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class ImmutableTests
    {
        [VerifyContract]
        public readonly IContract ImmutabilityTester = new ImmutabilityContract<ImmutablePerson>();
    }
}