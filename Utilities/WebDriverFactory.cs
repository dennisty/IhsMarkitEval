using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace IhsMarkitEval.Utilities
{
    public abstract class WebDriverFactory
    {
        public static IWebDriver Create(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => GetChromeDriver(),
                BrowserType.Firefox => GetFirefoxDriver(),
                _ => throw new ArgumentOutOfRangeException("Invalid browser specified!"),
            };
        }

        private static IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }

        private static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}
