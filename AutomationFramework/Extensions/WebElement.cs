using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Helpers;
using OpenQA.Selenium.Interactions;
using AutomationFramework.Base;

namespace AutomationFramework.Extensions
{
    public static class WebElement
    {
        public static bool Exists(this IWebElement element)
        {
            if (element.Displayed)
                return true;
            else
            {
                Logging.Write("Element " + element.ToString() + " was not found on the page");
                throw new Exception(string.Format("Element was not displayed on page"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropdownElement(this IWebElement element, string value)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByValue(value);
        }

        public static void Hover(this IWebElement element)
        {
            Actions ac = new Actions(Drivers.WebDriver);
            ac.MoveToElement(element).Perform();

        }
    }
}
