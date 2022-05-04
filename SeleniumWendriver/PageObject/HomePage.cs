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
        }

        #endregion

        #region Navigation
        public LoginPage NavigateToLogin()
        {
            FileABugLink.Click();
            return new LoginPage(driver);
        }

        #endregion

    }
}
