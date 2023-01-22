using OpenQA.Selenium;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class ContactSalesPage : ContactSalesLocators
    {
        private readonly IWebDriver driver;

        public ContactSalesPage(IWebDriver driver) : base (driver)
        {
            this.driver = driver;
        }

        public void ScrollToSection() {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", ContactSalesSection());
        }

        public string FillOutContactSalesForm(string firstName, string lastName, string company, string email, string phone, string messageForTeam) 
        {
            driver.SwitchTo().Frame(ContactSalesIframe());
            FirstNameTextBox().SendKeys(firstName);
            LastNameTextBox().SendKeys(lastName);
            CompanyTextBox().SendKeys(company);
            EmailTextBox().SendKeys(email);
            PhoneTextBox().SendKeys(phone);
            MessageTextBox().SendKeys(messageForTeam);
            PrivacyPolicyCheckBox().Click();
            GetLatestEventsAnnouncementsCheckBox().Click();
            ContactSalesButton().Click();
            return ThanksMessageElement().Text;
        }

    }
}
