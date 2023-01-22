using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Security;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TeamInternationalWeb.Elements;
using static System.Net.Mime.MediaTypeNames;


namespace Pages
{
    public class LocationsPage : LocationsLocators
    {
        private readonly IWebDriver driver;

        public LocationsPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", LocationsSection());
        }

        public List<string> GetLabels() {
            List<string> labelsText = new List<string>();
            List<IWebElement> locationsOptions = LocationsOptions();
            for (int x = 0; x < locationsOptions.Count; x++)
            {
                string Optiontext = LocationOptionToGetText().Text.ToUpper();
                labelsText.Add(Optiontext);
                ArrowBtnNext().Click();
            }

            return labelsText;
        }

        public void MouseOverEverySmallSection()
        {
            Actions action = new(driver);
            List<IWebElement> locationsOptions = LocationsOptions();
            for (int x = 0; x < locationsOptions.Count; x++)
            {
                IWebElement locationOption = LearnMoreButtonOfCurrentLocation();
                action.MoveToElement(locationOption).Perform();
                ArrowBtnNext().Click();
            }

        }

        public List<string> ClickOnEverySmallSection() {
            List<string> pageTitles = new();
            List<IWebElement> locationsOptions = LocationsOptions();

            for (int x = 0; x < locationsOptions.Count; x++)
            {
                FindDesiredLocation(x+1);
                LearnMoreButtonOfCurrentLocation().Click();
                string textTitle = driver.Url;
                pageTitles.Add(textTitle);
                driver.Navigate().Back();
                ScrollToSection();
            }
           
            return pageTitles;

        }


    }
}
