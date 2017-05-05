using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GoogleTest.Web
{
    public class DriverFactory
    {
        private readonly IWebDriver _driver;

        public DriverFactory()
        {
            switch (Configuration.GetBrowser())
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}