using System;
using System.Collections.Generic;
using System.Linq;
using GoogleTest.Web.Elements;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace GoogleTest.Web.Forms
{
    public class GooglePage : BaseForm
    {
        private const string FormLocator = "//*[@id='main']";
        private const string FormName = "Google page";
        private readonly IWebDriver _driver;

        private TextBox TbxSearchField => new TextBox(By.Id("lst-ib"), "Search field", _driver);
        private Label LblSearchResultsCount => new Label(By.Id("resultStats"), "Search results count", _driver);

        private IEnumerable<Label> SearchResultsOnPage => new Label(By.ClassName("g"), "Search results list", _driver)
            .GetAllLabels();

        public GooglePage(IWebDriver driver)
            : base(By.XPath(FormLocator), FormName, driver)
        {
            _driver = driver;
        }

        public List<string> GetAllResultsTextList()
        {
            var searchResultText =
                from result in SearchResultsOnPage
                select result.GetText();
            return searchResultText.ToList();
        }

        public void SearchFor(string text)
        {
            TbxSearchField.SetText(text);
            TbxSearchField.SendKeys(Keys.Enter);
        }

        public int GetSearchResultsCount()
        {
            var resultText = LblSearchResultsCount.GetText().Replace(" ", "");
            const string pattern = "\\d{4,}";
            return Convert.ToInt32(Regex.Match(resultText, pattern).ToString());
        }
    }
}