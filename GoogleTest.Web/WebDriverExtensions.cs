using System;
using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleTest.Web
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until<bool>(waiting =>
            {
                var result = ((IJavaScriptExecutor) driver).ExecuteScript(
                    "return document['readyState'] ? 'complete' == document.readyState : true");
                return result is bool && (bool) result;
            });
        }

        public static void WaitForElementPresent(this IWebDriver driver, By locator, string name)
        {
            var wait = new WebDriverWait(driver,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            wait.Until(waiting =>
            {
                var webElements = driver.FindElements(locator);
                return webElements.Count != 0;
            });
        }
    }
}