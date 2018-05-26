using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using VkApi.Menu;

namespace VkApi.Forms
{
   public class EditLivePositionInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";
        private readonly TextBox _selectPoliticalCustom = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_political_custom")), "PoliticalCustom");
        private readonly TextBox _selectReligion = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_religion")), "PoliticalCustom");
        private readonly TextBox _selectLife = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_life")), "Life");
        private readonly TextBox _selectPeople = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_people")), "People");
        private readonly TextBox _selectSmoke = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_smoking")), "Smoke");
        private readonly TextBox _selectAlcohol = new TextBox(By.XPath(string.Format(TemplateSelectLocator, "pedit_alcohol")), "Alcohol");

        private readonly TextBox _txbInspired = new TextBox(By.Id("pedit_inspired_by"), "Inspired");


        public EditLivePositionInfo()
            : base(By.ClassName("page_block_header"), "Life Position Page")
        {
        }
      
        public void FillInfoUser(string text) {
            if (!string.IsNullOrEmpty(text))
            {
                _selectPoliticalCustom.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Умеренные")), "PoliticalCustomLi").Click();
                Thread.Sleep(250);
                _selectReligion.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Ислам")), "ReligionLi").Click();
                Thread.Sleep(250);
                _selectLife.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Саморазвитие")), "LifeLi").Click();
                Thread.Sleep(250);

                _selectPeople.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Доброта")), "PeopleLi").Click();
                Thread.Sleep(250);

                _selectSmoke.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Негативное")))[0].Click();
                Thread.Sleep(250);

                _selectAlcohol.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Негативное")))[1].Click();
                Thread.Sleep(250);

                _txbInspired.SetText(text);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                _selectPoliticalCustom.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Не ")))[0].Click();
                Thread.Sleep(250);
          
                _selectLife.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Не ")))[1].Click();
                Thread.Sleep(250);

                _selectPeople.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Не ")))[2].Click();
                Thread.Sleep(250);

                _selectSmoke.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Не ")))[3].Click();
                Thread.Sleep(250);

                _selectAlcohol.Click();
                Browser.GetDriver().FindElements(By.XPath(string.Format(TemplateLiLocator, "Не ")))[4].Click();
                Thread.Sleep(250);


                _txbInspired.Clear();
                _selectReligion.Clear();
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
