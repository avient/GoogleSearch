using System;
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
        }

        public void VerifyIsOpened()
        {
            _driver.WaitForElementPresent(_locator, "Form " + _name);
            Console.WriteLine($"Form '{_name}' is opened");
        }
    }
}
