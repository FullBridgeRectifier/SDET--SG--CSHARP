﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace aliexpress_e2e.Framework.PageObjects
{
    public class LandingPage
    {

        //Driver
        IWebDriver driver;
        //Locators        
        By popUp = By.CssSelector("div[data-widget-cid='widget-21']");
        By searchBox = By.Id("search-key");
        By popUpCloseButton = By.ClassName("close-layer");
        By searchButton = By.ClassName("search-button");
        By popUpInternalPages = By.ClassName("newuser-container");
        By popUpCloseButtonInternalPages = By.ClassName("next-dialog-close");

        public LandingPage(IWebDriver driver) => this.driver = driver;

        public void ClosePopUpIfShown()
        {
            if (driver.FindElement(popUp).Displayed)
            {
                driver.FindElement(popUpCloseButton).Click();
            }
            else
                Console.WriteLine("Popup was not displayed by the website, this is ok.");
        }

        public void SearchItem(String item)
        {
            if (driver.FindElement(searchBox).Displayed)
            {
                driver.FindElement(searchBox).SendKeys(item);
            }
            else
            {
                Assert.Fail("could not send text to the website, verify textbox");
            }
        }

        public void ClickSearchButton()
        {
            if (driver.FindElement(searchButton).Displayed)
            {
                driver.FindElement(searchButton).Click();
                try
                {
                    driver.FindElement(popUpInternalPages).Click();
                }
                catch
                {
                    Console.Write("Internal popup was not displayed, this is ok");                    
                }
            }
            else
            {
                Assert.Fail("could not send text to the website, verify textbox");
            }
        }



    }
}
