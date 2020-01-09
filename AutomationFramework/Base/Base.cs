using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Base
{
    public class Base
    {
        private IWebDriver driver { get; set; }

        public BaseInit CurrentPage { get; set; }

        /// <summary>
        /// Creates instance of new page instance and webdriver
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        protected TPage GetInstance<TPage>() where TPage : BaseInit, new()
        {
            TPage pageInstance = new TPage()
            {
                driver = Drivers.WebDriver
            };

            PageFactory.InitElements(Drivers.WebDriver, pageInstance);

            return pageInstance;
        }

        /// <summary>
        /// Sets the current page selected
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage As<TPage>() where TPage : BaseInit
        {
            return (TPage)this;
        }
    }
}
