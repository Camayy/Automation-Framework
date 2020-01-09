using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Pages
{
    public class amazonpage
    {
        string url = "https://www.amazon.co.uk/";

        private IWebDriver driver;

        public bool TestMethod()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            return true;
        }
        
    }
}
