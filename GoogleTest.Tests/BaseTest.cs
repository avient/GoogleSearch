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
            var driver = WebDriverSingleton.Instance.GetDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.Instance.Reset();
        }
    }
}