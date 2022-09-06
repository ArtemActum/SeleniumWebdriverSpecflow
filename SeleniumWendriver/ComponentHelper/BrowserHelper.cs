using OpenQA.Selenium;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWendriver.ComponentHelper
{
    public class BrowserHelper
    {
        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }
        public static void Forward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }
        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

    }
}
