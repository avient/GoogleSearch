using OpenQA.Selenium;

namespace GoogleTest.Web.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name, IWebDriver driver) : base(locator, name, driver)
        {
        }
    }
}