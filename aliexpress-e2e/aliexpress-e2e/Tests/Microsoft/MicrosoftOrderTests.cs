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
        public void Test()
        {
            var homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.ValidateMenu();
            homePage.UseMenu("windows");
            

        }
    }
}
