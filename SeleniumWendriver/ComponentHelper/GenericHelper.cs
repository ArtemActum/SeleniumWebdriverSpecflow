using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.ComponentHelper
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By Locator)

        {
            try
            {
                return ObjectRepository.Driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static IWebElement GetElement(By Locator)
        {
            if(IsElementPresent(Locator))
                return ObjectRepository.Driver.FindElement(Locator);
            else
            
                throw new NoSuchElementException("Element Not Found: " + Locator.ToString());
            
        }

        //public static void TakeScreenShot(string filename = "Screen")
        //{
        //    Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
        //    if (filename.Equals("Screen"))
        //    {
        //        string name = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
        //        screen.SaveAsFile(filename, ImageFormat.Jpeg);
        //        return;
        //    }
        //    screen.SaveAsFile(filename, ImageFormat.Jpeg);
        //}

        //public static bool WaitForWebElement(By Locator, TimeSpan timeout)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
        //    wait.PollingInterval = TimeSpan.FromMilliseconds(500);
        //    wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        //    bool flag = wait.Until(WaitForElementFunc(locator));
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout()));
        //    return flag;
        //}

        private static Func<IWebDriver, bool> WaitForElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }
    }
}
