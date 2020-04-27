using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliexpress_e2e.Framework.Utilities
{
    public class BrowserUtilities
    {

        static IWebDriver driver;
        public BrowserUtilities(IWebDriver Wdriver) => driver = Wdriver;

        public static void SwitchToNewestTab()
        {
            var handles = driver.WindowHandles;
            SwitchToWindowHandle(handles[handles.Count - 1]);
        }

        public static void SwitchToWindowHandle(string handle)
        {
            driver.SwitchTo().Window(handle);
        }
    }
}
