using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class TestDataReader
    {
        private static readonly ResourceManager resourceManager;

        static TestDataReader()
        {
            string environment = Environment.GetEnvironmentVariable("environment");
            resourceManager = new ResourceManager("YourNamespace.Resources." + environment, typeof(TestDataReader).Assembly);
        }

        public static string GetTestData(string key)
        {
            return resourceManager.GetString(key, CultureInfo.InvariantCulture);
        }
    }
}
