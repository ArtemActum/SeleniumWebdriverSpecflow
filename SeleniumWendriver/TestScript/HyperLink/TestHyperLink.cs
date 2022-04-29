using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.HyperLink
{
    [TestClass]
    public class TestHyperLink
    {
        [TestMethod, TestCategory("Smoke")]
        public void ClickLink()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            //IWebElement element = ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
            //element.Click();

            //IWebElement pelement = ObjectRepository.Driver.FindElement(By.PartialLinkText("File"));
            //pelement.Click();

            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            LinkHelper.ClickLink(By.PartialLinkText("File"));

        }
    }
}
