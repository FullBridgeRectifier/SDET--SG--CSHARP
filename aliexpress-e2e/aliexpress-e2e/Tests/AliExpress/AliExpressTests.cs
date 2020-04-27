using aliexpress_e2e.Framework;
using aliexpress_e2e.Framework.PageObjects;
using aliexpress_e2e.Framework.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliexpress_e2e.Tests.AliExpress 
{
    [TestFixture]
    public class AliExpressTests : Base
    {

        [Test]
        public static void Aliexpress_E2E()
        {
            LandingPage landing = new LandingPage(driver);            
            landing.ClosePopUpIfShown();
            landing.SearchItem("iphone");
            landing.ClickSearchButton();
            SearchPage search = new SearchPage(driver);
            search.NavigateToSecondPage();
            search.ClickProduct();
            ProductPage product = new ProductPage(driver);
            BrowserUtilities.SwitchToNewestTab();
            product.ValidateStock();
        }




    }
}
