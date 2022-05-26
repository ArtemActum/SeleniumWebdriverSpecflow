using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.Settings;

using OpenQA.Selenium.Support;

using SeleniumWendriver.BaseClasses;
using SeleniumExtras.PageObjects;
using SeleniumWendriver.ComponentHelper;

namespace SeleniumWendriver.PageObject
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;


        #region WebElement

        [FindsBy(How = How.Id, Using = "quicksearch_main")]
        private IWebElement QuickSearchTextBox;

        [FindsBy(How = How.Id, Using = "find")]
        [CacheLookup]
        private IWebElement QuickSearchBtn;

        [FindsBy(How = How.LinkText, Using = "File a Bug")]
        private IWebElement FileABugLink;

        //private By QuickSearchTextBox = By.Id("quicksearch_main");
        //private By QuickSearchBtn = By.Id("find");
        //private By FileABugLink = By.LinkText("File a Bug");



        #endregion

        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public void QuickSearch(string text)
        {
            QuickSearchTextBox.SendKeys(text);
            QuickSearchBtn.Click();

            //ObjectRepository.Driver.FindElement(QuickSearchTextBox).SendKeys(text);
            //ObjectRepository.Driver.FindElement(QuickSearchBtn).Click();
        }

        #endregion

        #region Navigation

        public LoginPage NavigateToLogin()
        {
            FileABugLink.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("log_in"), TimeSpan.FromSeconds(30));
            return new LoginPage(driver);

            //ObjectRepository.Driver.FindElement(FileABugLink).Click();
        }

        #endregion

    }
}
