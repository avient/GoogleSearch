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

        protected BaseElement(By locator, string name)
        {
            this._name = name;
            this._locator = locator;
        }

        protected IWebElement GetElement()
        {
            WaitForElementPresent();
            return _element ?? (_element = Driver.GetInstance().FindElement(_locator));
        }

        public List<BaseElement> GetAllElements()
        {
            var allElements = Driver.GetInstance().FindElements(_locator);
            return allElements.Select((t, i) => new BaseElement(_locator, _name + i) {_element = t}).ToList();
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
            Driver.GetInstance().WaitForPageToLoad();
        }

        public string GetText()
        {
            WaitForElementPresent();
            return GetElement().Text;
        }

        protected void WaitForElementPresent()
        {
            var wait = new WebDriverWait(Driver.GetInstance(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Driver.GetInstance().FindElements(_locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"Element with locator: '{_locator}' does not exists!");
            }
        }

        public static void WaitForElementPresent(By locator, string name)
        {
            var wait = new WebDriverWait(Driver.GetInstance(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Driver.GetInstance().FindElements(locator);
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