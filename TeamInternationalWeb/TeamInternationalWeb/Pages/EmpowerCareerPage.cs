using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class EmpowerCareerPage : EmpowerCareerLocators
    {
        private readonly IWebDriver driver;

        public EmpowerCareerPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", EmpowerCareerSection());
        }

        public void MouseOverInSeeAllOffersButton()
        {
            Actions action = new(driver);
            action.MoveToElement(SeeAllOffersButton()).Perform();
        }

        public string ClickOnSeeAllOffersButton() 
        {
            SeeAllOffersButton().Click();
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            string textTitle = driver.Title;
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return textTitle;
        }

    }
}
