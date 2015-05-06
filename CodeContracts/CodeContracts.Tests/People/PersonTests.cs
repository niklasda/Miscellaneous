using System.Diagnostics.Contracts;
using CodeContracts.People;
using CodeContracts.People.Exceptions;
using CodeContracts.Tests.People.EventHandler;
using MbUnit.Framework;

namespace CodeContracts.Tests.People
{
	public class PersonTests
	{
		[Test]
        [ExpectedException(typeof(ContractViolationException))]
        public void TestCtorAgeContract()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;
            
            var p = new Person("name", 0);
			Assert.IsNotNull(p);
		}

		[Test]
        [ExpectedException(typeof(ContractViolationException))]
        public void TestCtorNameContract()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;
            
            var p = new Person(getName(), 10);
            Assert.IsNotNull(p);
        }

		private string getName()
		{
			Contract.Ensures(Contract.Result<string>() == null);
			return this.GetType().ToString();
		}

		[Test]
		public void TestCtorLegal()
		{
			var p = new Person("name", 23);
			Assert.AreEqual("name", p.Name);
			Assert.AreEqual(23, p.Age);
		}

		[Test]
        [ExpectedException(typeof(ContractViolationException))]
        public void TestCtorInvariant()
		{
            Contract.ContractFailed += ContractFailed.Contract_ContractFailed;
            
            var p = new Person("name", 223);
			Assert.AreEqual("name", p.Name);
			Assert.AreEqual(223, p.Age);
		}
	}
}