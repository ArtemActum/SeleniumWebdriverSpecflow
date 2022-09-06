using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivingDoc.SpecFlowPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Configuration;
using SeleniumWendriver.CustomException;
using SeleniumWendriver.Settings;
using TechTalk.SpecFlow;



namespace SeleniumWendriver.BaseClasses
{
    //[TestClass]
    [Binding]
    public class BaseClass
    {
        private static FirefoxProfile GetFirefoxOptions() 
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            //profile = manager.GetProfile("default");
            return profile;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }
            private static InternetExplorerOptions GetIEOptions() // used to launch the IE Browser with additional Settings
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            return options;
        }

        //private static IWebDriver /*FirefoxDriver*/ GetFirefoxDriver()
        //{
        //  IWebDriver driver = new FirefoxDriver(/*GetFirefoxOptions()*/);
        //  return driver;
        //}

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        

        
        [BeforeTestRun]
        public static void InitWebdriver(/*TestContext tc*/)
        {
            ObjectRepository.Config = new AppConfigReader();
           


            switch (ObjectRepository.Config.GetBrowser())
            {
                //case BrowserType.Firefox:
                //    ObjectRepository.Driver = GetFirefoxDriver();
                //    break;

                    case BrowserType.Chrome:
                    ObjectRepository.Driver= GetChromeDriver();
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver= GetIEDriver();
                    break;

                default:
                    throw new NoSuitableDriverFound("Driver Not Found: " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()); // nastaveni nacitani stranky
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies(); 
            BrowserHelper.BrowserMaximize(); //otevri stranku na celou obrazovku
        }

        
        [AfterTestRun]
        public static void TearDown()
        {
            if(ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close(); //to close the current browser window and it will not stop the webdriver
                ObjectRepository.Driver.Quit(); // to close all the browser window and also stop the webdriver

            }
        }
    }
}
