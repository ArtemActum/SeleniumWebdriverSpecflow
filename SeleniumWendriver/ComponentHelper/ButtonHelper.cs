using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement element;
        public static void ClickButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }

        public static bool IsButtonEnabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            return element.Enabled;
        }

        public static string GetButtonText(By locator)
        {
            element = GenericHelper.GetElement(locator);
            if (element.GetAttribute("value") == null)
                return String.Empty;
            return element.GetAttribute("value");
        }
        public static void Logout()
        {
            if (GenericHelper.IsElementPresent(By.XPath("//div[@id='header']/ul[1]/li[11]/a")))
            {
                ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
                GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));
            }
        }
    }
}
