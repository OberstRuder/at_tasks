using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using Framework;
using FluentAssertions;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class Tests
    {
        protected IWebDriver Driver;

        public static void AssertCalculatorModelWithSummaryResponse(GoogleCloudPricingCalculator pricingCalculator, CostEstimateSummaryPage summaryPage)
        {
            pricingCalculator.EstimateCost.Should().Be(summaryPage.GetTotalEstimatedCost());
            pricingCalculator.NumberOfInstances.Should().Be(summaryPage.GetNumberOfInstances());
            pricingCalculator.OperatingSystem.Should().Be(summaryPage.GetOperationSystem());
            pricingCalculator.ProvisioningModel.Should().Be(summaryPage.GetProvisioningModel());
            pricingCalculator.MachineType.Should().Be(summaryPage.GetMachineType());
            pricingCalculator.ModelGPU.Should().Be(summaryPage.GetModelGPU());
            pricingCalculator.NumberOfGPUs.Should().Be(summaryPage.GetNumberOfGPUs());
            pricingCalculator.LocalSSD.Should().Be(summaryPage.GetLocalSSD());
            pricingCalculator.Region.Should().Be(summaryPage.GetRegion());
            pricingCalculator.CommittedUse.Should().Be(summaryPage.GetCommittedUse());
        }

        [SetUp]
        public void SetUp()
        {
            Driver = DriveSingleton.GetDriver();
        }

        [Test]
        public void SearchTest()
        {
            var page = new GoogleCloudMainPage(Driver);

            var resultPage = InitiateCalculatorSearch(page);

            var pricingCalculator = GoogleCloudPricingCalculatorCreator.CreateGoogleCloudPricingCalculatorModel();
            var calculator = GoogleCloudPricingCalculatorCreator.CreateGoogleCloudPricingCalculatorPage(resultPage, pricingCalculator, Driver);

            string costFromCalculator = calculator.GetEstimateCost();
            calculator.ClickAddToEstimateOnCostDetailsButton().ClickCloseButton();
            pricingCalculator.EstimateCost = costFromCalculator;

            var shareCostPopUp = calculator.ClickShareButton();
            string costFromSharePopUp = shareCostPopUp.GetTotalEstimatedCost();

            ClassicAssert.AreEqual(costFromCalculator + " / month", costFromSharePopUp);

            var summaryPage = shareCostPopUp.ClickEstimateSummaryButton();

            AssertCalculatorModelWithSummaryResponse(pricingCalculator, summaryPage);
        }

        private GoogleCloudSearchResultPage InitiateCalculatorSearch(GoogleCloudMainPage page)
        {
            return page
                .ClickMagnifyingGlassIcon()
                .InputSearchRequest(GoogleCloudPricingCalculatorCreator.GetSearchRequest())
                .InitiateSearch();
        }

        [Test]
        public void ErrorTestForScreen()
        {
            var page = new GoogleCloudMainPage(Driver);
            var result = page
                .ClickMagnifyingGlassIcon()
                .InputSearchRequest(GoogleCloudPricingCalculatorCreator.GetSearchRequest())
                .InitiateSearch();

            ClassicAssert.AreEqual(result.GetPagetitle(), GoogleCloudPricingCalculatorCreator.GetSearchPageTitle());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string directory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string screenshotPath = Path.Combine(directory, "screenshot-" + timestamp + ".png");
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotPath);
                Console.WriteLine("Screenshot saved: " + screenshotPath);
            }
            DriveSingleton.CloseDriver();
            Driver = null;
        }
    }
}
