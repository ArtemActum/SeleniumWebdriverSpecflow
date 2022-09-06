using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.BrowserActions
{
    [TestClass]
    public class TestBrowserActions
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/course/design-and-develop-a-killer-website-with-html5-and-css3/");

            ButtonHelper.ClickButton(By.XPath("(//span[contains(text(),'Teach on Udemy')])[1]"));

            BrowserHelper.GoBack();

            BrowserHelper.Forward();

            BrowserHelper.RefreshPage();


        }
    }
}
