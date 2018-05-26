using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using VkApi.Enumerables;

namespace VkApi.Forms
{
    public class SideMenu : BaseForm
    {
        private const string TemplateMenuLocator = "//li/a//span[contains(text(),'{0}')]";

        public SideMenu() : base(By.XPath("//ol"),
            "Main side menu")
        {
        }

        public void NavigateToMenuItem(string menuItem)
        {
            var _linkMenuItem = new Link(
                By.XPath(string.Format(TemplateMenuLocator, menuItem)),
                "Link main side menu item:" + menuItem);
            _linkMenuItem.Click();
        }
    }
}
