using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.ExcelReader;
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
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

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
            Thread.Sleep(5000);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\downloads\CreateData.csv", "CreateData#csv", DataAccessMethod.Sequential)] //MSTest frame work provide the attribute “DataSource” by which, one can easily access the data

        public void TestBugFromCSV()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            bugPage.SelectFromCombo(TestContext.DataRow["Severity"].ToString(), TestContext.DataRow["HardWare"].ToString(), TestContext.DataRow["OS"].ToString());
            bugPage.TypeIn(TestContext.DataRow["Summary"].ToString(), TestContext.DataRow["Desc"].ToString());
            bugPage.ClickSubmit();
            bugPage.Logout();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TestBugXlsx()
        {
            string xlPath = @"C:\downloads\ExcelData.xlsx";
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            bugPage.SelectFromCombo(ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 0).ToString(), ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 1).ToString(), ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 2).ToString());
            bugPage.TypeIn(ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 3).ToString(), ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 4).ToString());
            bugPage.ClickSubmit();
            bugPage.Logout();
            Thread.Sleep(5000);
        }
    }
}