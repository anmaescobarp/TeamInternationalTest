using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class SolutionsForIndustryLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public SolutionsForIndustryLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected List<IWebElement> SolutionForIndustrialOptions() 
        {
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("section.active .industrial-row.g-0>.industrial-item"))).ToList();
        }

        protected IWebElement SolutionForIndustryOption(int position)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".industrial-row.g-0>.industrial-item:nth-child(" + position + ")")));
        }

        protected IWebElement SolutionForIndustryOptionToGetText(IWebElement optionElement) 
        {
            return optionElement.FindElement(By.CssSelector(" h3"));
        }
    }
}
