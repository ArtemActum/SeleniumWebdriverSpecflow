
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
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
                LinkHelper.ClickLink(By.LinkText("File a Bug"));
            }

            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                throw;
            }

        }
    }
}
