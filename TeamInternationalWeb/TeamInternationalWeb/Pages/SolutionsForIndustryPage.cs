using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TeamInternationalWeb.Elements;


namespace Pages
{
    public class SolutionsForIndustryPage : SolutionsForIndustryLocators
    {
        private readonly IWebDriver driver;
        private readonly Actions action;


        public SolutionsForIndustryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            action = new Actions(this.driver);
        }

        public void Goto() {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.teaminternational.com/");
        }

        public List<string> GetLabels() {
            List<string> optionsText = new();
            List<IWebElement> solutionForIndustrialOptions = SolutionForIndustrialOptions();
            foreach (IWebElement elem in solutionForIndustrialOptions)
            {
                string optionText = SolutionForIndustryOptionToGetText(elem).Text.Replace("\r\n", " ");
                optionsText.Add(optionText);
            }
            return optionsText;
        }

        public List<string> ClickOnEverySmallSection() {
            List<string> pageTitle = new();
            List<IWebElement> solutionForIndustrialOptions = SolutionForIndustrialOptions();

            for (int x = 1; x < solutionForIndustrialOptions.Count+1; x++)
            {
                IWebElement solutionIndustrialOption = SolutionForIndustryOption(x);
                solutionIndustrialOption.Click();
                string textTitle = driver.Title;
                pageTitle.Add(textTitle);
                driver.Navigate().Back();  
            }
            return pageTitle;

        }

        
        public void MouseOverEverySmallSection()
        {
            List<IWebElement> solutionForIndustrialOptions = SolutionForIndustrialOptions();
            for (int x = 1; x < solutionForIndustrialOptions.Count + 1; x++)
            {
                IWebElement solutionIndustrialOption = SolutionForIndustryOption(x);
                action.MoveToElement(solutionIndustrialOption).Perform();
            }

        }
    }
}
