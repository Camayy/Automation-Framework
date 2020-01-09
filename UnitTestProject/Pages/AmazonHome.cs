using AutomationFramework.Base;
using AutomationFramework.Extensions;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Pages
{
    class AmazonHome : BaseInit
    {
        public AmazonHome()
        {
            WebDriverEx.WaitForPageLoad();
        }



        #region webelements     
        [FindsBy(How = How.CssSelector, Using = "#nav-xshop > a:nth-child(3)")]
        IWebElement shopbydepartmentbtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        IWebElement searchBar { get; set; }
        #endregion

        internal TodaysDealsPage ClickTodaysDealsButton()
        {
            shopbydepartmentbtn.Click();
            Logging.Write("Clicked Todays Deals button");
            return GetInstance<TodaysDealsPage>();
        }

        //placeholder
        internal AmazonHome ClickLoginButton(string username, string password)
        {
            //PLACEHOLDER
            return GetInstance<AmazonHome>();
        }
    }
}
