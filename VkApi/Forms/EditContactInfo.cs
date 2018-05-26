using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using VkApi.Menu;

namespace VkApi.Forms
{
   public class EditContactInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";
        private readonly TextBox _selectCountry = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_country")), "Country");
        private readonly TextBox _selectCity = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_city")), "City");
        private readonly TextBox _txbMobile = new TextBox(By.Id("pedit_mobile"), "mobile");
        private readonly TextBox _txbHome = new TextBox(By.Id("pedit_home"), "Home");
        private readonly TextBox _txbSkype = new TextBox(By.Id("pedit_skype"), "Skype");
        private readonly TextBox _txbSite = new TextBox(By.Id("pedit_website"), "Site");


        public EditContactInfo()
            : base(By.ClassName("page_block_header"), "Friends Page")
        {
        }
      
        public void FillInfoUser(string text) {
            if (!string.IsNullOrEmpty(text))
            {
                _selectCountry.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Россия")), "CountryLi").Click();
                Thread.Sleep(1000);
                _selectCity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Воронеж")), "CityLi").Click();
                _txbMobile.SetText(text);
                _txbHome.SetText(text);
                _txbSkype.SetText(text);
                _txbSite.SetText(text);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                _selectCountry.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Не выбрана")), "CountryLi").Click();
                _txbMobile.Clear();
                _txbHome.Clear();
                _txbSkype.Clear();
                _txbSite.Clear();
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
