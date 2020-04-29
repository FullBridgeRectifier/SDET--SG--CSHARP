using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliexpress_e2e.Framework.Utilities
{
    public  class WaitUtilities
    {
        static IWebDriver driver;
        public WaitUtilities(IWebDriver Wdriver) => driver = Wdriver;

        public static void WaitForPageToLoad(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                
            }
        }

        public static void FluentWait(IWebDriver driver, String locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => x.FindElement(By.CssSelector(locator)));
        }

        public static void ExplicitlyWait(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch
            {
                Console.WriteLine("Element was not displayed, moving forward");
            }
        }
    }
}
