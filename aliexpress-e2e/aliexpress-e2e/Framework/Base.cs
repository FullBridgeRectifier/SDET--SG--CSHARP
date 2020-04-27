using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace aliexpress_e2e.Framework
{
    public class Base
    {
        public static IWebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            if (ConfigurationManager.AppSettings["browser"] == "CHROME")
            {
                driver = new ChromeDriver();
            }
            else if (ConfigurationManager.AppSettings["browser"] == "FIREFOX")
            {
                driver = new FirefoxDriver();
            }else
            {
                Assert.Fail("Error on type of browser at config file (App.config)");
            }
            driver.Url = ConfigurationManager.AppSettings["URL"];

        }

        [TearDown]
        public void DestroyBrowser()
        {
            driver.Quit();
        }




    }
}
