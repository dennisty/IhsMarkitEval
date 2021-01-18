using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace IhsMarkitEval.Pages
{
    internal class HomePage : BasePage
    {
        private readonly By RunButtonLocator = By.Id("run-button");
        private readonly By OutputWindowLocator = By.Id("output");
        private readonly By SaveButtonLocator = By.Id("save-button");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickRunButton()
        {
            IWebElement runButton = Driver.FindElement(RunButtonLocator);
            runButton.Click();
        }

        public void ClearOutputText(int timeoutSec = 5)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            _ = js.ExecuteScript($"document.getElementById('output').innerText = ''");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSec));

            try
            {
                wait.Until(d => d.FindElement(OutputWindowLocator).Text == "");
            }
            catch (WebDriverTimeoutException) {
                throw new WebDriverTimeoutException($"Failed to clear output text within {timeoutSec} seconds!");
            }
        }

        public string GetOutputWindowText()
        {
            IWebElement outputWindow = Driver.FindElement(OutputWindowLocator);
            return outputWindow.Text;
        }

        public bool VerifyOutputWindowText(string desiredText, int timeoutSec = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSec));

            try
            {
                return wait.Until(d => d.FindElement(OutputWindowLocator).Text == desiredText);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public LoginModal ClickSaveButtonWhenNotLoggedIn()
        {
            IWebElement saveButton = Driver.FindElement(SaveButtonLocator);
            saveButton.Click();
            return new LoginModal(Driver);
        }
    }
}
