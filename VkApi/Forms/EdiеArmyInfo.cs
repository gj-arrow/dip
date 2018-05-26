using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Elements;
using demo.framework.forms;
using demo.Framework.Elements;
using OpenQA.Selenium;
using VkApi.Menu;

namespace VkApi.Forms
{
    public class EditArmyInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";

        private readonly TextBox _selectCountry = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "country-1")), "Country");
        private readonly TextBox _selectStartWork = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "start-1")), "StartWork");
        private readonly TextBox _selectEndWork = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "finish-1")), "EndWork");
        private readonly TextBox _txbArmy = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "unit-1")), "Unit");

        public EditArmyInfo()
            : base(By.XPath("//*[@id='profile_editor']/div[1]"), "Army Page")
        {
        }

        public void FillInfoUser(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _selectCountry.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Россия")), "CountryLi").Click();
                Thread.Sleep(250);
                _txbArmy.Clear();
                _txbArmy.SetText("qwertyuiopiuytrewqwertyui");
                Browser.GetDriver().FindElements(By.XPath("//li//em[contains(text(),'qwerty')]"))[0].Click();
                _selectStartWork.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2017")))[0].Click(); 
                Thread.Sleep(250);
                _selectEndWork.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2019")))[0].Click();
                Thread.Sleep(250);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                Browser.GetDriver().FindElements(By.XPath("//a[@class = 'pedit_del_icon _del_icon']"))[0].Click();
                Thread.Sleep(1000);
                Browser.GetDriver().FindElements(By.XPath("//a[@class = 'pedit_del_icon _del_icon']"))[0].Click();
                Thread.Sleep(1000);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
