using System;
using OpenQA.Selenium;

namespace GoogleTest.Web.Elements
{
    public abstract class BaseElement
    {
        protected readonly string Name;
        protected readonly By Locator;
        protected IWebElement Element;
        protected readonly IWebDriver Driver;


        protected BaseElement(By locator, string name, IWebDriver driver)
        {
            Name = name;
            Locator = locator;
            Driver = driver;
        }

        protected IWebElement GetElement()
        {
            WaitForElementPresent();
            return Element ?? (Element = Driver.FindElement(Locator));
        }

        public void Click()
        {
            WaitForElementPresent();
            Console.WriteLine($"Click element :: '{Name}'");
            GetElement().Click();
        }

        public void SendKeys(string key)
        {
            WaitForElementPresent();
            GetElement().SendKeys(key);
            Driver.WaitForPageToLoad();
        }

        public string GetText()
        {
            WaitForElementPresent();
            return GetElement().Text;
        }

        protected void WaitForElementPresent()
        {
            Driver.WaitForElementPresent(Locator, Name);
        }
    }
}