using System;
using System.Collections.Generic;
using System.Linq;
using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleTest.Web.Elements
{
    public class BaseElement
    {
        private readonly string _name;
        private readonly By _locator;
        private IWebElement _element;
        private readonly IWebDriver _driver;


        protected BaseElement(By locator, string name, IWebDriver driver)
        {
            _name = name;
            _locator = locator;
            _driver = driver;
        }

        protected IWebElement GetElement()
        {
            WaitForElementPresent();
            return _element ?? (_element = _driver.FindElement(_locator));
        }

        public List<BaseElement> GetAllElements()
        {
            var allElements = _driver.FindElements(_locator);
            return allElements.Select((t, i) => new BaseElement(_locator, _name + i, _driver) {_element = t}).ToList();
        }

        protected string GetName()
        {
            return _name;
        }

        protected By GetLocator()
        {
            return _locator;
        }

        public void Click()
        {
            WaitForElementPresent();
            Console.WriteLine($"Click element :: '{GetName()}'");
            GetElement().Click();
        }

        public void SendKeys(string key)
        {
            WaitForElementPresent();
            GetElement().SendKeys(key);
            _driver.WaitForPageToLoad();
        }

        public string GetText()
        {
            WaitForElementPresent();
            return GetElement().Text;
        }

        protected void WaitForElementPresent()
        {
            var wait = new WebDriverWait(_driver,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = _driver.FindElements(_locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"Element with locator: '{_locator}' does not exists!");
            }
        }

        public static void WaitForElementPresent(By locator, string name, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = driver.FindElements(locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"Element with locator: '{locator}' does not exists!");
            }
        }
    }
}