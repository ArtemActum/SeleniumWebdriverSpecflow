using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using SeleniumWendriver.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.TestScript.FindElements
{
    [TestClass]
    public class HandleElements
    {
        [TestMethod]
        public void GetAllElements()
        {
            
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//input"));
            //ReadOnlyCollection<IWebElement> elements2 = ObjectRepository.Driver.FindElements(By.Id("123"));
            //foreach (var ele in elements)
            //{
            //    Console.WriteLine("ID: {0}", ele.GetAttribute("id"));
            //}

        }
    }
}
