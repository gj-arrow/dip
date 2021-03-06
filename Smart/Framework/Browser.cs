﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace demo.framework
{

    public class Browser : BaseEntity
    {
        protected static readonly Browser _browser;
        private static IWebDriver _driver;
       
        public static Browser GetInstance()
        {
           _driver = BrowserFactory.SetupBrowser();
           _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Double.Parse(Configuration.GetTimeout()));

            return new Browser();
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void WaitForPageToLoad()
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
                wait.Until<Boolean>(waiting =>
                {
                    try
                    {
                        var result = ((IJavaScriptExecutor)Browser.GetDriver()).ExecuteScript("return document['readyState'] ? 'complete' == document.readyState : true");
                        return result != null && result is Boolean && (Boolean)result;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
        }

    }
}
