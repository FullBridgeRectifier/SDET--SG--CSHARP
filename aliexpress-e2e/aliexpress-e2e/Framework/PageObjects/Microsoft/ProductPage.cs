using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using aliexpress_e2e.Framework.Utilities;
using System.Threading;
using NUnit.Framework;

namespace aliexpress_e2e.Framework.PageObjects.Microsoft
{
    class ProductPage
    {
        //Wait Locators
        By NewsLetterPopUpBy = By.CssSelector("div[data-m*='DialogEmailNewsletterDialog']");
        //Driver
        IWebDriver driver;
        //Locators
        public static string storedPriceProductPage;
        [FindsBy(How = How.CssSelector, Using = "div[data-m*='DialogEmailNewsletterDialog']")]
        public IWebElement NewsletterPopUp { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[data-m*='DialogEmailNewsletterCloseButton']")]
        public IWebElement CloseNewsletterPopUpButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[id='ProductPrice_productPrice_PriceContainer']")]
        public IWebElement PriceLocator { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button[id='buttonPanel_AddToCartButton']")]
        public IWebElement AddToCartButton { get; set; }
        public ProductPage(IWebDriver driver) => this.driver = driver;

        public void ValidateAndMoveForward()
        {
            try
            {
                WaitUtilities.ExplicitlyWait(driver, NewsLetterPopUpBy);
                CloseNewsletterPopUpButton.Click();
            }
            catch
            {
                Console.WriteLine("Newsletter Popup did not appear, this does not end the test");
            }

            //Asserting price shown is the same one
            try
            {
                ValidatePrices(PriceLocator.Text);
                storedPriceProductPage = PriceLocator.Text;

                try
                {
                    AddToCartButton.Click();
                }catch
                {
                    Assert.Fail("Could not find the click add to cart");
                }
            }
            catch
            {
                Assert.Fail("Could not find the pricing information inside the details page");
            }
        }

        public void ValidatePrices(string detailPrice)
        {
            Assert.AreEqual(SearchPage.storedPrice, detailPrice);
        }
    }
}
