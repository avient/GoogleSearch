using System;
using OpenQA.Selenium;

namespace GoogleTest.Web.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name, IWebDriver driver) : base(locator, name, driver)
        {
        }

        public void SetText(string text)
        {
            WaitForElementPresent();
            GetElement().Click();
            Console.WriteLine($"{GetName()} :: type text '{text}'");
            GetElement().SendKeys(text);
        }

       
    }
}