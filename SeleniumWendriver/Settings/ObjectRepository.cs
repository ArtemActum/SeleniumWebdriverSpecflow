using OpenQA.Selenium;
using SeleniumWendriver.Interfaces;
using SeleniumWendriver.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static HomePage hPage;
        public static LoginPage lPage;
        public static EnterBug ePage;
        public static BugDetail bPage;
    }
}
