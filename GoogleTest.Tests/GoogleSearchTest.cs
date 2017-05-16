using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using GoogleTest.Infrastructure;
using GoogleTest.Web.Forms;
using NUnit.Framework;

namespace GoogleTest.Tests
{
    public class GoogleSearchTest : BaseTest
    {
        [Test, TestCaseSource(nameof(GetGoogleSearchTestData))]
        public void SearchAndAssertSearchCountTest(string wordToSearch, long searchResultsCount)
        {
            var gp = new GooglePage();
            gp.SearchFor(wordToSearch);

            var actualSearchResultsCount = gp.GetSearchResultsCount();
            Console.WriteLine($"Asserting results more than :: '{searchResultsCount}'");
            Assert.AreEqual(true, actualSearchResultsCount > searchResultsCount,
                $"Search count '{actualSearchResultsCount}' are less than '{searchResultsCount}'");

            Console.WriteLine($"Asserting results contain :: '{wordToSearch}'");
            var i = 1;

            Assert.Multiple(() =>
            {
                foreach (var res in gp.GetAllResultsTextList())
                {
                    Assert.AreEqual(true, res.ToLower().Contains(wordToSearch.ToLower()),
                        $"Search result '{i}' doesn't contain '{wordToSearch}' word");
                    i++;
                }
            });
        }

        private static IEnumerable<object[]> GetGoogleSearchTestData()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", Configuration.GetTestDataSet()));
            var xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot == null) yield break;
            foreach (XmlNode xnode in xmlRoot)
            {
                if (xnode.Attributes == null) continue;
                var wordToSearch = xnode.Attributes.GetNamedItem("wordToSearch").Value;
                var searchResultsCount = Convert.ToInt64(xnode.Attributes.GetNamedItem("searchResultsCount").Value);
                yield return new object[] {wordToSearch, searchResultsCount};
            }
        }
    }
}