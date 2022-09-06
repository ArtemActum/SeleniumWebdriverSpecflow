using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.DefaultWait
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.LinkText("Testng"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            GenericHelper.WaitForWebElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            IWebElement ele = GenericHelper.WaitForWebElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));

            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Console.WriteLine("After wait : {0}", wait.Until(changeofvalue()));

        }

        [TestMethod]
        public void TestFreeCharge()
        {
            NavigationHelper.NavigateToUrl("https://www.freecharge.in/#");
            LinkHelper.ClickLink(By.XPath("/html//div[@id='__next']/div[1]//div[@class='home-tab-wrapper']/div[1]/ul/li[@title='Mobile Recharge']/div[@class='tile-img-tag']"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("/html//div[@id='__next']/div[1]/div[@class='main-container']/div[@class='main-wrapper']//form//input[@name='Enter Mobile Number']"), TimeSpan.FromSeconds(50)));
            //Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("/html//div[@id='__next']/div[1]/footer/div[@class='footer-section']//div[@class='footer-list-container']/div[4]/div[@class='links-list']/ul[1]/li[7]/div/span[@class='tooltip-label tooltip-show-arrow']"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("/html//div[@id='__next']/div[1]/div[@class='main-container']/div[@class='main-wrapper']//input[@name='search-field']"), TimeSpan.FromSeconds(50)));
            
        }

        private Func<IWebElement, string> changeofvalue()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for value change");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("major"))
                    return select.SelectedOption.Text;
                return null;
            });
        }
    }
}
