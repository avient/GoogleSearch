using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleTest.Web.Elements;
using OpenQA.Selenium;

namespace GoogleTest.Web.Forms
{
    public class GooglePage : BaseForm
    {
        private const string FormLocator = "//*[@id='main']";
        private const string FormName = "Google page";

        private TextBox TbxSearchField => new TextBox(By.Id("lst-ib"), "Search field");
        private Label LblSearchResultsCount => new Label(By.Id("resultStats"), "Search results count");
        private List<BaseElement> SearchResultsOnPage => new Label(By.ClassName("g"), "Search results list")
            .GetAllElements();

        public GooglePage()
            : base(By.XPath(FormLocator), FormName)
        {
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
            var result = LblSearchResultsCount.GetText().Substring(0, LblSearchResultsCount.GetText().IndexOf('('));
            var sb = new StringBuilder();
            var stringQuery = result.Where(char.IsDigit);
            foreach (var c in stringQuery)
                sb.Append(c);
            return Convert.ToInt32(sb.ToString());
        }
    }
}