using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GoogleTest.Web
{
    public class WebDriverSingleton
    {
        private static IWebDriver driver;

        private WebDriverSingleton()
        {
            switch (Configuration.GetBrowser())
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        public static IWebDriver Instance
        {
            get
            {
                if (driver != null) return driver;
                new WebDriverSingleton();
                return driver;
            }
        }
    }
}