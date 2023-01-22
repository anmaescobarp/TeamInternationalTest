using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class LocationsLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public LocationsLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement LocationsSection()
        {
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor='locations']")));
        }

        protected List<IWebElement> LocationsOptions() 
        {
            
            List<IWebElement> locationOptions = driver.FindElements(By.CssSelector("section[data-anchor='locations'] div[class='location-item slick-slide']")).ToList();
            locationOptions.Add(driver.FindElement(By.CssSelector("div.slick-current.slick-active.slick-center")));
            return locationOptions;
        }

        protected IWebElement LocationActiveOption()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("section[data-anchor='locations'] .slick-slide.slick-active")));
        }

        protected IWebElement LocationOptionToGetText()
        {
            return LocationActiveOption().FindElement(By.CssSelector(" h3"));
        }

        protected IWebElement LearnMoreButtonOfCurrentLocation()
        {
            Thread.Sleep(1000);
            return LocationActiveOption().FindElement(By.CssSelector(" .btn.btn-green"));
        }

        protected IWebElement ArrowBtnNext() 
        {
            Thread.Sleep(2000);
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".arrow-btn.next")));
        }

        protected void FindDesiredLocation(int position)
        {
            IWebElement CurrentPageInfo;
            CurrentPageInfo = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("p[class=\"paging-info\"]>.big")));
            while (CurrentPageInfo.Text != "0"+position.ToString())
            {
                string pageI = CurrentPageInfo.Text;
                ArrowBtnNext().Click();
                Thread.Sleep(2000);
                CurrentPageInfo = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("p[class=\"paging-info\"]>.big")));
            }

        }

    }
}
