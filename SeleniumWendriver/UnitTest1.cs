using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Configuration;
using SeleniumWendriver.Interfaces;
using SeleniumWendriver.Settings;
using System;
using System.Configuration;

namespace SeleniumWendriver
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine("Test");
            

        }
    }
}
