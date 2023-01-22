using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Linq;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace TeamInternationalWeb.Tests
{
    [TestClass]
    public class TeamInternationTest
    {
        private readonly IWebDriver driver;
        private readonly SolutionsForIndustryPage testinit;
        private readonly ItSoftwareServicesPage testsecondsecreen;
        private readonly TheyTrustUsPage testTheyTrust;
        private readonly LocationsPage testLocations;
        private readonly TopGunLabsPage testTopGunLabs;
        private readonly EmpowerCareerPage testEmpowerCareers;
        private readonly ContactSalesPage testContactSales;

        //public static BatchDto Parse(string source) => JsonConvert.DeserializeObject<string>(source);

        public TeamInternationTest()
        {
            driver = new ChromeDriver();
            testinit = new(driver);
            testsecondsecreen = new(driver);
            testTheyTrust = new(driver);
            testLocations = new(driver);
            testTopGunLabs = new(driver);
            testEmpowerCareers = new(driver);
            testContactSales = new(driver);
        }

        [TestMethod]
        public void TeamInternationPageTest()
        {
            // Get expected Info from JSON file
            List<Dictionary<string, string>> expectedBehaviors = ExpectedBehaviorsclass.ExpectedBehaviors;
            
            
            // TEST FIRST SECTION:
           
            Dictionary<string, string> expectedSolutionServicesValues = expectedBehaviors.Where(x => x.ContainsKey("Software Solutions Labels")).First().ToDictionary(x => x.Key, x => x.Value);
            List<string> expectedLabelsforSS = expectedSolutionServicesValues["Software Solutions Labels"].Split(',').ToList();
            List<string> expectedPageTitlesforSS = expectedSolutionServicesValues["Page Titles expected"].Split(',').ToList();
            
            // Go To Team Internation file
            testinit.Goto();
            // Validation of Labels
            List<string> actualLabelsforSS = testinit.GetLabels();
            var differencesBetweenLabelsforSS = actualLabelsforSS.FindAll(x => !expectedLabelsforSS.Contains(x)).ToList();
            Assert.IsTrue(differencesBetweenLabelsforSS.Count==0);

            //Mouse Over Action
            testinit.MouseOverEverySmallSection();

            // Validation of Page titles after clicking every single option
            List<string> actualPageTitlesSS = testinit.ClickOnEverySmallSection();
            var differencesBetweenTitlesforSS = GetDifferencesBetweenLists(expectedPageTitlesforSS, actualPageTitlesSS);
            Assert.IsTrue(differencesBetweenTitlesforSS.Count == 0);


            // TEST SECOND SECTION:

            Dictionary<string, string> expectedItSoftwareValues = expectedBehaviors.Where(x => x.ContainsKey("Innovative IT Labels")).First().ToDictionary(x => x.Key, x => x.Value);
            List<string> expectedLabelsforIT = expectedItSoftwareValues["Innovative IT Labels"].Split(',').ToList();
            List<string> expectedPageTitlesforIT = expectedItSoftwareValues["Page Titles expected"].Split(',').ToList();

            //Scroll To Section
            testsecondsecreen.ScrollToSection();

            // Validation of Labels
            List<string> actualLabelsforIT = testsecondsecreen.GetLabels(); // Poner wait
            var differencesBetweenLabelsforIT = actualLabelsforIT.FindAll(x => !expectedLabelsforIT.Contains(x)).ToList();
            Assert.IsTrue(differencesBetweenLabelsforIT.Count == 0);

            //Mouse Over Action
            testsecondsecreen.MouseOverEverySmallSection();

            // Validation of Page titles after clicking every single option
            List<string> actualPageTitlesforIT = testsecondsecreen.ClickOnEverySmallSection();
            var differencesBetweenTitlesforIT = GetDifferencesBetweenLists(expectedPageTitlesforIT, actualPageTitlesforIT);
            Assert.IsTrue(differencesBetweenTitlesforIT.Count == 0);


            // TEST THIRD SECTION:


            //Scroll To Section
            testTheyTrust.ScrollToSection();

            //Mouse Over Action
            testTheyTrust.MouseOverEverySmallSection();



            // TEST FOURTH SECTION:

            Dictionary<string, string> expectedLocationsValues = expectedBehaviors.Where(x => x.ContainsKey("Locations Labels")).First().ToDictionary(x => x.Key, x => x.Value);
            List<string> expectedLabelsforLocations = expectedLocationsValues["Locations Labels"].Split(',').ToList();
            List<string> expectedPageTitlesforLocations = expectedLocationsValues["Page URL"].Split(',').ToList();

            //Scroll To Section
            testLocations.ScrollToSection();

            // Validation of Labels
            List<string> actualLabelsforLocations = testLocations.GetLabels();
            var differencesBetweenLabelsforLocations = actualLabelsforLocations.FindAll(x => !expectedLabelsforLocations.Contains(x)).ToList();
            Assert.IsTrue(differencesBetweenLabelsforLocations.Count == 0);

            //Mouse Over Action
            testLocations.MouseOverEverySmallSection();

            // Validation of Page titles after clicking every single option
            List<string> actualPageTitlesforLocations =  testLocations.ClickOnEverySmallSection();
            var differencesBetweenTitlesforLocations = GetDifferencesBetweenLists(expectedPageTitlesforLocations, actualPageTitlesforLocations);
            Assert.IsTrue(differencesBetweenTitlesforLocations.Count == 0);



            // TEST FIFTH SECTION:

            Dictionary<string, string> expectedTopGunValues = expectedBehaviors.Where(x => x.ContainsKey("Top Gun Labels")).First().ToDictionary(x => x.Key, x => x.Value);
            List<string> expectedLabelsforTopGun = expectedTopGunValues["Top Gun Labels"].Split(',').ToList();
            string expectedPageTitleforTopGun = expectedTopGunValues["Page Title expected"];

            //Scroll To Section
            testTopGunLabs.ScrollToSection();

            // Validation of Labels
            List<string> actualLabelsforTG =  testTopGunLabs.GetLabels();
            var differencesBetweenLabelsforTG = actualLabelsforTG.FindAll(x => !expectedLabelsforTopGun.Contains(x)).ToList();
            Assert.IsTrue(differencesBetweenLabelsforTG.Count == 0);

            //Mouse Over Action
            testTopGunLabs.MouseOverInSeeMoreButton();

            // Validation of Page title after clicking See More button
            string actualPageTitleForTG = testTopGunLabs.ClickOnSeeMoreButton();
            Assert.IsTrue(actualPageTitleForTG.IndexOf(expectedPageTitleforTopGun)>0);



            // TEST SIXTH SECTION:


            Dictionary<string, string> expectedCareerValues = expectedBehaviors.Where(x => x.ContainsKey("Page Title of Empower Career")).First().ToDictionary(x => x.Key, x => x.Value);
            string expectedTitleforCareer = expectedCareerValues["Page Title of Empower Career"];

            //Scroll To Section
            testEmpowerCareers.ScrollToSection();

            //Mouse Over Action
            testEmpowerCareers.MouseOverInSeeAllOffersButton();

            // Validation of Page title after clicking See All offers button
            string actualPageTitleForCarrer = testEmpowerCareers.ClickOnSeeAllOffersButton();
            Assert.IsTrue(expectedTitleforCareer.Equals(actualPageTitleForCarrer));



            // TEST SEVENTH SECTION:

            Dictionary<string, string> expectedContactSalesValues = expectedBehaviors.Where(x => x.ContainsKey("Contact Sales Message")).First().ToDictionary(x => x.Key, x => x.Value);
            string expectedMessageForContactSales = expectedContactSalesValues["Contact Sales Message"];

            //Scroll To Section
            testContactSales.ScrollToSection();

            //Validation Fill Out all form and clicking on Contact Sales
            string message = testContactSales.FillOutContactSalesForm(expectedContactSalesValues["First Name"], expectedContactSalesValues["Last Name"], expectedContactSalesValues["Company"], 
                expectedContactSalesValues["Email"], expectedContactSalesValues["Phone"], expectedContactSalesValues["MessageForTeam"]);
            Assert.IsTrue(message.Equals(expectedMessageForContactSales));

        }

        [TestCleanup]
        public void QuitBrowser()
        {
            driver.Quit();
        }

        public static List<string> GetDifferencesBetweenLists(List<string> listexpected, List<string> listactual)
        {
            var differencesList = new List<string>();
            foreach (string itemList in listactual)
            {
                int temp = 0;
                foreach (string expecteditem in listexpected)
                {
                    if (itemList.IndexOf(expecteditem) == -1){ temp++;}
                }
                if (temp == listactual.Count) { differencesList.Add(itemList); }
            }
            return differencesList;

        }
    }
}
