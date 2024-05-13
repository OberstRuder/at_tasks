using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class CostEstimateSummaryPage : BasePage
    {
        private IWebElement TotalEstimatedCost;
        private IWebElement NumberOfInstances;
        private IWebElement OperatingSystem;
        private IWebElement ProvisioningModel;
        private IWebElement MachineType;
        private IWebElement ModelGPU;
        private IWebElement NumberOfGPUs;
        private IWebElement LocalSSD;
        private IWebElement Region;
        private IWebElement CommittedUse;

        public CostEstimateSummaryPage(IWebDriver webDriver) : base(webDriver)
        {
            TotalEstimatedCost = WebDriver.FindElement(By.XPath("//h4[@class='n8xu5 Nh2Phe D0aEmf']"));
            NumberOfInstances = WebDriver.FindElement(By.XPath("//span[text()='Number of Instances']/following-sibling::span[@class='Kfvdz']"));
            OperatingSystem = WebDriver.FindElement(By.XPath("//span[text()='Operating System / Software']/following-sibling::span[@class='Kfvdz']"));
            ProvisioningModel = WebDriver.FindElement(By.XPath("//span[text()='Provisioning Model']/following-sibling::span[@class='Kfvdz']"));
            MachineType = WebDriver.FindElement(By.XPath("//span[text()='Machine type']/following-sibling::span[@class='Kfvdz']"));
            ModelGPU = WebDriver.FindElement(By.XPath("//span[text()='GPU Model']/following-sibling::span[@class='Kfvdz']"));
            NumberOfGPUs = WebDriver.FindElement(By.XPath("//span[text()='Number of GPUs']/following-sibling::span[@class='Kfvdz']"));
            LocalSSD = WebDriver.FindElement(By.XPath("//span[text()='Local SSD']/following-sibling::span[@class='Kfvdz']"));
            Region = WebDriver.FindElement(By.XPath("//span[text()='Region']/following-sibling::span[@class='Kfvdz']"));
            CommittedUse = WebDriver.FindElement(By.XPath("//span[text()='Committed use discount options']/following-sibling::span[@class='Kfvdz']"));
        }

        public override BasePage OpenPage()
        {
            throw new System.NotImplementedException("The page opens in response for getting summary cost and can not be accessed directly.");
        }

        public string GetTotalEstimatedCost()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, TotalEstimatedCost, 10);
            return TotalEstimatedCost.Text;
        }

        public string GetNumberOfInstances()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, NumberOfInstances, 10);
            return NumberOfInstances.Text;
        }

        public string GetOperationSystem()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, OperatingSystem, 10);
            return OperatingSystem.Text;
        }

        public string GetProvisioningModel()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, ProvisioningModel, 10);
            return ProvisioningModel.Text;
        }

        public string GetMachineType()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, MachineType, 10);
            return MachineType.Text;
        }

        public string GetModelGPU()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, ModelGPU, 10);
            return ModelGPU.Text;
        }

        public string GetNumberOfGPUs()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, NumberOfGPUs, 10);
            return NumberOfGPUs.Text;
        }

        public string GetLocalSSD()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, LocalSSD, 10);
            return LocalSSD.Text;
        }

        public string GetRegion()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, Region, 10);
            return Region.Text;
        }

        public string GetCommittedUse()
        {
            WaitUtil.WaitForElementVisibility(WebDriver, CommittedUse, 10);
            return CommittedUse.Text;
        }

        public bool IsModelGPUDisplayed()
        {
            try
            {
                return NumberOfGPUs.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
