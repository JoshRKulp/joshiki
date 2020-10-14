using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            var text = File.ReadAllText("./statistics.json");

            text = "[" + Regex.Replace(text.Remove(text.Length - 3).Remove(0, 2), "\".*: {", "{") + "]";

            _resultSet = (JsonConvert.DeserializeObject<List<Result>>(text));
        }

        [TestMethod]
        [TestCategory("E Forms")]
        public void EFormSubmit()
        {
            var result = _resultSet.FirstOrDefault(r => r.Transaction == "eForm Submit");

            Assert.IsTrue(result != null, $"No Results for eForm Submit");
            Assert.IsTrue(result.ErrorPct <= 10, $"Error percentage for eForm Submit was {result.ErrorPct.ToString("N2")}%");
            Assert.IsTrue(result.MeanResTime <= 200, $"Mean time for eForm Submit was {result.MeanResTime.ToString("N2")}ms");
        }
    }
}
