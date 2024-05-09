using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriwer.Task3
{
    public class GoogleCloudSearchResultPage : BasePage
    {
        private IWebElement Calculator;

        public GoogleCloudSearchResultPage(IWebDriver webDriver) : base(webDriver)
        {
            Calculator = WebDriver.FindElement(By.XPath("//span[contains(text(), 'calculator')]/ancestor::div[@class='x9K9hf wVBoU']//a[@class='K5hUy']"));
        }

        public override BasePage OpenPage()
        {
            throw new Exception("The page opens in response to the search request and should not be accessed directly.");
        }

        public GoogleCloudPlatformPricingCalculator ClickCalculator()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, Calculator, 15);
            Calculator.Click();
            return new GoogleCloudPlatformPricingCalculator(WebDriver);
        }
    }
}
