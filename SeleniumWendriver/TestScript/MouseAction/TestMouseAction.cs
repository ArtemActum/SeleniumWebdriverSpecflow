using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.MouseAction
{
    [TestClass]
    public class TestMouseAction
    {
        [TestMethod]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("draggable"));


            act.ContextClick(ele) // it is going to open the right click menu
                .Build() //sestavim akce volanim metody Build
                .Perform(); //Proveďte akci voláním metody Perform

            //Thread.Sleep(5000);
        }

        [TestMethod]
        public void DranNDrop()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.Id("droptarget"));
            IWebElement cookies = ObjectRepository.Driver.FindElement(By.XPath("//button[contains(text(),'Accept and Close')]"));

            act.Click(cookies) //Accept cookies
                .DragAndDrop(src, tar) 
                .Build()
                .Perform();

            Thread.Sleep(4000);
        }


        [TestMethod]
        public void TestClicknHold()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]/span"));
            IWebElement cookies = ObjectRepository.Driver.FindElement(By.XPath("//button[contains(text(),'Accept and Close')]"));

            act.Click(cookies);

                Thread.Sleep(5000);

                act.ClickAndHold(ele) // Stiskne a podrží levé tlačítko myši.
                .MoveToElement(tar, 0, 30) // Přesune aktuální prvek na zadaný prvek
                .Release() // Uvolní levé tlačítko myši
                .Build()
                .Perform();

            Thread.Sleep(10000);
        }

        [TestMethod]
        public void TestKeyBoard()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Actions act = new Actions(ObjectRepository.Driver);

            IWebElement ele1 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_top"));
            IWebElement ele2 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_main"));
            ele1.SendKeys("fx");

            act.KeyDown(ele2, Keys.LeftShift) // Simuluje stisk klávesy
                .SendKeys(ele2, "f")
                .SendKeys(ele2, "x")
                .KeyUp(ele2, Keys.LeftShift) // Simuluje uvolnění klíče
                .Build()
                .Perform();
            Thread.Sleep(5000);

        }

    }
}
