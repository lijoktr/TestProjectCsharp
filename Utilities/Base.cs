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
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            String browsername = ConfigurationManager.AppSettings["browser"];
            initbrowser(browsername);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //wait after each line of execution
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getdriver()
        {
            return driver;
        }

        public void initbrowser(string browsername)
        {
            switch (browsername)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]

        public void Close()
        {
            //Thread.Sleep(20000);
            driver.Close();
        }
    }
}
