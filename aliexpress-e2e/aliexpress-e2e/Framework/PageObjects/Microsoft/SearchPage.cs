using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;
using NUnit.Framework;
using aliexpress_e2e.Framework.Utilities;

namespace aliexpress_e2e.Framework.PageObjects.Microsoft
{
    class SearchPage
    {
        //Wait Locators
        By StoreSwitcherBy = By.XPath("//button[@id='R1MarketRedirect-close']");
        By ResultsBy = By.XPath("(//li[@aria-posinset='1']//span[@itemprop='price'])[1]");
        //Driver
        IWebDriver driver;
        public static string storedPrice = "";
        [FindsBy(How = How.XPath, Using = "//button[@id='R1MarketRedirect-close']")]
        public IWebElement StoreSwitcherButton { get; set; }
        [FindsBy(How = How.XPath, Using = "(//li[@aria-posinset='1']//span[@itemprop='price'])[1]")]
        public IWebElement FirstResult { get; set; }
        [FindsBy(How = How.XPath, Using = "(//li[@aria-posinset='2']//span[@itemprop='price'])[1]")]
        public IWebElement SecondResult { get; set; }
        [FindsBy(How = How.XPath, Using = "(//li[@aria-posinset='3']//span[@itemprop='price'])[1]")]
        public IWebElement ThirdResult { get; set; }

        public SearchPage(IWebDriver driver) => this.driver = driver;

        public void ValidateSearch()
        {
            try
            {
                WaitUtilities.ExplicitlyWait(driver, StoreSwitcherBy);
                StoreSwitcherButton.Click();
            }
            catch
            {
                Console.WriteLine("StoreSwitcherPopUp was not displayed, this is ok and will not end the test");
            }
            Thread.Sleep(1342);
            WaitUtilities.ExplicitlyWait(driver, ResultsBy);
            Console.WriteLine(FirstResult.Text);
            Console.WriteLine(SecondResult.Text);
            Console.WriteLine(ThirdResult.Text);
            storedPrice = FirstResult.Text;
            try
            {
                FirstResult.Click();
            }
            catch
            {
                Assert.Fail("Could not click the first result, ending test");
            }
        }
    }
}
