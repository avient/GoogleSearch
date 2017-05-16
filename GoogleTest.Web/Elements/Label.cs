using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace GoogleTest.Web.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name, IWebDriver driver) : base(locator, name, driver)
        {
        }

        public List<Label> GetAllLabels()
        {
            var allElements = Driver.FindElements(Locator);
            return allElements.Select((t, i) => new Label(Locator, Name + i, Driver) { Element = t }).ToList();
        }
    }
}