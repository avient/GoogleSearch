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
            var wait = new WebDriverWait(WebDriverSingleton.Instance,
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until<bool>(waiting =>
            {
                var result = ((IJavaScriptExecutor) WebDriverSingleton.Instance).ExecuteScript(
                    "return document['readyState'] ? 'complete' == document.readyState : true");
                return result is bool && (bool) result;
            });
        }
    }
}