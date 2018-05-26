using System.Threading;
using demo.framework;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace VkApi.Forms
{
    public class LoginForm : BaseForm
    {
        private readonly TextBox _txbUserEmail = new TextBox(By.Id("index_email"), "User email or phone");
        private readonly TextBox _txbPassword = new TextBox(By.Id("index_pass"), "User password");
        private readonly TextBox _txbContinueToReg = new TextBox(By.Id("ij_submit"), "Continue to register");

        public LoginForm()
            : base(By.Id("index_login"), "Login Page")
        {
        }

        public void Login(string userEmailOrPhone, string password)
        {
            _txbContinueToReg.ScrollToElement();
            Browser.GetDriver().FindElements(By.XPath("//*[@id='bottom_nav']//a[contains(text(),'Русский')]"))[0].Click();
            Thread.Sleep(1500);
            _txbUserEmail.SetText(userEmailOrPhone);
            _txbPassword.SetText(password);          
        }
    }
}

