using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumWendriver.StepDefinition
{
    [Binding]
    public sealed class TestFeature
    {
        private readonly IWebDriver _webDriver;

        public TestFeature()
        {
            _webDriver = new ChromeDriver();
        }

        #region Given

        [Given(@"User is at Home Page")]
        public void GivenUserIsAtHomePage()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl("http://localhost:5001/");
            _webDriver.Manage().Window.Maximize();
        }

        [Given(@"File a Bug Should be visible")]
        public void GivenFileABugShouldBeVisible()
        {
            throw new PendingStepException();
        }

        #endregion 

        #region When

        [When(@"I click on File a Bug Link")]
        public void WhenIClickOnFileABugLink()
        {
            throw new PendingStepException();
        }

        #endregion



    }
}