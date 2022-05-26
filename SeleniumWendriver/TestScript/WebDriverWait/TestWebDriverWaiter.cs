using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumWendriver.TestScript.WebDriverWaiter
{
    [TestClass]
    public class TestWebDriverWaiter
    {
        [TestMethod]
        public void TestWait()
        {

            NavigationHelper.NavigateToUrl("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =  TimeSpan.FromSeconds(50);
            TextBoxHelper.TypeInTextBox(By.XPath("//input[@class='udlite-text-input udlite-text-input-small udlite-text-sm udlite-search-form-autocomplete-input js-header-search-field']"),
               "C#");
        }


        [TestMethod]
        public void TestDynamicWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1); 
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50)); // Create the object of our WebDriverWait class
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(waitforElement()).SendKeys("health");
            ButtonHelper.ClickButton(By.XPath("/html//input[@id='find_top']"));
            wait.Until(waitforLastElement()).Click();
            Console.WriteLine("Title : {0}", wait.Until(waitforpageTitle()));
        }

        [TestMethod]
        public void TestExpCondition()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50)); // Create the object of our WebDriverWait class
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html//input[@id='quicksearch_top']"))).SendKeys("html");
            ButtonHelper.ClickButton(By.XPath("/html//input[@id='find_top']"));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='bugzilla-body']/ul[@class='zero_result_links']//a[@href='enter_bug.cgi']"))).Click();
            Console.WriteLine("Title : {0}", wait.Until(ExpectedConditions.TitleContains("u")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='header']/ul[@class='links']//a[@href='report.cgi']"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='bugzilla-body']/h2[.='Current State']")));
        }

        private Func<IWebDriver, bool> waitforSearchbox()
        {
            return ((x) =>
             {
                 Console.WriteLine("Waiting for Search Box");
                 return x.FindElements(By.XPath("/html//input[@id='quicksearch_top']")).Count == 1;
             });
        }

        private Func<IWebDriver, string> waitforTitle()
        {
            return ((x) =>
            {
                
                if (x.Title.Contains("Bug List"))
                    
                    return x.Title;
                return null;
            });
        }
        private Func<IWebDriver, IWebElement> waitforElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element");
                if (x.FindElements(By.XPath("/html//input[@id='quicksearch_top']")).Count == 1)
                    return x.FindElement(By.XPath("/html//input[@id='quicksearch_top']"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitforLastElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Last Element");
                if (
                    x.FindElements(
                        By.XPath("//div[@id='bugzilla-body']/ul[@class='zero_result_links']//a[@href='enter_bug.cgi']")).Count ==
                    1)
                    return
                        x.FindElement(
                            By.XPath("//div[@id='bugzilla-body']/ul[@class='zero_result_links']//a[@href='enter_bug.cgi']"));
                return null;
            });

        }

        private Func<IWebDriver, string> waitforpageTitle()
            {
                return ((x) =>
                {
                    Console.WriteLine("Waiting for Title");
                    if (
                        x.FindElements(By.CssSelector("#title p")).Count == 1)
                        return x.FindElement(By.CssSelector("#title p")).Text;
                    return null;
                });
            }
        }
    }

