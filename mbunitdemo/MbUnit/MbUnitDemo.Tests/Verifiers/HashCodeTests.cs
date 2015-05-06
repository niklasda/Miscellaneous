using System;
using System.Collections.Generic;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class HashCodeTest
    {
        [VerifyContract]
        public readonly IContract HashCodeTester = new HashCodeAcceptanceContract<EquatablePerson>()
          {
              CollisionProbabilityLimit = CollisionProbability.Low,
              UniformDistributionQuality = UniformDistributionQuality.Good,
              DistinctInstances = generateInstances()
              //DistinctInstances = new[] { new EquatablePerson("Niklas", 37) }
          };

        private static IEnumerable<EquatablePerson> generateInstances()
        {
            for (int i = -30000; i < 20000; i++)
                for (int j = -10000; j < 30000; j++)
                yield return new EquatablePerson("Niklas", i+j);
        }
    }
}