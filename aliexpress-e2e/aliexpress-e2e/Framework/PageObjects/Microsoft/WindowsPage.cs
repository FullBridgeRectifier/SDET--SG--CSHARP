using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using aliexpress_e2e.Framework.Utilities;
using System.Threading;

namespace aliexpress_e2e.Framework.PageObjects.Microsoft
{
    class WindowsPage
    {
        //Wait Locators
        By Win10MenuBy = By.XPath("//button[@id='c-shellmenu_50']");
        By SearchButtonBy = By.CssSelector("button[id='search']");
        By SearchButtonBoxBy = By.CssSelector("input[id='cli_shellHeaderSearchInput']");
        //WebDriver
        IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//button[@id='c-shellmenu_50']")]
        public IWebElement Win10Menu { get; set; }
        [FindsBy(How = How.CssSelector, Using = "ul[data-m*='Windows10_cont']")]
        public IWebElement DropDown { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button[id='search']")]
        public IWebElement SearchButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[id='cli_shellHeaderSearchInput']")]
        public IWebElement SearchBox { get; set; }

        public WindowsPage(IWebDriver driver) => this.driver = driver;

        public void ValidateHover()
        {
            WaitUtilities.ExplicitlyWait(driver, Win10MenuBy);
            Actions actions = new Actions(driver);
            Actions mouseOverButton = actions.MoveToElement(Win10Menu).Click();
            mouseOverButton.Perform();
            IList<IWebElement> options = DropDown.FindElements(By.TagName("li"));
            foreach (var elements in options)
            {
                Console.WriteLine(elements);
            }
        }

        public void ValidateSearch()
        {
            WaitUtilities.ExplicitlyWait(driver, SearchButtonBy);
            Actions actions = new Actions(driver);
            Actions mouseOverSearchButton = actions.MoveToElement(SearchButton).Click();
            mouseOverSearchButton.Perform();
            WaitUtilities.ExplicitlyWait(driver, SearchButtonBoxBy);
            Thread.Sleep(982);
            SearchBox.SendKeys("Visual Studio");
            SearchBox.SendKeys(Keys.Return);
        }
    }
}
