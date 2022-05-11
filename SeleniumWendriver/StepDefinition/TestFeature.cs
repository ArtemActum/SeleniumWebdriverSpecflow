using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using TechTalk.SpecFlow;

namespace SeleniumWendriver.StepDefinition
{
    [Binding]
    public sealed class TestFeature
    {
        private HomePage hPage;
        private LoginPage lPage;
        private EnterBug ePage;
        private BugDetail bPage;

        private readonly IWebDriver _webDriver;

        public TestFeature()
        {
            _webDriver = new ChromeDriver();
        }

        #region Given

        [Given(@"User is at Home Page")]
        public void GivenUserIsAtHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [Given(@"File a Bug Should be visible")]
        public void GivenFileABugShouldBeVisible()
        {
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("enter_bug")));
        }

        #endregion 

        #region When

        [When(@"I click on File a Bug Link")]
        public void WhenIClickOnFileABugLink()
        {
            ObjectRepository.hPage = new HomePage(ObjectRepository.Driver);
            ObjectRepository.lPage = ObjectRepository.hPage.NavigateToLogin();
        }

        [When(@"I provide the username, password and click on Login button")]
        public void WhenIProvideTheUsernamePasswordAndClickOnLoginButton()
        {
            ObjectRepository.ePage = ObjectRepository.lPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
        }

        [When(@"I provide the severity, hardware, platform and summary")]
        public void WhenIProvideTheSeverityHardwarePlatformAndSummary()
        {
            bPage.SelectFromCombo("critical", "Macintosh", "Other");
            bPage.TypeIn("Summary 1", "Desc - 1");
        }


        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            ObjectRepository.ePage.Logout();
        }

        [When(@"I click on Testng link")]
        public void WhenIClickOnTestngLink()
        {
            bPage = ePage.NavigateToDetail();
        }

        [When(@"I provide the severity , harware , platform and summary")]
        public void WhenIProvideTheSeverityHarwarePlatformAndSummary()
        {
            bPage.SelectFromCombo("critical", "Macintosh", "Other");
            bPage.TypeIn("Summary 1", "Desc - 1");
        }



        #endregion

        #region Then

        [Then(@"User should be at Login Page")]
        public void ThenUserShouldBeAtLoginPage()
        {
            Assert.AreEqual("Log in to Bugzilla", ObjectRepository.lPage.Title);
            //AssertHelper.AreEqual("Log in to Bugzilla 1", lPage.Title);
        }

        [Then(@"User Should be at Enter Bug page")]
        public void ThenUserShouldBeAtEnterBugPage()
        {
            Assert.AreEqual("Enter Bug", ObjectRepository.ePage.Title);
        }

        [Then(@"User should be logged out and should be at Home Page")]
        public void ThenUserShouldBeLoggedOutAndShouldBeAtHomePage()
        {
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("welcome")));
        }

        [Then(@"User Should be at Bug Detail page")]
        public void ThenUserShouldBeAtBugDetailPage()
        {
            Assert.AreEqual("Enter Bug: Testng", bPage.Title);
        }


        [Then(@"Bug should get created")]
        public void ThenBugShouldGetCreated()
        {
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("commit_top")));
        }


        #endregion

        #region And

        [When(@"click on Submit button")]
        public void WhenClickOnSubmitButton()
        {
            bPage.ClickSubmit();
        }

        [Then(@"User should be at Search page")]
        public void ThenUserShouldBeAtSearchPage()
        {
        }

        #endregion


    }
}