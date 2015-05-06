using WatiN.Core;

namespace MbUnitDemo.Tests.Web.Pages
{
    /// <summary>
    /// The Google search page.
    /// </summary>
    [Page(UrlRegex = "http://www.google.com/.*")]
    public class GoogleSearchPage : Page
    {
        [FindBy(Name = "q")]
        public TextField QueryTextField;

        [FindBy(Name = "btnG")]
        public Button SearchButton;

        [FindBy(Name = "btnI")]
        public Button ImFeelingLuckyButton;

        public static void GoTo(Browser browser)
        {
            browser.BringToFront();
            browser.GoTo("http://www.google.com");
        }

        public void Search(string query)
        {
            QueryTextField.TypeText(query);
            SearchButton.Click();
        }
    }
}