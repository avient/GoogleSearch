using OpenQA.Selenium;

namespace GoogleTest.Web.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name, IWebDriver driver) : base(locator, name, driver)
        {
        }
    }
}