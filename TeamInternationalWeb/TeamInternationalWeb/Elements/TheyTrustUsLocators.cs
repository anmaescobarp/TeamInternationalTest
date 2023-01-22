using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class TheyTrustUsLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public TheyTrustUsLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement TheyTrustUsSection()
        {
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor=\"clients\"]")));
        }

        protected List<IWebElement> TheyTrustUsOptions() 
        {
            return driver.FindElements(By.CssSelector("section[data-anchor=\"clients\"] div[id]")).ToList();
        }

        protected IWebElement TheyTrustUsOption(int position)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("section[data-anchor='clients'] div[id]:nth-child("+ position+")")));
        }

    }
}
