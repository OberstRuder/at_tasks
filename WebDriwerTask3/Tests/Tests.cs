using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriwer.Task3;

namespace Tests
{
    public class Tests
    {
        protected IWebDriver WebDriver;

        [SetUp]
        public void SetUp()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            WebDriver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchTest()
        {
            var page = new GoogleCloudMainPage(WebDriver);

            var resultPage = InitiateCalculatorSearch(page);

            var calculator = FillOutFormAndCalculate(resultPage);

            string costFromCalculator = calculator.GetEstimateCost();
            calculator.ClickAddToEstimateOnCostDetailsButton().ClickCloseButton();

            var shareCostPopUp = calculator.ClickShareButton();
            string costFromSharePopUp = shareCostPopUp.GetTotalEstimatedCost();

            ClassicAssert.AreEqual(costFromCalculator + " / month", costFromSharePopUp);

            var summaryPage = shareCostPopUp.ClickEstimateSummaryButton();

            AssertSummaryPage(costFromCalculator, summaryPage);
        }

        private void AssertSummaryPage(string costFromCalculator, CostEstimateSummaryPage summaryPage)
        {
            ClassicAssert.AreEqual(costFromCalculator, summaryPage.GetTotalEstimatedCost());
            ClassicAssert.AreEqual("4", summaryPage.GetNumberOfInstances());
            ClassicAssert.AreEqual("Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)", summaryPage.GetOperationSystem());
            ClassicAssert.AreEqual("Regular", summaryPage.GetProvisioningModel());
            ClassicAssert.AreEqual("n1-standard-8, vCPUs: 8, RAM: 30 GB", summaryPage.GetMachineType());
            ClassicAssert.AreEqual("NVIDIA Tesla V100", summaryPage.GetModelGPU());
            ClassicAssert.AreEqual("1", summaryPage.GetNumberOfGPUs());
            ClassicAssert.AreEqual("2x375 GB", summaryPage.GetLocalSSD());
            ClassicAssert.AreEqual("Netherlands (europe-west4)", summaryPage.GetRegion());
            ClassicAssert.AreEqual("1 year", summaryPage.GetCommittedUse());
        }

        private GoogleCloudPlatformPricingCalculator FillOutFormAndCalculate(GoogleCloudSearchResultPage resultPage)
        {
            return resultPage
                .ClickCalculator()
                .ClickAddToEstimateButton()
                .ClickComputerEngineButton()
                .InsertNumberOfInstances("4")
                .SelectOperationSystem("Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)")
                .SelectRegularProvisionModel()
                .SelectMachineFamily("General Purpose")
                .SelectSeries("N1")
                .SelectMachineType("n1-standard-8")
                .SwitchAddGPUs()
                .SelectModelGPU("NVIDIA Tesla V100")
                .SelectNumberOfGPUs("1")
                .SelectLocalSSD("2x375 GB")
                .SelectRegion("Netherlands (europe-west4)")
                .SelectOneYearCommittedUse();
        }

        private GoogleCloudSearchResultPage InitiateCalculatorSearch(GoogleCloudMainPage page)
        {
            return page
                .ClickMagnifyingGlassIcon()
                .InputSearchRequest("Google Cloud Platform Pricing Calculator")
                .InitiateSearch();
        }

        [TearDown]
        public void TearDown()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }
    }
}
