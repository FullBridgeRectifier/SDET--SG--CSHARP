using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aliexpress_e2e.Framework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace aliexpress_e2e.Framework.PageObjects.Microsoft
{
    class HomePage
    {
        //WaitSelectors
        By UpperMenu365By = By.XPath("//a[@id='shellmenu_0']");
        //IWebDriver
        IWebDriver driver;
        //Selectors
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_0']")]
        public IWebElement UpperMenu365 { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_1']")]
        public IWebElement UpperMenuOffice{ get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_2']")]
        public IWebElement UpperMenuWindows { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_3']")]
        public IWebElement UpperMenuSurface { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_4']")]
        public IWebElement UpperMenuXbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='shellmenu_5']")]
        public IWebElement UpperMenuDeales { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='l1_support']")]
        public IWebElement UpperMenuSupport { get; set; }
        public HomePage(IWebDriver driver) => this.driver = driver;

        public void ValidateMenu()
        {
            try
            {
                WaitUtilities.ExplicitlyWait(driver, UpperMenu365By);
                if (UpperMenu365.Displayed && UpperMenuOffice.Displayed &&
               UpperMenuWindows.Displayed && UpperMenuSurface.Displayed
               && UpperMenuXbox.Displayed && UpperMenuDeales.Displayed
               && UpperMenuSupport.Displayed)
                {
                    Console.WriteLine("Items where validated and found to be present");
                }
            }catch (NoSuchElementException e)
            {
                Console.WriteLine("Menus is missing one of its components, this validation will not end the test but should be checked out: " + e);
            }
            catch (StaleElementReferenceException e)
            {
                Console.WriteLine("StaleElement exception thrown, execution will halt, verify logic " + e);
                Assert.Fail("StaleElement exception thrown, execution will halt, verify logic " + e);
            }
        }

        public void UseMenu(string menu)
        {
            try
            {
                if(menu.Equals("365"))
                {
                    UpperMenu365.Click();
                    return;                  
                }
                if(menu.Equals("office"))
                {
                    UpperMenuOffice.Click();
                    return;
                }
                if (menu.Equals("windows"))
                {
                    UpperMenuWindows.Click();
                    return;
                }
                if (menu.Equals("surface"))
                {
                    UpperMenuSurface.Click();
                    return;
                }
                if (menu.Equals("xbox"))
                {
                    UpperMenuXbox.Click();
                    return;
                }
                if (menu.Equals("deals"))
                {
                    UpperMenuDeales.Click();
                    return;
                }
                if (menu.Equals("support"))
                {
                    UpperMenuSupport.Click();
                    return;
                }
            }
            catch (NoSuchElementException e)
                {
                    Console.WriteLine("Menus is missing one of its components, this validation will not end the test but should be checked out: " + e);
                }
            catch (StaleElementReferenceException e)
                {
                    Assert.Fail("The requested element: " + UpperMenu365.Text + " was found to be stale dumping stacktrace: " + e);
                }
            catch (ElementNotVisibleException e)
                {
                    Assert.Fail("The requested element: " + UpperMenu365.Text + " was not visible dumping stacktrace: " + e);
                }
        }
    }
}
