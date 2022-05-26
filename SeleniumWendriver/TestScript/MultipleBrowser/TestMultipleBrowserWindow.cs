using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;

namespace SeleniumWendriver.TestScript.MultipleBrowser
{
    [TestClass]
    public class TestMultipleBrowserWindow
    {
        [TestMethod, TestCategory("Smoke Test")]
        public void TestMutipleBrowserWindow()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("/html//div[@id='accept-choices']"));
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']//a[@href='tryit.asp?filename=tryjs_alert']"));
            GenericHelper.TakeScreenShot();
            BrowserHelper.SwitchToWindow(1);
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']//a[@href='tryit.asp?filename=tryjs_alert']"));
            BrowserHelper.SwitchToWindow(2);
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("/html//a[@id='getwebsitebtn']"));
            GenericHelper.TakeScreenShot();
            //BrowserHelper.SwitchToParent();




            //GenericHelper.TakeScreenShot();
            //BrowserHelper.SwitchToWindow(1);
            //NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            //GenericHelper.TakeScreenShot();
            //ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            //BrowserHelper.SwitchToWindow(2);
            //GenericHelper.TakeScreenShot();
            //ButtonHelper.ClickButton(By.XPath("//div[@class='textarea']/descendant::button"));
            //GenericHelper.TakeScreenShot();
            //BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void TestFrame()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("/html//div[@id='accept-choices']"));
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']//a[@href='tryit.asp?filename=tryjs_alert']"));
            BrowserHelper.SwitchToWindow(1);
            //ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//body/button[.='Try it']"));
            var a = ObjectRepository.Driver.SwitchTo().Alert().Text;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            //TextBoxHelper.ClearTextBox(By.XPath("//div[@id='textareawrapper']/div"));
            //TextBoxHelper.TypeInTextBox(By.XPath("//div[@id='textareawrapper']/div"), a);

        }
    }
}
