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
        public ExtentReports extent;
        public ExtentTest test;
        String browsername;
       
        //public IWebDriver driver;

        [OneTimeSetUp]
        public void setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;
            String reportpath = projectDirectory + "//index.html";
            var htmlreporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent?.AttachReporter(htmlreporter);
            extent?.AddSystemInfo("host name", "localhost");
            extent?.AddSystemInfo("environment", "QA");
            extent?.AddSystemInfo("user", "lijo");

        }

        public ThreadLocal<IWebDriver> driver = new();
        [SetUp]
        public void Startbrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
            var status  = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("test failed", capScreenshot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrace"+stacktrace+"\n");
            }
            else if(status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("test passed");
            }
            extent.Flush();
            //Thread.Sleep(5000);
            driver.Value.Close();

        }
        public MediaEntityModelProvider capScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}
