using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ODH_UnitTesting
{
    

    [TestClass]
    public class UnitTest1
    {
        private List<Result> _resultSet;


        [TestInitialize]
        public void Setup()
        {
            var settings = File.ReadAllText(@".\appsettings.json");
            var settingsObject = JsonConvert.DeserializeObject<Settings>(settings);

            if (settingsObject.StatisticsFileName.Contains("__ResultsFolder__"))
            {
                settingsObject.StatisticsFileName = settingsObject.StatisticsFileName.Replace("__ResultsFolder__", ".");
            }

            var text = File.ReadAllText(settingsObject.StatisticsFileName);

            text = "[" + Regex.Replace(text.Remove(text.Length - 1).Remove(0, 1), "\".*: {", "{") + "]";

            _resultSet = (JsonConvert.DeserializeObject<List<Result>>(text));

        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void EFormSubmit()
        {
            checkResults( "eForm Submit" );
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void GetStateCodes181()
        {
            checkResults("/Barcode/GetStateCodes-181");
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void GetStateCodes182()
        {
            checkResults("/Barcode/GetStateCodes-182");
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void Auth180()
        {
            checkResults("/Barcode/Auth-180");
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void Auth1801()
        {
            checkResults("/Barcode/Auth-180-1");
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void Auth1800()
        {
            checkResults("/Barcode/Auth-180-0");
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void ohid70()
        {
            checkResults("/wps/portal/gov/ohid-7-0");
        }



        public void checkResults(string title, int errorPct = 10, int meanResTime = 1000)
        {
            var result = _resultSet.FirstOrDefault(r => r.Transaction == title);

            Assert.IsTrue(result != null, $"No Results for {title}");
            Assert.IsTrue(result.ErrorPct <= errorPct, $"Error percentage for {title} was {result.ErrorPct.ToString("N2")}% and expected {errorPct}");
            Assert.IsTrue(result.MeanResTime <= meanResTime, $"Mean time for {title} was {result.MeanResTime.ToString("N2")}ms and expected {meanResTime.ToString("N2")}ms");
        }
    }
}
