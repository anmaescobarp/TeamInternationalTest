using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class ItSoftwareServicesPage : ItSoftwareServicesLocators
    {
        private readonly IWebDriver driver;

        public ItSoftwareServicesPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", SoftwareServicesSection());
        }

        public List<string> GetLabels() {
            List<string> labelsText = new();
            List<IWebElement> softwareServicesOptions = SoftwareServicesOptions();
            for (int x = 0; x < softwareServicesOptions.Count-1; x++)
            {
                string Optiontext = SoftwareServiceOptionToGetText(x).Text.Replace("\r\n", " ");
                labelsText.Add(Optiontext);
            }

            return labelsText;
        }

        public List<string> ClickOnEverySmallSection() {
            List<string> pageTitlesOfOptions = new();
            List<IWebElement> softwareServicesOptions = SoftwareServicesOptions();

            for (int x = 1; x < softwareServicesOptions.Count; x++)
            {
                IWebElement softwareServiceOption = SoftwareServiceOption(x);
                softwareServiceOption.Click();
                string textTitle = driver.Title;
                pageTitlesOfOptions.Add(textTitle);
                driver.Navigate().Back();
                ScrollToSection();
            }

            return pageTitlesOfOptions;

        }

        public void MouseOverEverySmallSection()
        {
            Actions action = new(driver);
            List<IWebElement> softwareServicesOptions = SoftwareServicesOptions();
            for (int x = 1; x < softwareServicesOptions.Count; x++)
            {
                IWebElement softwareServiceOption = SoftwareServiceOption(x);
                action.MoveToElement(softwareServiceOption).Perform();
            }

        }
    }
}
