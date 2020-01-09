using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Pages
{
    public class LoginPage : BaseInit
    {
        
        [FindsBy(How = How.CssSelector, Using = "ASDF")]
        private IWebElement tempelement { get; set; }

        public bool Login()
        {
            return true;
        }
    }
}
