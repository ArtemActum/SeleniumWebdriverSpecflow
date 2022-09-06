using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWendriver.ComponentHelper;

using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWendriver.DataDriven.Script
{
    [TestClass]
    public class TestCreateBug
    {
        //private TestContext _testContext;

        //public TestContext TestContext
        //{
        //    get { return _testContext; }
        //    set { _testContext = value; }
        //}

        [TestMethod]
        public void TestBug()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            bugPage.SelectFromCombo("critical", "Macintosh", "Other");
            bugPage.TypeIn("Summary one", "Description one");
            bugPage.ClickSubmit();
            bugPage.Logout();
        }


    }
}