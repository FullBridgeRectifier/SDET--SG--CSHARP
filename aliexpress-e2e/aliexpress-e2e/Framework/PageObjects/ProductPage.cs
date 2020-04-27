using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliexpress_e2e.Framework.PageObjects
{
    public class ProductPage
    {
        IWebDriver driver;
        String strQty;
        By qtyInStock = By.XPath("//div[@class='product-quantity-tip']");

        public ProductPage(IWebDriver driver) => this.driver = driver;

        public void ValidateStock()
        {
            strQty = driver.FindElement(qtyInStock).Text;
            strQty = strQty.Substring(0, 5);
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
    }
}
