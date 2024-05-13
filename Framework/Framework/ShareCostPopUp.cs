using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ShareCostPopUp : BasePage
    {
        private IWebElement OpenEstimateSummaryButton;
        private IWebElement TotalEstimatedCost;

        public ShareCostPopUp(IWebDriver webDriver) : base(webDriver)
        {
            OpenEstimateSummaryButton = WebDriver.FindElement(By.XPath("//a[@class='tltOzc MExMre rP2xkc jl2ntd']"));
            TotalEstimatedCost = WebDriver.FindElement(By.XPath("//div[@class='fbc2ib']/label[@class='gN5n4 MyvX5d D0aEmf']"));
        }

        public override BasePage OpenPage()
        {
            throw new Exception("This pop-up opens after clicking on the \"Share\" button and" +
                    "can not be accessed directly ");
        }

        public CostEstimateSummaryPage ClickEstimateSummaryButton()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, OpenEstimateSummaryButton, 10);
            OpenEstimateSummaryButton.Click();

            string originalTab = WebDriver.CurrentWindowHandle;
            SwitchToTab(originalTab, 2);

            return new CostEstimateSummaryPage(WebDriver);
        }

        public string GetTotalEstimatedCost()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, TotalEstimatedCost, 10);
            return TotalEstimatedCost.Text;
        }
    }
}
