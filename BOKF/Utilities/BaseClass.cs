using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace BOKF.Utilities
{
    class BaseClass
    {
        public IWebDriver GetWebDriver(string BrowserName)
        {
            switch (BrowserName)
            {
                case "Chrome":
                    var chromeDriver = new ChromeDriver();
                    return chromeDriver;
                case "Firefox":
                    var firefoxDriver = new FirefoxDriver();
                    return firefoxDriver;
                case "IE":
                    var ieDriver = new InternetExplorerDriver();
                    return ieDriver;
                case "Edge":
                    var edgeDriver = new EdgeDriver();
                    return edgeDriver;
                default:
                    throw new ArgumentOutOfRangeException(null);
            }
        }
    }
}
