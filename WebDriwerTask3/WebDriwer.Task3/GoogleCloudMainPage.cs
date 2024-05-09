using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriwer.Task3
{
    public class GoogleCloudMainPage : BasePage
    {
        private static readonly string MainPageUrl = "https://cloud.google.com/";

        private By MagnifyingGlassIcon = By.XPath("//div[@class='YSM5S']");
        private By SearchInputField = By.XPath("//input[@class='qdOxv-fmcmS-wGMbrd']");
        private By SearchInitButton = By.XPath("//i[@class='google-material-icons PETVs PETVs-OWXEXe-UbuQg']");

        public GoogleCloudMainPage(IWebDriver webDriver) : base(webDriver)
        {
            WebDriver.Navigate().GoToUrl(MainPageUrl);
        }

        public override BasePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(MainPageUrl);
            return this;
        }

        public GoogleCloudMainPage ClickMagnifyingGlassIcon()
        {
            WebDriver.FindElement(MagnifyingGlassIcon).Click();
            return this;
        }

        public GoogleCloudMainPage InputSearchRequest(string searchRequest)
        {
            WebDriver.FindElement(SearchInputField).SendKeys(searchRequest);
            return this;
        }

        public GoogleCloudSearchResultPage InitiateSearch()
        {
            WebDriver.FindElement(SearchInitButton).Click();
            return new GoogleCloudSearchResultPage(WebDriver);
        }
    }
}
