using GoogleTest.Infrastructure;
using GoogleTest.Web;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleTest.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new DriverFactory().GetDriver(Configuration.GetBrowser());
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}