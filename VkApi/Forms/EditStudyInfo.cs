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
    public class EditStudyInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";

        private readonly TextBox _selectCountry = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_country-1")), "Country");
        private readonly TextBox _selectCountry1 = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_country1")), "Country");
        private readonly TextBox _selectCity = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_city-1")), "City");
        private readonly TextBox _selectSchool = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_school-1")), "School"); 
        private readonly TextBox _selectStartSudy = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_start-1")), "StartStudy");
        private readonly TextBox _selectEndStudy = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_finish-1")), "EndStudy");
        private readonly TextBox _selectGraduation = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_graduation-1")), "Graduation");
        private readonly TextBox _selectClass = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "s_class-1")), "Class");
        private readonly TextBox _txbProf = new TextBox(By.Id("s_spec-1_custom"), "Profession");

        public EditStudyInfo()
            : base(By.XPath("//*[@id='profile_editor']//a[contains(text(),'Высшее образование')]"), "Study Page")
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
                Thread.Sleep(250);
                _selectSchool.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Колледж №1")), "SchoolLi").Click();
                Thread.Sleep(250);
                _selectStartSudy.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2017")))[0].Click(); 
                Thread.Sleep(250);
                _selectEndStudy.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2020")))[0].Click();
                Thread.Sleep(250);
                _selectGraduation.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "2020")))[1].Click();
                Thread.Sleep(250);
                _selectClass.Click();
                new TextBox(By.XPath("//*[@id='row_s_class-1']//li[3]"), "ClassLi").Click();
                Thread.Sleep(500);

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
                _selectCountry1.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Не выбрана")), "CountryLi").Click();
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
