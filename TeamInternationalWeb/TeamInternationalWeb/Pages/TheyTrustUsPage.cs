using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class TheyTrustUsPage : TheyTrustUsLocators
    {
        private readonly IWebDriver driver;

        public TheyTrustUsPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", TheyTrustUsSection());
        }

        public void MouseOverEverySmallSection()
        {
            Actions action = new Actions(driver);
            List<IWebElement> theyTrustUsOptions = TheyTrustUsOptions();
            for (int x = 0; x < theyTrustUsOptions.Count; x++)
            {
                IWebElement option = TheyTrustUsOption(x+1);
                action.MoveToElement(option).Perform();
            }

        }
    }
}
