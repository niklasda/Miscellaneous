using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;
using MbUnitDemo.Tests.Web.FX;
using MbUnitDemo.Tests.Web.Pages;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [Category(Categories.Watin)]
    public class WatinSearchTest : BrowserTestFixture
    {
        [Test]
        [Browser(BrowserType.IE)]
        public void FailedSearchResultsInCapture()
        {
            GoogleSearchPage.GoTo(Browser);
            Browser.Page<GoogleSearchPage>().Search("Gallio");

            Assert.Fail("Fail for demonstration purposes.");
        }
    }
}