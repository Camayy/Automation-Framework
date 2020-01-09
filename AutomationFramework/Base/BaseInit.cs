using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Base
{
    /// <summary>
    /// Initialises PageFactory
    /// </summary>
    public abstract class BaseInit : Base
    {
        private IWebDriver driver { get; set; }
        public BaseInit()
        {
            PageFactory.InitElements(Drivers.WebDriver, this);
        }
    }
}
