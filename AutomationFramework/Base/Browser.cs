using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver driver;

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BrowserType Type { get; set; }

        public void NavigateToUrl(string url)
        {
            Drivers.WebDriver.Url = url;
        }

        /// <summary>
        /// List of Browser types
        /// </summary>
        public enum BrowserType
        {
            Chrome,
            FireFox,
            InternetExplorer,
            Edge

        }

        /// <summary>
        /// Selects the browser to be used
        /// </summary>
        /// <param name="browserType">Browser to be used</param>
        public static void SelectBrowserType(BrowserType browserType = BrowserType.Chrome)
        {
            //change if other browser
            browserType = BrowserType.Chrome;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    Drivers.WebDriver = new ChromeDriver();
                    Drivers.Browser = new Browser(Drivers.WebDriver);
                    break;
                case BrowserType.FireFox:
                    Drivers.WebDriver = new FirefoxDriver();
                    Drivers.Browser = new Browser(Drivers.WebDriver);
                    break;
                case BrowserType.InternetExplorer:
                    Drivers.WebDriver = new InternetExplorerDriver();
                    Drivers.Browser = new Browser(Drivers.WebDriver);
                    break;
                default:
                    break;
            }
        }
    }
}
