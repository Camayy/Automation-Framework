using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Base
{
    public static class Drivers
    {
        public static IWebDriver WebDriver { get; set; }

        public static Browser Browser { get; set; }
    }
}
