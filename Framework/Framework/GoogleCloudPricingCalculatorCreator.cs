using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework
{
    public class GoogleCloudPricingCalculatorCreator
    {
        private static readonly string SearchRequest = "Google Cloud Platform Pricing Calculator";
        private static readonly string SearchPageTitle = "Cloud Computing Services | Google Cloud";
        private static readonly string NumberOfInstances = "4";
        private static readonly string OperationSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
        private static readonly string ProvisionModel = "Regular";
        private static readonly string MachineFamily = "General Purpose";
        private static readonly string Series = "N1";
        private static readonly string MachineType = "n1-standard-8, vCPUs: 8, RAM: 30 GB";
        private static readonly string AddGpu = "true";
        private static readonly string ModelGpu = "NVIDIA Tesla V100";
        private static readonly string NumberOfGpu = "1";
        private static readonly string LocalSsd = "2x375 GB";
        private static readonly string Region = "Netherlands (europe-west4)";
        private static readonly string CommittedUse = "1 year";

        public static string GetSearchRequest()
        {
            return SearchRequest;
        }

        public static string GetSearchPageTitle()
        {
            return SearchPageTitle;
        }

        public static GoogleCloudPricingCalculator CreateGoogleCloudPricingCalculatorModel()
        {
            return new GoogleCloudPricingCalculator
            {
                NumberOfInstances = NumberOfInstances,
                OperatingSystem = OperationSystem,
                ProvisioningModel = ProvisionModel,
                MachineFamily = MachineFamily,
                Series = Series,
                MachineType = MachineType,
                AddGPUs = bool.Parse(AddGpu),
                ModelGPU = ModelGpu,
                NumberOfGPUs = NumberOfGpu,
                LocalSSD = LocalSsd,
                Region = Region,
                CommittedUse = CommittedUse
            };
        }

        public static GoogleCloudPlatformPricingCalculator CreateGoogleCloudPricingCalculatorPage(GoogleCloudSearchResultPage resultPage, GoogleCloudPricingCalculator model, IWebDriver driver)
        {
            var calculatorPage = resultPage
                .ClickCalculator()
                .ClickAddToEstimateButton()
                .ClickComputerEngineButton();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(c => c.FindElement(By.XPath("//*[@id='c11']")));

            calculatorPage
                .InsertNumberOfInstances(model.NumberOfInstances)
                .SelectOperationSystem(model.OperatingSystem);

            SelectProvisionModel(calculatorPage, model.ProvisioningModel);
            SelectMachineFamily(calculatorPage, model.MachineFamily);
            SelectSeries(calculatorPage, model.Series);
            SelectMachineType(calculatorPage, model.MachineType);
            SelectGPUs(calculatorPage, model, driver);
            SelectRegion(calculatorPage, model.Region);
            SelectCommittedUse(calculatorPage, model.CommittedUse);

            return calculatorPage;
        }

        private static void SelectProvisionModel(GoogleCloudPlatformPricingCalculator calculatorPage, string provisionModel)
        {
            switch (provisionModel)
            {
                case "Regular":
                    calculatorPage.SelectRegularProvisionModel();
                    break;
                case "Spot":
                    calculatorPage.SelectSpotProvisionModel();
                    break;
            }
        }

        public static void SelectMachineFamily(GoogleCloudPlatformPricingCalculator calculatorPage, string machineFamily)
        {
            calculatorPage.SelectMachineFamily(machineFamily);
        }

        public static void SelectSeries(GoogleCloudPlatformPricingCalculator calculatorPage, string machineType)
        {
            calculatorPage.SelectSeries(machineType);
        }

        private static void SelectMachineType(GoogleCloudPlatformPricingCalculator calculatorPage, string machineType)
        {
            var pattern = new Regex("^([^,]+)");
            var matcher = pattern.Match(machineType);
            if (matcher.Success)
            {
                calculatorPage.SelectMachineType(matcher.Groups[1].Value);
            }
        }

        private static void SelectGPUs(GoogleCloudPlatformPricingCalculator calculatorPage, GoogleCloudPricingCalculator model, IWebDriver driver)
        {
            if (model.AddGPUs)
            {
                calculatorPage
                    .SwitchAddGPUs();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(c => c.FindElement(By.XPath("//span[text() = 'GPU Model']/ancestor::div[@class='VfPpkd-TkwUic']")));

                calculatorPage
                    .SelectModelGPU(model.ModelGPU)
                    .SelectNumberOfGPUs(model.NumberOfGPUs)
                    .SelectLocalSSD(model.LocalSSD);
            }
        }

        private static void SelectRegion(GoogleCloudPlatformPricingCalculator calculatorPage, string region)
        {
            calculatorPage.SelectRegion(region);
        }

        private static void SelectCommittedUse(GoogleCloudPlatformPricingCalculator calculatorPage, string committedUse)
        {
            switch (committedUse)
            {
                case "None":
                    calculatorPage.SelectNoneCommittedUse();
                    break;
                case "1 year":
                    calculatorPage.SelectOneYearCommittedUse();
                    break;
                case "3 years":
                    calculatorPage.SelectThreeYearsCommittedUse();
                    break;
            }
        }
    }
}
