using GoogleTest.Infrastructure;
using GoogleTest.Web;
using NUnit.Framework;

namespace GoogleTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            var browser = WebDriverSingleton.Instance;
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.Instance.Quit();
        }
    }
}