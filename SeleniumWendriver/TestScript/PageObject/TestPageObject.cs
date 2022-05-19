﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWendriver.BaseClasses;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.PageObject;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            BugDetail enterBug = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            enterBug.SelectFromSeverity("trivial");
            ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));

            //NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //HomePage homePage = new HomePage(ObjectRepository.Driver);
            //Console.WriteLine(DisplayElementName(homePage, "homePage.QuickSearchTextBox"));
            //LoginPage loginPage = homePage.NavigateToLogin();
            //BugDetail bugDetail = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            //////BugDetail bugDetail = enterBug.NavigateToDetail();
            //bugDetail.SelectFromSeverity("trivial");
            ////// ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
            //ButtonHelper.Logout();
        }

        public string DisplayElementName(PageBase aPageInstance, string element)
        {
            var fieldInfo = GetFieldInfo(aPageInstance, element);
            var memeberInfo = fieldInfo.GetCustomAttributes(true);
            var attribute = memeberInfo[0] as FindsByAttribute;
            return string.Format("How : {0} using : {1}", attribute.How, attribute.Using);
        }

        public FieldInfo GetFieldInfo(PageBase aPageInstance, string element)
        {
            var elementName = element.Split('.');
            Type aPageType = aPageInstance.GetType();
            var fieldInofs = aPageType.GetFields();
            return fieldInofs.FirstOrDefault((x) => x.Name.Equals(elementName[1], StringComparison.OrdinalIgnoreCase));
        }


    }
}
