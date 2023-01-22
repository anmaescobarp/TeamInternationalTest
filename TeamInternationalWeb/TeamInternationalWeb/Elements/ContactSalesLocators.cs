using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeamInternationalWeb.Elements
{
    public class ContactSalesLocators
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly string mainlocator = "lightning-layout-item:nth-child(3)>slot>lightning-layout >slot>lightning-layout-item:nth-child(position)";
        public ContactSalesLocators(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement ContactSalesSection()
        {
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("section[data-anchor=\"contact-us\"]")));
        }
        protected IWebElement ContactSalesIframe() 
        {
            Thread.Sleep(3000);
            return driver.FindElement(By.CssSelector("iframe[src*='candidates-form']"));
        }

        private IWebElement MainFormIntoIframe()
        {
            Thread.Sleep(2000);
            return driver.FindElement(By.CssSelector("body > webruntime-app > community_byo-scoped-header-and-footer > main"));
        }

        protected IWebElement FirstNameTextBox()
        {
            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "1") + " input"));
        }
        protected IWebElement LastNameTextBox()
        {
            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "2") + " input"));
        }

        protected IWebElement CompanyTextBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "3") + " input"));
        }

        protected IWebElement EmailTextBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "4") + " input"));
        }

        protected IWebElement PhoneTextBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "5") + " input"));
        }

        protected IWebElement MessageTextBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "6") + " input"));
        }

        protected IWebElement PrivacyPolicyCheckBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "7") + " span.checkmark"));
        }

        protected IWebElement GetLatestEventsAnnouncementsCheckBox()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "8") + " span.checkmark"));
        }

        protected IWebElement ContactSalesButton()
        {

            return MainFormIntoIframe().FindElement(By.CssSelector(mainlocator.Replace("position", "9") + " input"));
        }

        protected IWebElement ThanksMessageElement()
        {
            return MainFormIntoIframe().FindElement(By.CssSelector("lightning-layout-item:nth-child(3)>slot>div:nth-child(1)"));
        }


    }
}
