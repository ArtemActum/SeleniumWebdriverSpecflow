using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.TextBox
{
    [TestClass]
    public class TestTextBox
    {
        [TestMethod]
        public void TextBox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("Buzilla_login"));
            //ele.SendKeys(ObjectRepository.Config.GetUsername());

            //ele = ObjectRepository.Driver.FindElement(By.Id("Buzilla_password"));
            //ele.SendKeys(ObjectRepository.Config.GetPassword());

            //ele = ObjectRepository.Driver.FindElement(By.Id("Buzilla_login"));
            //ele.Clear();

            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
        }

    }
}
