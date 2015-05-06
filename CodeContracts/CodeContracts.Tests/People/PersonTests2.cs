using System.Diagnostics.Contracts;
using CodeContracts.People;
using CodeContracts.People.Exceptions;
using CodeContracts.Tests.People.EventHandler;
using MbUnit.Framework;

namespace CodeContracts.Tests.People
{
	public class PersonTests2
	{
		[Test]
        [ExpectedException(typeof(ContractViolationException))]
        public void TestPersonInvariant()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;

			var p = new Person("niklas", 23);

			Assert.AreEqual("niklas", p.Name);
			Assert.AreEqual(23, p.Age);

			p.Age = 200;
//			Assert.AreEqual(200, p.Age);
		}

		[Test]
		[ExpectedException(typeof(ContractViolationException))]
		public void TestPersonAgeSetter()
		{
			Contract.ContractFailed += ContractFailed.Contract_ContractFailed;

			var p = new Person("niklas", 23);

			Assert.AreEqual("niklas", p.Name);
			Assert.AreEqual(23, p.Age);

			p.Age = 2123;
		}

	}
}