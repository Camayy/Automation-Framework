using System;
using System.Threading;
using AutomationFramework.Base;
using AutomationFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using UnitTestProject.Pages;
using System.Configuration;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1 : Base
    {
        [TestInitialize]
        public void TestSetup()
        {
            Browser.SelectBrowserType(Browser.BrowserType.Chrome);
            Logging.CreateLogFile();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Drivers.Browser.NavigateToUrl(ConfigurationManager.AppSettings["URL"].ToString());

            

            //Reads excel file and places into datatable
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\passwords.xlsx";
            ExcelReader.PopulateCollection(fileName);

            //change to bool and use asserts
            CurrentPage = GetInstance<AmazonHome>();
            //CurrentPage = CurrentPage.As<AmazonHome>().ClickLoginButton(ExcelReader.ReadData(1, "usernamecolumn"), ExcelReader.ReadData(1, "passwordcolumn"));
            CurrentPage = CurrentPage.As<AmazonHome>().ClickTodaysDealsButton();
            CurrentPage = CurrentPage.As<TodaysDealsPage>().ClickUnder15Link();
            Thread.Sleep(100);
        }

        [TestMethod]
        public void TableTest()
        {
            Drivers.Browser.NavigateToUrl(ConfigurationManager.AppSettings["URL"].ToString());

            CurrentPage = GetInstance<AmazonHome>();
            CurrentPage = CurrentPage.As<AmazonHome>().ClickTodaysDealsButton();
            CurrentPage = CurrentPage.As<TodaysDealsPage>().ClickUnder15Link();

            //get table elements example
            var table =  CurrentPage.As<TodaysDealsPage>().GetTodaysDealsList();

            HTMLTable.ReadTable(table);
            HTMLTable.ClickTableElement("0", "test", "test", "Submit");

        }

        [TestCleanup]
        public void TestCleanup()
        {
            Drivers.WebDriver.Quit();
        }
    }
}

