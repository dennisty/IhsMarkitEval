using IhsMarkitEval.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IhsMarkitEval.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected readonly string BaseUrl = "https://dotnetfiddle.net/";
        protected IWebDriver Driver { get; set; }
        protected BrowserType Browser { get; set; }

        public BaseTest(BrowserType browser)
        {
            Browser = browser;
        }

        [SetUp]
        public void SetupTest()
        {
            Driver = WebDriverFactory.Create(Browser);
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.Close();
            Driver.Quit();
        }

    }
}
