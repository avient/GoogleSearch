using System;
using GoogleTest.Web.Elements;
using OpenQA.Selenium;

namespace GoogleTest.Web.Forms
{
    public abstract class BaseForm
    {
        private readonly string _name;
        private readonly By _locator;
        private readonly IWebDriver _driver;

        protected BaseForm(By locator, string name, IWebDriver driver)
        {
            _locator = locator;
            _name = name;
            _driver = driver;
            VerifyIsPresent();
        }

        private void VerifyIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator, "Form " + _name, _driver);
            Console.WriteLine($"Form '{_name}' has appeared");
        }
    }
}
