using aliexpress_e2e.Framework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace aliexpress_e2e.Framework.PageObjects
{
    public class ProductPage
    {
        IWebDriver driver;
        String strQty;
        By qtyInStock = By.XPath("//div[@class='product-quantity-tip']");
        By popUpInternalPages = By.ClassName("newuser-container");
        By popUpCloseButtonInternalPages = By.ClassName("next-dialog-close");
        By itemsToIterate = By.CssSelector("div[class='sku-title']");
        By buyNowButton = By.CssSelector("button[class*=buynow");
        By aliLogin = By.CssSelector("div[class=next-dialog-body");

        public ProductPage(IWebDriver driver) => this.driver = driver;

        public void ValidateStock()
        {
            WaitUtilities.ExplicitlyWait(driver, popUpInternalPages);
            try
            {
                driver.FindElement(popUpCloseButtonInternalPages).Click();
            }
            catch
            {
                Console.Write("Internal popup was not displayed, this is ok");
            }
            strQty = driver.FindElement(qtyInStock).Text;
            strQty = strQty.Substring(0, 2);
            strQty = strQty.Replace("\\D+", "");
            if(int.Parse(strQty) > 0)
            {
                Console.WriteLine("Item has stock, this concludes the test");
            }
            else
            {
                Assert.Fail("Product is not in stock");
            }
        }

        public void BuyNowFlow()
        {
            ReadOnlyCollection<IWebElement> listOfPresentElements = driver.FindElements(itemsToIterate);
            Console.WriteLine(listOfPresentElements);

        }
    }
}
