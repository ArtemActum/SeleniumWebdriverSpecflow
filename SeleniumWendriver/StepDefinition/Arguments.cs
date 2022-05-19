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
    public sealed class Arguments
    {
        private HomePage hPage;
        private LoginPage lPage;
        private BugDetail bPage;

        private readonly IWebDriver _webDriver;

        public Arguments()
        {
            _webDriver = new ChromeDriver();
        }

        #region Given

        //[Given(@"User is at Home Page with url in the browser ""([^""]*)""")]
        ////[Given(@"User is at Home Page with url in the browser ""(.*)""")]
        //[Given(@"User is at Home Page with url ""(.*)""")]
        //public void GivenUserIsAtHomePageWithUrl(string url)
        //{
        //    //NavigationHelper.NavigateToUrl(url);
        //    NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        //}

        [Given(@"User is at Home Page\.")]
        public void GivenUserIsAtHomePage_()
        {
            //NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl("http://localhost:5001/");
            _webDriver.Manage().Window.Maximize();
        }


        //[Given(@"File a Bug Should be visible")]
        //public void GivenFileABugShouldBeVisible()
        //{
        //    Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("enter_bug")));
        //}

        [Given(@"File a Bug should be visible")]
        public void GivenFileABugShouldBeVisible()
        {

            //Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("enter_bug")));
        }


        #endregion

        #region When

        [When(@"I click on File a Bug link")]
        public void WhenIClickOnFileABugLink()
        {
            hPage = new HomePage(ObjectRepository.Driver);
            lPage = hPage.NavigateToLogin();
        }


        //[When(@"I click on ""(.*)"" Link")]
        //public void WhenIClickOnLink(/*string linkText*/)
        //{
        //    ObjectRepository.hPage = new HomePage(ObjectRepository.Driver);
        //    ObjectRepository.lPage = ObjectRepository.hPage.NavigateToLogin();
        //}
        


        [When(@"I provide the ""(.*)"", ""(.*)"" and click on Login button")]
        public void WhenIProvideTheAndClickOnLoginButton(string user, string pass)
        {
            ObjectRepository.bPage = ObjectRepository.lPage.Login(user, pass);
        }

        [When(@"I click on Logout button at bug detail page")]
        //[When(@"I click on Logout button at enter bug page")]
        public void WhenIClickOnLogoutButtonAtEnterBugPage()
        {
            bPage.Logout();
        }


        [When(@"I provide the severity , hardware , platform , summary and desc")]
        public void WhenIProvideTheSeverityHardwarePlatformSummaryAndDesc(Table table)
        {
            foreach (var row in table.Rows)
            {
                bPage.SelectFromCombo(row["Severity"], row["Hardware"], row["Platform"]);
                bPage.TypeIn(row["Summary"], row["Desc"]);
            }
        }


        [When(@"I provide the ""([^""]*)"" , ""([^""]*)"" , ""([^""]*)"" , ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIProvideTheAnd(string severity, string hardware, string platform, string summary, string desc)
        {
            bPage.SelectFromCombo(severity, hardware, platform);
            bPage.TypeIn(summary, desc);
        }




        #endregion

        #region Then

        [Then(@"User should be at Login Page with title ""(.*)""")]
        public void ThenUserShouldBeAtLoginPageWithTitle(string title)
        {
            Assert.AreEqual(title, ObjectRepository.lPage.Title);
        }


        [Then(@"User Should be at Bug Detail page with title ""([^""]*)""")]
        public void ThenUserShouldBeAtBugDetailPageWithTitle(string title)
        {
            Assert.AreEqual(title, ObjectRepository.bPage.Title);
        }



        #endregion

        #region And

        //[Given(@"File a Bug should be visible")]
        //public void GivenFileABugShouldBeVisible()
        //{
        //    bPage.ClickSubmit();
        //}

        

        [When(@"click on Submit button in page")]
        public void WhenClickOnSubmitButtonInPage()
        {
            bPage.ClickSubmit();
        }


        #endregion


    }
}