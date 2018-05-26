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
    public class EditCarrierInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";

        private readonly TextBox _selectCountry = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "country1")), "Country");
        private readonly TextBox _selectCity = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "city1")), "City");
        private readonly TextBox _selectStar = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "start1")), "StartWork");
        private readonly TextBox _selectEnd = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "finish1")), "EndWork");
        private readonly TextBox _txbProf = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "position1")), "Position");
        private readonly Button _removeCompany = new Button(By.XPath("//*[@id='row_group1']//a"), "RemoveCompany");

        public EditCarrierInfo()
            : base(By.XPath("//*[@id='profile_editor']/div[1]"), "Carrier Page")
        {
        }

        public void FillInfoUser(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _selectCountry.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Россия")), "CountryLi").Click();
                Thread.Sleep(250);
                _selectCity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Воронеж")), "CityLi").Click();
                _selectStar.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2017")))[0].Click(); 
                Thread.Sleep(250);
                _selectEnd.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2018")))[1].Click();
                Thread.Sleep(250);
                _txbProf.Clear();
                _txbProf.SetText("Инженер-программист");
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
                _removeCompany.Click();
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
