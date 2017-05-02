using System;
using GoogleTest.Web.Elements;
using OpenQA.Selenium;

namespace GoogleTest.Web.Forms
{
    public abstract class BaseForm
    {
        private readonly string _name;
        private readonly By _locator;

        protected BaseForm(By locator, string name)
        {
            _locator = locator;
            _name = name;
            VerifyIsPresent();
        }

        private void VerifyIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator, "Form " + _name);
            Console.WriteLine($"Form '{_name}' has appeared");
        }
    }
}
