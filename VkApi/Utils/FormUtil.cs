using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework;
using OpenQA.Selenium;

namespace VkApi.Utils
{
    public static class FormUtil
    {
        public static void ClickBtn(string nameBtn)
        {
            var elements = Browser.GetDriver().FindElements(By.XPath($"//*[contains(text(), '{nameBtn}')]"));
            if (nameBtn == "Войти")
                elements[1].Click();
            else
                elements[0].Click();
        }
    }
}
