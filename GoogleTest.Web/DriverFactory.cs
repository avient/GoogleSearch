using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GoogleTest.Web
{
    public class DriverFactory
    {
        public IWebDriver GetDriver(string browserName)
        {
            switch (browserName)
            {
                case "firefox":
                    return new FirefoxDriver();
                default:
                    return new ChromeDriver();
            }
        }
    }
}