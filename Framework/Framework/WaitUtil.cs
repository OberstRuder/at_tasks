using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    internal class WaitUtil
    {
        public static void WaitForElementVisibility(IWebDriver webDriver, IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(driver => element.Displayed);
        }

        public static void WaitForOpenNewTab(IWebDriver webDriver, int seconds, int numberOfWindows)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(driver => driver.WindowHandles.Count == numberOfWindows);
        }
    }
}
