﻿using OpenQA.Selenium;
using SeleniumWendriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace SeleniumWendriver.BaseClasses
{
    public class PageBase // konstruktor pro inicializaci stranky, spolecna actions/navigace methods
    {
        private IWebDriver driver;


        
        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;
        //private IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this); //This class provide a method called “initElements” which will initialize the web element
            this.driver = _driver;
        }

        public void Logout()
        {
            if (GenericHelper.IsElementPresent(By.XPath("//div[@id='header']/ul[1]/li[11]/a")))
            {
                ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
            }
            GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));

        }

        protected void NaviGateToHomePage()
        {
            HomeLink.Click();
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
