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
using OpenQA.Selenium.Support.UI;

namespace aliexpress_e2e.Framework.PageObjects.Microsoft
{
    class CartPage
    {
        
        //Driver
        IWebDriver driver;
        //Locators
        public string pricePlus20;
        public string pricePerQty;
        public double pricePlus20Cart;
        public double pricePlus20Calculated;
        By QtySelector = By.CssSelector("select[aria-label='Visual Studio Professional Subscription  Quantity selection']");
        By CartPriceBy = By.CssSelector("span[itemprop='price']");
        [FindsBy(How = How.CssSelector, Using = "span[itemprop='price']")]
        public IWebElement CartPrice { get; set; }

        public CartPage(IWebDriver driver) => this.driver = driver;

        public void ValidatePricingAcrossAllPages()
        {
            WaitUtilities.ExplicitlyWait(driver, CartPriceBy);
            try
            {
                if(CartPrice.Text.Equals(SearchPage.storedPrice))
                {
                    if (CartPrice.Text.Equals(ProductPage.storedPriceProductPage))
                    {
                        Console.WriteLine($"Prices matched succesfully: {CartPrice.Text} {SearchPage.storedPrice} {ProductPage.storedPriceProductPage}");
                    }
                    else
                    {
                        Assert.Fail($"Prices are not consistent: {CartPrice.Text} is not the same as the search page stored price: {ProductPage.storedPriceProductPage} ");
                    }
                }
                else
                {
                    Assert.Fail($"Prices are not consistent: {CartPrice.Text} is not the same as the search page stored price: {SearchPage.storedPrice} ");
                }
            }
            catch
            {
                Assert.Fail("Could not find the price inside the cart page");
            }
        }

        public void SelectQtyAndValidatePrice()
        {
            WaitUtilities.ExplicitlyWait(driver, QtySelector);
            try
            {
                var selection = driver.FindElement(QtySelector);
                var selectElement = new SelectElement(selection);
                selectElement.SelectByValue("20");
                    try
                    {
                        driver.Navigate().Refresh();
                        pricePlus20 = driver.FindElement(CartPriceBy).Text;
                        int lenght20 = pricePlus20.Length;
                        pricePlus20 = pricePlus20.Substring(1, lenght20 - 1);
                        pricePerQty = ProductPage.storedPriceProductPage;
                        int lenght1 = pricePerQty.Length;
                        pricePerQty = pricePerQty.Substring(1, lenght1 - 1);
                        pricePlus20Cart = Convert.ToDouble(pricePlus20)*20;
                        pricePlus20Calculated = Convert.ToDouble(pricePerQty) * 20;
                        Assert.AreEqual(pricePlus20Cart, pricePlus20Calculated);
                    }
                    catch
                    {
                        Assert.Fail("Couldnt check the updated pricing, verify cart");
                    }
            }
            catch
            {
                Assert.Fail("Could not find or select the dropdown list for the QTY");
            }
        }
    }
}
