using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWendriver.BaseClasses;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.PageObject
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;

        #region WebElement

        [FindsBy(How = How.Id, Using = "Bugzilla_login")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.Id, Using = "Bugzilla_password")]
        private IWebElement PassTextBox;

        [FindsBy(How = How.Id, Using = "log_in")]
        [CacheLookup]
        private IWebElement LoginButton;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;


        #endregion
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;

        }

        #region Actions

        public EnterBug Login(string username, string password)
        {
            LoginTextBox.SendKeys(username);
            PassTextBox.SendKeys(password);
            LoginButton.Click();
            GenericHelper.WaitForWebElementInPage(By.LinkText("Testng"), TimeSpan.FromSeconds(30));
            return new EnterBug(driver);
        }
        #endregion

        #region Navigation
        public void NavigateToHome()
        {
            HomeLink.Click();
        }

        #endregion

    }

}
