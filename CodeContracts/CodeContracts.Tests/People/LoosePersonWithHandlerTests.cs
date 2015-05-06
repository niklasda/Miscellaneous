using CodeContracts.People;
using CodeContracts.People.Exceptions;
using CodeContracts.Tests.People.EventHandler;
using System.Diagnostics.Contracts;
using MbUnit.Framework;

namespace CodeContracts.Tests.People
{
	public class LoosePersonWithHandlerTests
	{
        
		[Test]
        [ExpectedException(typeof(ContractViolationException))]
		public void TestCtorAgeContract()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;

            var p = new LoosePersonWithHandler("name", 0);
            Assert.IsNotNull(p);
		}

		[Test]
        [ExpectedException(typeof(ContractViolationException))]
        public void TestCtorNameContract()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;

			var p = new LoosePersonWithHandler(null, 10);
            Assert.IsNotNull(p);
        }

		[Test]
		public void TestCtorLegal()
		{
			var p = new LoosePersonWithHandler("name", 23);
			Assert.AreEqual("name", p.Name);
			Assert.AreEqual(23, p.Age);
		}

		[Test]
		public void TestCtorTooLarge()
		{
			var p = new LoosePersonWithHandler("name", 223);
			Assert.AreEqual("name", p.Name);
			Assert.AreEqual(223, p.Age);
		}
	}
}