using System;
using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        protected string GetName()
        {
            return Name;
        }

        protected By GetLocator()
        {
            return Locator;
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
            Driver.WaitForPageToLoad();
        }

        public string GetText()
        {
            WaitForElementPresent();
            return GetElement().Text;
        }

        protected void WaitForElementPresent()
        {
            var wait = new WebDriverWait(Driver,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Driver.FindElements(Locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"Element with locator: '{Locator}' does not exists!");
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