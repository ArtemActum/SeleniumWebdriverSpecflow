using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumWendriver.StepDefinition
{
    [Binding]
    public sealed class SpecflowPOM
    {
        private HomePage hPage;
        private LoginPage lPage;
        private BugDetail bPage;

        private readonly IWebDriver _webDriver;

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
            bPage = lPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
        }

        [When(@"I provide the severity, hardware, platform and summary")]
        public void WhenIProvideTheSeverityHardwarePlatformAndSummary()
        {
            bPage.SelectFromCombo("critical", "Macintosh", "Other");
            bPage.TypeIn("Summary 1", "Desc - 1");
        }

        [When(@"I click on Logout button at Bug Detail Page")]
        public void WhenIClickOnLogoutButtonAtBugDetailPage()
        {
            ObjectRepository.bPage.Logout();
        }


        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            ObjectRepository.bPage.Logout();
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

        }

        [Then(@"User Should be at Bug Detail Page with title ""([^""]*)""")]
        public void ThenUserShouldBeAtBugDetailPageWithTitle(string p0)
        {
            Assert.AreEqual("Enter Bug", ObjectRepository.bPage.Title);
        }



        [Then(@"User should be logged out and should be at Home Page")]
        public void ThenUserShouldBeLoggedOutAndShouldBeAtHomePage()
        {
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("welcome")));
        }


        [Then(@"User should be at Bug Detail Page")]
        public void ThenUserShouldBeAtBugDetailPage()
        {
            Assert.AreEqual("Enter Bug", ObjectRepository.bPage.Title);
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

        [Then(@"User should be at Search Page")]
        public void ThenUserShouldBeAtSearchPage()
        {

        }


        #endregion


    }
}