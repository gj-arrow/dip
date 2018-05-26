using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework.Elements;
using demo.framework.forms;
using demo.Framework.Elements;
using OpenQA.Selenium;
using VkApi.Menu;

namespace VkApi.Forms
{
    public class EditMainInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";
        private readonly TextBox _selectSex = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_sex")), "sex");
        private readonly TextBox _selectStatus = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_status")), "status");
        private readonly TextBox _selectBday = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_bday")), "HB Day");
        private readonly TextBox _selectBmonth = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_bmonth")), "HB month");
        private readonly TextBox _selectByear = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_byear")), "HB year");
        private readonly TextBox _selectHBVisiblity = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_bday_visibility")), "HB visibility");
        private readonly TextBox _txbTown = new TextBox(By.Id("pedit_home_town"), "Town");
        private readonly TextBox _selectLanguage = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_langs")), "Languages");

        public EditInfoMenu rightMenu = new EditInfoMenu();

        public EditMainInfo()
            : base(By.ClassName("page_block_header"), "Edit Main Page")
        {
        }

        public void FillInfoUser(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _selectSex.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "мужской")), "sexLi").Click();
                _selectStatus.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Всё сложно")), "statusLi").Click();
                _selectBday.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "2")), "HB DayLi").Click();
                _selectBmonth.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Апреля")), "HB monthLi").Click();
                _selectByear.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "2000")), "HB yearLi").Click();
                _txbTown.SetText("Минск");
                _selectHBVisiblity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Не показывать")), "HB visibilityLi").Click();
                _selectLanguage.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "English")), "Lang Li").Click();
                _selectLanguage.ScrollToElement();
                Thread.Sleep(500);
               
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                _selectSex.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "мужской")), "sexLi").Click();
                _selectStatus.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Не выбрано")), "statusLi").Click();
                _selectBday.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "9")), "HB DayLi").Click();
                _selectBmonth.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Января")), "HB monthLi").Click();
                _selectByear.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "1996")), "HB yearLi").Click();
                _txbTown.Clear();
                _selectHBVisiblity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Показывать дату рождения")), "HB visibilityLi").Click();
                new TextBox(By.XPath("//span[contains(text(), 'English')]/../preceding-sibling::span"), "lang").Click();
                _selectLanguage.ScrollToElement();
                Thread.Sleep(500);

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
