using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SeleniumWendriver.StepDefinition
{
    [Binding]
    public sealed class SpecflowWithoutPOM
    {
        private readonly IWebDriver _webDriver;
        private readonly By _fileABug = By.XPath("//a[@id='enter_bug']/span[.='File a Bug']");
        private readonly By _loginInputButton = By.XPath("/html//input[@id='Bugzilla_login']");
        private readonly By _passwordInputButton = By.XPath("/html//input[@id='Bugzilla_password']");
        private readonly By _enterButton = By.XPath("/html//input[@id='log_in']");
        private readonly By _logoutButton = By.XPath("//div[@id='header']/ul[@class='links']//a[@href='index.cgi?logout=1']");
        private readonly By _exploreButton = By.XPath("//a[@id='enter_bug']/span[.='File a Bug']");
        private readonly By _exploreTextBugPage = By.XPath("//td[@id='title']/p[.='Bugzilla – Enter Bug: TestProduct']");
        private readonly By _exploreTextHomePage = By.XPath("/html//h1[@id='welcome']");
        private readonly By _submitButton = By.XPath("/html//input[@id='commit']");
        private readonly By _statusOfBug = By.XPath("/html//span[@id='static_bug_status']");
        private readonly By _summary = By.XPath("/html//input[@id='short_desc']");





        private HomePage hPage;
        private LoginPage lPage;
        private BugDetail bPage;


        public SpecflowWithoutPOM()
        {
            _webDriver = new ChromeDriver();
        }

        #region Given

        [Given(@"Go to website")]
        public void GivenGoToWebsite()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl("http://localhost:5001/");
            _webDriver.Manage().Window.Maximize();
        }

        #endregion

        #region When

        [When(@"I click on File a Bug Link\.")]
        public void WhenIClickOnFileABugLink_()
        {
            _webDriver.FindElement(_fileABug).Click();
        }

        [When(@"I provide the username, password and click on Login button\.")]
        public void WhenIProvideTheUsernamePasswordAndClickOnLoginButton_()
        {
            //_webDriver.FindElement(_passwordInputButton).SendKeys(ObjectRepository.Config.GetPassword());

            _webDriver.FindElement(_loginInputButton).SendKeys(ConfigurationManager.AppSettings.Get(AppConfigKeys.Username));
            _webDriver.FindElement(_passwordInputButton).SendKeys(ConfigurationManager.AppSettings.Get(AppConfigKeys.Password));
            _webDriver.FindElement(_enterButton).Click();

        }

        [When(@"I provide the severity, hardware, platform and summary\.")]
        public void WhenIProvideTheSeverityHardwarePlatformAndSummary_()
        {

            _webDriver.FindElement(_summary).SendKeys("Summary");
        }

        [When(@"I click on Logout button\.")]
        public void WhenIClickOnLogoutButton_()
        {
            _webDriver.FindElement(_logoutButton).Click();
        }





        #endregion

        #region Then

        [Then(@"User should be at Login Page\.")]
        public void ThenUserShouldBeAtLoginPage_()
        {

        }


        [Then(@"User should be at Bug Detail Page\.")]
        public void ThenUserShouldBeAtBugDetailPage_()
        {
            _webDriver.FindElement(_exploreTextBugPage).GetAttribute("id").Contains("title");
        }

        [Then(@"Bug should get created\.")]
        public void ThenBugShouldGetCreated_()
        {
            _webDriver.FindElement(_statusOfBug).GetAttribute("id").Contains("static_bug_status");
        }

        [Then(@"User should be logged out and should be at Home Page\.")]
        public void ThenUserShouldBeLoggedOutAndShouldBeAtHomePage_()
        {
            _webDriver.FindElement(_exploreTextHomePage).GetAttribute("id").Contains("welcome");
            _webDriver.Quit();

        }






        #endregion

        #region And

        [Given(@"File a Bug Should be visible\.")]
        public void GivenFileABugShouldBeVisible_()
        {

            _webDriver.FindElement(_exploreButton).GetAttribute("id").Contains("enter_bug");
        }

        [When(@"click on Submit button\.")]
        public void WhenClickOnSubmitButton_()
        {
            _webDriver.FindElement(_submitButton).Click();
        }

        [Then(@"User should be at Search Page\.")]
        public void ThenUserShouldBeAtSearchPage_()
        {
            _webDriver.FindElement(_statusOfBug).GetAttribute("id").Contains("static_bug_status");
        }

        #endregion

    }
}