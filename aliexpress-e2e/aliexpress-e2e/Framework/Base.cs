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
        IWebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            if (ConfigurationManager.AppSettings["Website"] == "CHROME")
            {
                driver = new ChromeDriver();
            }
            else if (ConfigurationManager.AppSettings["Website"] == "FIREFOX")
            {
                driver = new FirefoxDriver();
            }else
            {
                Assert.Fail("Error on type of browser at config file (App.config)");
            }
            driver.Url = ConfigurationManager.AppSettings["URL"];

        }




    }
}
