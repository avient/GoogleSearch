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
            var browser = Driver.GetInstance();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}
