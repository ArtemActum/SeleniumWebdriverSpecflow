using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;

namespace SeleniumWendriver.TestScript.MultipleBrowser
{
    [TestClass]
    public class TestMultipleBrowserWindow
    {
        [TestMethod]
        public void TestMutipleBrowserWindow()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            GenericHelper.TakeScreenShot();
            //BrowserHelper.SwitchToWindow(1);
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            //BrowserHelper.SwitchToWindow(2);
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//button[@class='w3-button w3-bar-item w3-hover-white w3-hover-text-green']"));
            GenericHelper.TakeScreenShot();
            //BrowserHelper.SwitchToParent();
        }
    }
}
