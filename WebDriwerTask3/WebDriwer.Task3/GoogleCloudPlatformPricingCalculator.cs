using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriwer.Task3
{
    public class GoogleCloudPlatformPricingCalculator : BasePage
    {
        private static readonly string CalculatorPage = "https://cloud.google.com/products/calculator";

        private By AddToEstimateButton = By.XPath("//span[@class='UywwFc-vQzf8d']");
        private By NumberOfInstances = By.XPath("//*[@id='c11']");
        private By OperatingSystemDropdown = By.XPath("//span[text() = 'Operating System / Software']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By RegularProvisioningModel = By.XPath("//label[text()='Regular']");
        private By MachineFamilyDropDown = By.XPath("//span[text() = 'Machine Family']/ancestor::div[@class='O1htCb-H9tDt PPUDSe t8xIwc']");
        private By SeriesDropDown = By.XPath("//span[text() = 'Series']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By MachineTypeDropDown = By.XPath("//span[text() = 'Machine type']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By AddGPUsSwitcher = By.XPath("//span[@class='eBlXUe-hywKDc']/ancestor::button[@aria-label='Add GPUs']");
        private By ModelGPUDropdown = By.XPath("//span[text() = 'GPU Model']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By NumberOfGPUsDropdown = By.XPath("//span[text() = 'Number of GPUs']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By LocalSSDDropdown = By.XPath("//span[text() = 'Local SSD']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By RegionDropdown = By.XPath("//span[text() = 'Region']/ancestor::div[@class='VfPpkd-TkwUic']");
        private By OneYearCommittedUseButton = By.XPath("//label[text()='1 year']");
        private By EstimateCost = By.XPath("//label[@class='gt0C8e MyvX5d D0aEmf']");
        private By ShareButton = By.XPath("//button[@aria-label='Open Share Estimate dialog']");
        private By AddToEstimateOnCostDetailsButton = By.XPath("//button[@class='AeBiU-LgbsSe AeBiU-LgbsSe-OWXEXe-Bz112c-M1Soyc AeBiU-LgbsSe-OWXEXe-dgl2Hf AeBiU-LgbsSe-OWXEXe-wdeprb-MD85tf-DKzjMe VVEJ3d']");

        public GoogleCloudPlatformPricingCalculator(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override BasePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(CalculatorPage);
            return this;
        }

        public AddToEstimatePopUp ClickAddToEstimateButton()
        {
            WebDriver.FindElement(AddToEstimateButton).Click();
            return new AddToEstimatePopUp(WebDriver);
        }

        public GoogleCloudPlatformPricingCalculator InsertNumberOfInstances(string number)
        {
            WebDriver.FindElement(NumberOfInstances).Clear();
            WebDriver.FindElement(NumberOfInstances).SendKeys(number);
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectOperationSystem(string operationSystem)
        {
            WebDriver.FindElement(OperatingSystemDropdown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + operationSystem + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-aJasdd-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-gk6SMd VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 10);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectRegularProvisionModel()
        {
            WebDriver.FindElement(RegularProvisioningModel).Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectMachineFamily(string machineFamily)
        {
            WebDriver.FindElement(MachineFamilyDropDown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + machineFamily + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-hjZysc-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-gk6SMd VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-aSi1db-MCEKJb']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 10);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectSeries(string series)
        {
            WebDriver.FindElement(SeriesDropDown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + series + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-hjZysc-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-gk6SMd VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-aSi1db-MCEKJb']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 15);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectMachineType(string machineType)
        {
            WebDriver.FindElement(MachineTypeDropDown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + machineType + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-hjZysc-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-aSi1db-MCEKJb']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 15);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SwitchAddGPUs()
        {
            WebDriver.FindElement(AddGPUsSwitcher).Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectModelGPU(string modelGPU)
        {
            WebDriver.FindElement(ModelGPUDropdown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + modelGPU + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-aJasdd-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 10);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectNumberOfGPUs(string number)
        {
            WebDriver.FindElement(NumberOfGPUsDropdown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + number + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-aJasdd-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-gk6SMd VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 15);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectLocalSSD(string value)
        {
            WebDriver.FindElement(LocalSSDDropdown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + value + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-aJasdd-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 10);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectRegion(string region)
        {
            WebDriver.FindElement(RegionDropdown).Click();

            var option = WebDriver.FindElement(By.XPath("//span[text() = '" + region + "']/ancestor::li[@class='MCs1Pd HiC7Nc VfPpkd-OkbHre VfPpkd-aJasdd-RWgCYc-wQNmvb VfPpkd-rymPhb-ibnC6b VfPpkd-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc']"));
            WaitUtil.WaitForElementVisibility(WebDriver, option, 10);
            option.Click();
            return this;
        }

        public GoogleCloudPlatformPricingCalculator SelectOneYearCommittedUse()
        {
            WebDriver.FindElement(OneYearCommittedUseButton).Click();
            return this;
        }

        public AddToEstimatePopUp ClickAddToEstimateOnCostDetailsButton()
        {
            WebDriver.FindElement(AddToEstimateOnCostDetailsButton).Click();
            return new AddToEstimatePopUp(WebDriver);
        }

        public ShareCostPopUp ClickShareButton()
        {
            WebDriver.FindElement(ShareButton).Click();
            return new ShareCostPopUp(WebDriver);
        }

        public string GetEstimateCost()
        {
            System.Threading.Thread.Sleep(2000);
            return WebDriver.FindElement(EstimateCost).Text;
        }
    }
}
