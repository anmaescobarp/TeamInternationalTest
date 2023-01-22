using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class TopGunLabsPage : TopGunLabsLocators
    {
        private readonly IWebDriver driver;

        public TopGunLabsPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", TopGunLabsSection());
        }

        public List<string> GetLabels() {
            List<string> optionsText = new List<string>();
            List<IWebElement> topGunOption = TopGunLabsOptions();
            for (int x = 0; x < topGunOption.Count; x++)
            {
                string text = TopGunLabsOptionToGetText(x+1).Text.ToUpper();
                optionsText.Add(text);
            }

            return optionsText;
        }

        public void MouseOverInSeeMoreButton()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(SeeMoreButton()).Perform();
        }

        public string ClickOnSeeMoreButton() 
        {
            SeeMoreButton().Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string textTitle = driver.Title;
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return textTitle;

        }

    }
}
