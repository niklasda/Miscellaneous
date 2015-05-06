using CodeContracts.People;
using MbUnit.Framework;

namespace CodeContracts.Tests.People
{
	public class LoosePersonTests
	{
		[Test]
		public void TestPersonBoom()
		{
			var p = new LoosePerson("name", 0);
            Assert.IsNotNull(p);
        }

	}
}