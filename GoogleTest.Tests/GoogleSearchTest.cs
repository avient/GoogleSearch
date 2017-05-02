using System;
using GoogleTest.Web.Forms;
using NUnit.Framework;

namespace GoogleTest.Tests
{
    public class GoogleSearchTest : BaseTest
    {
        private const string WordToSearch = "microsoft";
        private const int SearchResultsCount = 1000000000;

        [Test]
        public void RunTest()
        {
            var gp = new GooglePage();
            gp.SearchFor(WordToSearch);

            var actualSearchResultsCount = gp.GetSearchResultsCount();
            Console.WriteLine($"Asserting results more than :: '{SearchResultsCount}'");
            Assert.AreEqual(true, actualSearchResultsCount > SearchResultsCount,
                $"Search count '{actualSearchResultsCount}' are less than '{SearchResultsCount}'");

            Console.WriteLine($"Asserting results contain :: '{WordToSearch}'");
            var i = 1;

            Assert.Multiple(() =>
            {
                foreach (var res in gp.GetAllResultsTextList())
                {
                    Assert.AreEqual(true, res.ToLower().Contains(WordToSearch.ToLower()),
                        $"Search result '{i}' doesn't contain '{WordToSearch}' word");
                    i++;
                }
            });
            
        }
    }
}