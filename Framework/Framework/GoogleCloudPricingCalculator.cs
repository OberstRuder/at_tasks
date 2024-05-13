using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Framework
{
    public class GoogleCloudPricingCalculator
    {
        [JsonPropertyName("NumberOfInstances")]
        public string NumberOfInstances { get; init; }

        [JsonPropertyName("OperatingSystem")]
        public string OperatingSystem { get; init; }

        [JsonPropertyName("ProvisioningModel")]
        public string ProvisioningModel { get; init; }

        [JsonPropertyName("MachineFamily")]
        public string MachineFamily { get; init; }

        [JsonPropertyName("Series")]
        public string Series { get; init; }

        [JsonPropertyName("MachineType")]
        public string MachineType { get; init; }

        [JsonPropertyName("AddGPUs")]
        public bool AddGPUs { get; init; }

        [JsonPropertyName("ModelGPU")]
        public string ModelGPU { get; init; }

        [JsonPropertyName("NumberOfGPUs")]
        public string NumberOfGPUs { get; init; }

        [JsonPropertyName("LocalSSD")]
        public string LocalSSD { get; init; }

        [JsonPropertyName("Region")]
        public string Region { get; init; }

        [JsonPropertyName("CommittedUse")]
        public string CommittedUse { get; init; }

        [JsonPropertyName("EstimateCost")]
        public string EstimateCost { get; set; }
    }
}
