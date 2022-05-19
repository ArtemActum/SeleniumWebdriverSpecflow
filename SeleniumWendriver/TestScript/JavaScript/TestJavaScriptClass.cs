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

namespace SeleniumWendriver.TestScript.JavaScript
{
    [TestClass]
    public class TestJavaScriptClass
    {
        [TestMethod]
        public void TestJavaScript()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/bdd-with-selenium-webdriver-and-speckflow-using-c/");
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("/html//body[@id='udemy']/div[@class='main-content-wrapper']/div[@class='main-content']//div[@class='ud-component--course-landing-page-udlite--course-landing-page']//div[@class='report-abuse--report-abuse-full-width--hCrJe']/button[@type='button']/span[.='Report abuse']"));
            executor.ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            element.Click();

        }
    }
}
