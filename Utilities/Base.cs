using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject_C_seleniumframework.Utilities
{
    public class Base
    {
        ExtentReports extent;
        String browsername;
        //public IWebDriver driver;

        [OneTimeSetUp]
        public void setup()
        {
            String workingdirectory = Environment.CurrentDirectory;
            String projectdirectory = Directory.GetParent(workingdirectory).Parent.FullName;
            String reportpath = projectdirectory + "//index.html";
            var htmlreporter = new ExtentHtmlReporter(reportpath);

        }
        public ThreadLocal<IWebDriver> driver = new();
        [SetUp]
        public void Startbrowser()
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
