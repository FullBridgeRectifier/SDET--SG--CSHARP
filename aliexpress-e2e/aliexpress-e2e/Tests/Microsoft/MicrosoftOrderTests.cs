using aliexpress_e2e.Framework;
using aliexpress_e2e.Framework.PageObjects.Microsoft;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliexpress_e2e.Tests.Microsoft
{
    class MicrosoftOrderTests : Base
    {

        [Test]
        public void UnoSquareTest()
        {
            var homePage = new HomePage(driver);
            PageFactory.InitElements(driver, homePage);
            homePage.ValidateMenu();
            homePage.UseMenu("windows");

            var windowsPage = new WindowsPage(driver);
            PageFactory.InitElements(driver, windowsPage);
            windowsPage.ValidateHover();
            windowsPage.ValidateSearch();

            var searchPage = new SearchPage(driver);
            PageFactory.InitElements(driver, searchPage);
            searchPage.ValidateSearch();

            var productPage = new ProductPage(driver);
            PageFactory.InitElements(driver, productPage);
            productPage.ValidateAndMoveForward();

            var cartPage = new CartPage(driver);
            PageFactory.InitElements(driver, cartPage);
            cartPage.ValidatePricingAcrossAllPages();
            cartPage.SelectQtyAndValidatePrice();
        }
    }
}
