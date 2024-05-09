using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriwer.Task3
{
    public class AddToEstimatePopUp : BasePage
    {
        private IWebElement ComputerEngineButton;
        private IWebElement CloseButton;

        public AddToEstimatePopUp(IWebDriver webDriver) : base(webDriver)
        {
            ComputerEngineButton = WebDriver.FindElement(By.XPath("//div[@class='d5NbRd-EScbFb-JIbuQc PtwYlf']"));
            CloseButton = WebDriver.FindElement(By.XPath("//button[@class='pYTkkf-Bz112c-LgbsSe bwApif-zMU9ub']"));
        }

        public override BasePage OpenPage()
        {
            throw new Exception("This pop-up opens after clicking on the \"Add to estimate\" button and can not be accessed directly ");
        }

        public GoogleCloudPlatformPricingCalculator ClickComputerEngineButton()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, ComputerEngineButton, 10);
            ComputerEngineButton.Click();
            return new GoogleCloudPlatformPricingCalculator(WebDriver);
        }

        public GoogleCloudPlatformPricingCalculator ClickCloseButton()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, CloseButton, 10);
            CloseButton.Click();
            return new GoogleCloudPlatformPricingCalculator(WebDriver);
        }
    }
}
