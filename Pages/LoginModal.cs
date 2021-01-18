using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace IhsMarkitEval.Pages
{
    internal class LoginModal : BasePage
    {

        private readonly By LoginModalLocator = By.Id("login-modal");

        public LoginModal(IWebDriver driver) : base(driver)
        {
        }

        public bool VerifyLoginModalOpen(int timeoutSec = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSec));

            try
            {
                return wait.Until(d => d.FindElement(LoginModalLocator).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
