using System;
using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace GoogleTest.Web
{
    public static class Driver
    {
        private static IWebDriver _driver;

        public static IWebDriver GetInstance()
        {
            if (_driver != null) return _driver;
            var browserName = Configuration.GetBrowser();
            switch (browserName)
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            return _driver;
        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var wait = new WebDriverWait(GetInstance(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until<bool>(waiting =>
            {
                var result = ((IJavaScriptExecutor) GetInstance()).ExecuteScript(
                    "return document['readyState'] ? 'complete' == document.readyState : true");
                return result is bool && (bool) result;
            });
        }
    }
}