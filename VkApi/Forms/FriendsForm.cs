using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace VkApi.Forms
{
   public class FriendsForm : BaseForm
    {
        private readonly Link _linkExtendedConfiguration = new Link(By.XPath("//*[@id='friends_import_header']/a"), "Extended cofiguration  link");
        private readonly TextBox _txbSearch = new TextBox(By.XPath("//*[@id='search_query']"), "Search element");

        public FriendsForm()
            : base(By.Id("friends_import_header"), "Friends Page")
        {
        }

        public void ClickToExtendedConfiguration() {
            _linkExtendedConfiguration.Click();
        }

        public void SelectRegion(string region)
        {
            Thread.Sleep(1000);
            var _linkRegion = new TextBox(By.XPath("//div[@id='region_filter']//div[@id='cCountry']//tbody/tr/td[1]/input[1]"), "Extended cofiguration link");
            _linkRegion.SetText(region);
            _linkRegion.SetEnter();
        }

        public void EnterNameForSearch(string name)
        {
            _txbSearch.SetText(name);
            _txbSearch.SetEnter();
        }

    }
}
