using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.DefaultWait
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            //NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //LinkHelper.ClickLink(By.LinkText("File a Bug"));
            //TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            //TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            //ButtonHelper.ClickButton(By.Id("log_in"));
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(1));

            //DefaultWait<string> wait = new DefaultWait<IWebElement> (ObjectRepository.Driver.FindElement(By.Id("bug_severity"));
            //wait.PollingInterval = TimeSpan.FromSeconds(2);
            //wait.Timeout = TimeSpan.FromSeconds(1);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //Console.WriteLine("After wait: {0}",wait.Until(changeofvalue()));
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
