using GoogleTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GoogleTest.Web
{
    public class WebDriverSingleton
    {
        private static IWebDriver _driver;
        private static WebDriverSingleton _instance;

        private WebDriverSingleton()
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

        public void Reset()
        {
            _driver.Quit();
            _instance = null;
        }

        public static WebDriverSingleton Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new WebDriverSingleton();
                return _instance;
            }
        }
    }
}