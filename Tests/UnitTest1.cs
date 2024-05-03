

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
using NUnit.Framework.Constraints;

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

            loginpage.validlogin("rahulshettyacademy", "learning");
          
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            String[] expproduct = { "iphone X" };
            String[] actual = { "iphone X" };

            IList<IWebElement> listproduct = driver.FindElements(By.TagName("app-card"));

            foreach( IWebElement prod in listproduct )
            {
                //TestContext.Progress.WriteLine(prod.FindElement(By.CssSelector("h4.card-title a")).Text);
                if(expproduct.Contains(prod.FindElement(By.CssSelector("h4.card-title a")).Text))
                {
                   prod.FindElement(By.CssSelector(".card-footer button")).Click();
                }             
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkout = driver.FindElements(By.CssSelector("h4"));

            for(int i =0; i<checkout.Count; i++)
            {
                actual[i] = checkout[i].Text;
            }

            Assert.That(actual,Is.EqualTo(expproduct));
            //Assert.AreEqual(expproduct, actual);

            driver.FindElement(By.CssSelector(".btn-success")).Click();


            /*          //assertion
                        // to collect error message give wrong username
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(By.XPath("//input[@id='signInBtn']"), "Sign In"));

                        string er_message = driver.FindElement(By.ClassName("alert-danger")).Text;
                        TestContext.Progress.WriteLine(er_message);

                        IWebElement Link_1 = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
                        String actual_attr = Link_1.GetAttribute("href");
                        String expected_attr = "https://rahulshettyacademy.com/documents-request";
                        Assert.That(actual_attr, Is.EqualTo(expected_attr));
                        //Assert.AreEqual(expected_attr, actual_attr);
                        """
            */

        }



    }
}
