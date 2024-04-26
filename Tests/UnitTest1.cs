

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Diagnostics;
using NuGet.Frameworks;
using TestProject_C_seleniumframework.Utilities;
using OpenQA.Selenium.Support.UI;
using TestProject_C_seleniumframework.PageObject;

namespace TestProject_C_seleniumframework.Tests
{
    public class Tests : Base
    {
        

        [Test]
        public void Test1()
        {

            TestContext.Progress.WriteLine(driver.Url);
            TestContext.Progress.WriteLine(driver.Title);

            
            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacadem");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.getusername().SendKeys("rahulshettyacadem");

            driver.FindElement(By.Name("password")).SendKeys("learning");
            //driver.FindElement(By.CssSelector("input[type='checkbox'")).Click();
            driver.FindElement(By.XPath("//div[@class='form-group']/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@id='signInBtn']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(By.XPath("//input[@id='signInBtn']"), "Sign In"));

            // to collect error message give wrong username
            string er_message = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(er_message);

            IWebElement Link_1 = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String actual_attr = Link_1.GetAttribute("href");
            String expected_attr = "https://rahulshettyacademy.com/documents-request";
            Assert.That(actual_attr, Is.EqualTo(expected_attr));
            //Assert.AreEqual(expected_attr, actual_attr);

        }



    }
}
