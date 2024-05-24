using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using AngleSharp;
using System.Configuration;

namespace TestProject_C_seleniumframework.Utilities
{
    public class Base
    {
        String browsername;
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new();
        [SetUp]
        public void Setup()
        {
            browsername = TestContext.Parameters["browsername"];
            if(browsername == null)
            {
                browsername = ConfigurationManager.AppSettings["browser"];
            }
            initbrowser(browsername);
            driver.Value.Manage().Window.Maximize();
            //driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //wait after each line of execution
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getdriver()
        {
            return driver.Value;
        }

        public void initbrowser(string browsername)
        {
            switch (browsername)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        public static Jsonreader getDataParser()
        {
            return new Jsonreader();

        }

        [TearDown]

        public void Close()
        {
            Thread.Sleep(5000);
            driver.Value.Close();
        }
    }
}
