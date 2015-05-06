using System.Globalization;
using Gallio.Framework;
using MbUnit.Framework;

namespace MbUnitDemo.Tests.Ordering
{
    public class MultipleCulturesTests
    {
        [Test]
        [MultipleCulture("sv-SE", "en-US")]
        public void RepeatedCultureOrder1Demo()
        {
            TestLog.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName);

            Assert.IsTrue(true);
        }
    }
}