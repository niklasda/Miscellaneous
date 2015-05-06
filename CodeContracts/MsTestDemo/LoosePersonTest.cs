using System.Linq;
using CodeContracts.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestDemo
{
    [TestClass]
    public class LooseersonTest
    {
		[TestMethod]
		public void TestLegacyPerson()
		{
			var p = new LoosePerson(null, 32);
			Assert.IsNotNull(p);
		}
    }
}
