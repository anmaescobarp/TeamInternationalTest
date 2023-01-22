using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class ItSoftwareServicesLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public ItSoftwareServicesLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement SoftwareServicesSection()
        {
            Thread.Sleep(3000);
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor=\"services\"]")));
        }

        protected List<IWebElement> SoftwareServicesOptions() 
        {
            return driver.FindElements(By.CssSelector(".services-row.g-0>.service-item")).ToList();
        }

        protected IWebElement SoftwareServiceOption(int position)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".services-row.g-0>.service-item:nth-child(" + position + ")")));
        }

        protected IWebElement SoftwareServiceOptionToGetText(int position)
        {
            return SoftwareServicesOptions()[position].FindElement(By.CssSelector(" p:nth-child(1)"));
        }

    }
}
