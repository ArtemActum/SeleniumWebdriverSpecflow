using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace SeleniumWendriver.TestScript.PhantomJS
//{
//    [TestClass]
//    public class TestPhantomJS
//    {
//        [TestMethod]
//        public void TestPhantomJDriver()
//        {
//            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
//            GenericHelper.TakeScreenShot();
//            LinkHelper.ClickLink(By.LinkText("File a Bug"));
//            GenericHelper.TakeScreenShot();
//            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
//            GenericHelper.TakeScreenShot();
//            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
//            GenericHelper.TakeScreenShot();
//            ButtonHelper.ClickButton(By.Id("log_in"));
//            GenericHelper.TakeScreenShot();
//        }
//    }
//}
