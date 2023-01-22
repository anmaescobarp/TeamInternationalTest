using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class EmpowerCareerLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public EmpowerCareerLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement EmpowerCareerSection()
        {
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor=\"career\"]")));
        }

        protected IWebElement SeeAllOffersButton() 
        {
            return driver.FindElement(By.CssSelector("section[data-anchor=\"career\"] a.bnr-career-link"));
        }
    
    }
}
