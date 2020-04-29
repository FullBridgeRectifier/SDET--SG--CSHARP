using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using aliexpress_e2e.Framework.Utilities;

namespace aliexpress_e2e.Framework.PageObjects
{
    public class SearchPage
    {
        //Driver
        IWebDriver driver;
        //Locators   
        By nextPageButton = By.XPath("//button[@aria-label='Next page, current page 1']");
        By productSelector = By.XPath("//div[@product-index='1']//a[@class='item-title']");

        public SearchPage(IWebDriver driver) => this.driver = driver;

        public void NavigateToSecondPage()
        {

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,13000)");
                WaitUtilities.ExplicitlyWait(driver, nextPageButton);
                driver.FindElement(nextPageButton).Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Could not click next page due to not scrolling or button not clickable " + e);
            }
        }

        public void ClickProduct()
        {
            WaitUtilities.ExplicitlyWait(driver, productSelector);
            WaitUtilities.WaitForPageToLoad(driver, productSelector);
            try
            {
                driver.FindElement(productSelector).Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Could not click product link verify stacktrace: " + e);
            }
        }
    }
}
