using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.PageObject
{
    [TestClass]
    public class TestPageObject
    {
        [TestMethod]
        public void TestPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage homePage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = homePage.NavigateToLogin();
            EnterBug enterBug = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            BugDetail bugDetail = enterBug.NavigateToDetail();
            bugDetail.SelectFromSeverity("trivial");


        }
    }
}
