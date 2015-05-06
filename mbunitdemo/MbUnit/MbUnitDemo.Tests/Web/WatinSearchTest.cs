using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;
using MbUnitDemo.Tests.Web.FX;
using MbUnitDemo.Tests.Web.Pages;

namespace MbUnitDemo.Tests.Web
{
    [TestFixture]
    [Category(Categories.Watin)]
    public class WatinSearchTest : BrowserTestFixture
    {
        [Test]
        [Browser(BrowserType.IE)]
        public void FailedSearchResultsInCapture()
        {
            Browser.BringToFront();

            GoogleSearchPage.GoTo(Browser);

            Browser.Page<GoogleSearchPage>().Search("Gallio");

            Assert.Fail("Cause the test to fail for demonstration purposes.");
        }
    }
}