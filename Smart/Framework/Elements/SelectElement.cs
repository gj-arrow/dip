using OpenQA.Selenium;
using demo.framework.Elements;
using UISelectElement = OpenQA.Selenium.Support.UI.SelectElement;

namespace demo.Framework.Elements
{
    public class SelectElement : BaseElement
    {
        public SelectElement(By locator, string name) : base(locator, name)
        {
        }

        public void SelectValue(string value)
        {
            WaitForElementPresent();
            var select = new UISelectElement(GetElement());
            select.SelectByText(value);
        }

        public void SelectValueByIndex(int index)
        {
            WaitForElementPresent();
            var select = new UISelectElement(GetElement());
            select.SelectByIndex(index);
        }
    }
}
