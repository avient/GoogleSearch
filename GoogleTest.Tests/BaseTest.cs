using GoogleTest.Infrastructure;
using GoogleTest.Web;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver _driver;

        public BaseTest(out IWebDriver driver)
        {
            driver = new DriverFactory().GetDriver();
            _driver = driver;
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}