using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Extensions;

namespace UnitTestProject.Pages
{
    class TodaysDealsPage : BaseInit
    {
        #region webelements
        [FindsBy(How = How.CssSelector, Using = "#widgetFilters > div:nth-child(1) > span:nth-child(2) > div > a")]
        IWebElement under15Link { get; set; }

        [FindsBy(How = How.ClassName, Using = "")]
        IWebElement tblDealTable { get; set; }
        #endregion

        internal TodaysDealsPage ClickUnder15Link()
        {
            WebDriverEx.WaitForPageLoad();

            if (WebElement.Exists(under15Link))
            {
                under15Link.Click();
            }

            return GetInstance<TodaysDealsPage>();
        }

        internal IWebElement GetTodaysDealsList()
        {
            return tblDealTable;
        }
    }
}
