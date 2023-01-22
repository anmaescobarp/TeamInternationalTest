using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class TopGunLabsLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public TopGunLabsLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement TopGunLabsSection()
        {
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor=\"education\"]")));
        }

        protected List<IWebElement> TopGunLabsOptions() 
        {
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("section[data-anchor=\"education\"] div.slick-track>div"))).ToList();
        }

        private IWebElement TopGunLabsOption(int position)
        {
            return driver.FindElement(By.CssSelector("section[data-anchor=\"education\"] div.slick-track>div:nth-child("+ position +")"));
        }

        protected IWebElement TopGunLabsOptionToGetText(int position)
        {
            return TopGunLabsOption(position).FindElement(By.CssSelector(" h4"));
        }

        protected IWebElement SeeMoreButton() 
        {
            return driver.FindElement(By.CssSelector("section[data-anchor=\"education\"] a.bnr-career-link"));
        }
    
    }
}
