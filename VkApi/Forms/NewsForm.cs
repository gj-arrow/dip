using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace VkApi.Forms
{
    public class NewsForm : BaseForm
    {
        private readonly Button _btnMyPage = new Button(By.XPath("//li[@id='l_pr']//span[contains(text(),'Моя Страница')]"),"My page button");
        private readonly Button _btnProfileMenu = new Button(By.XPath("//*[@id='top_profile_link']"), "Profile menu");
        public SideMenu sideMenu = new SideMenu();

        public NewsForm()
            : base(By.XPath("//*[@id='l_pr']/a/span/span[3]"), "News Page")
        {
        }

        public void ClickMyPageBtn()
        {
            _btnMyPage.ClickAndWait();
        }

        public void ClickProfileMenuBtn()
        {
            _btnProfileMenu.Click();
        }
    }
}
