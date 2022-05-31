using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumWendriver.TestScript.Popups
{
    [TestClass]
    [DeploymentItem(@"Resources")]
    public class TestPopups
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void TestAlert()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("/html//div[@id='accept-choices']"));
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']//a[@href='tryit.asp?filename=tryjs_alert']"));
            BrowserHelper.SwitchToWindow(1);
            //IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
            //JavaScriptExecutor.ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");
            //TextBoxHelper.ClearTextBox(By.CssSelector("#textareawrapper"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//body/button[.='Try it']"));
            //var text = JavaScriptPopHelper.GetPopUpText();
            //JavaScriptPopHelper.ClickOkOnPopup();
            Thread.Sleep(1000);
            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            Thread.Sleep(1000);
            var text = alert.Text;
            Thread.Sleep(1000);
            alert.Accept();
            Thread.Sleep(1000);
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            ////GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //TextBoxHelper.ClearTextBox(By.XPath("//div[@id='textareawrapper']/div"));
            //TextBoxHelper.TypeInTextBox(By.Id("textareaCode"), text);

            ////GenericHelper.Wait(ExpectedConditions.ElementIsVisible(By.Id("id")), TimeSpan.FromSeconds(60));

        }


        [TestMethod]
        public void TestConfimPopup()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            ButtonHelper.ClickButton(By.XPath("/html//div[@id='accept-choices']"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            IAlert confirm = ObjectRepository.Driver.SwitchTo().Alert();
            confirm.Accept();
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            confirm = ObjectRepository.Driver.SwitchTo().Alert();
            confirm.Dismiss();



            //var text = JavaScriptPopHelper.GetPopUpText();
            //JavaScriptPopHelper.ClickOkOnPopup();

            //ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            //JavaScriptPopHelper.ClickCancelOnPopup();
            //ObjectRepository.Driver.SwitchTo().DefaultContent();
            //GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));

        }

        [TestMethod]
        public void TestPrompt()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            ButtonHelper.ClickButton(By.XPath("/html//div[@id='accept-choices']"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            IAlert prompt = ObjectRepository.Driver.SwitchTo().Alert();
            prompt.SendKeys("This is automation");
            prompt.Accept();

            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            prompt = ObjectRepository.Driver.SwitchTo().Alert();
            prompt.SendKeys("This is automation");
            prompt.Dismiss();

            //BrowserHelper.RefreshPage();
            //BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            //ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            //text = JavaScriptPopHelper.GetPopUpText();
            //JavaScriptPopHelper.SendKeys(text + "abc");
            //JavaScriptPopHelper.ClickCancelOnPopup();
            //ObjectRepository.Driver.SwitchTo().DefaultContent();
            //GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));

        }

        [TestCleanup]
        public void TearDown()
        {
            
        }

    }
}
