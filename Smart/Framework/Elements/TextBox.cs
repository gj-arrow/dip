using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using demo.framework.Elements;
using System.Threading;

namespace demo.framework.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, String name) : base(locator, name){}

        public void SetText(String text)
        {
            WaitForElementPresent();
            GetElement().Click();
            GetElement().SendKeys(text);
            Log.Info(String.Format("{0} :: type text '{1}'", GetName(), text));
        }

        public void SetEnter()
        {
            WaitForElementPresent();
            GetElement().Click();
            Thread.Sleep(500);
            GetElement().SendKeys(Keys.Enter);
            Log.Info(String.Format("{0} :: set Enter", GetName()));
        }

        public void Clear()
        {
            WaitForElementPresent();
            GetElement().Clear();
            Log.Info(String.Format("{0} :: Clear textBox", GetName()));
        }
    }
}
