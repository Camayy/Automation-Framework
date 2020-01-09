using AutomationFramework.Base;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Extensions
{
    public static class WebDriverEx
    {

        // THIS CAN BE MADE BETTER (USE TIMESPAN.FROMSECONDS TO TIME OUT PAGE 
        public static void WaitForPageLoad()
        {
            
            bool wait = Drivers.WebDriver.Execute<bool>("return document.readyState").Equals("complete");

            if (wait)
            {
                Logging.Write("Page loaded");
            }
            else
            {
                Logging.Write("Page not loaded");
            }
            //bool wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(d => ((javascriptexecutor)d).executescript("return document.readyState").Equals("complete")); 
        }


        public static T Execute<T>(this IWebDriver driver, string script)
        {
            return (T)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
