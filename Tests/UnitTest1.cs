

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
            String[] expproduct = { "iphone X" };
            String[] actual = { "iphone X" };

            TestContext.Progress.WriteLine(driver.Url);
            TestContext.Progress.WriteLine(driver.Title);
                        
            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacadem");
            LoginPage loginpage = new LoginPage(driver);

            shoppage Shop = loginpage.validlogin("rahulshettyacademy", "learning");
            Shop.waitfordisplay();

            IList<IWebElement> listproduct = Shop.getproductlist();

            foreach( IWebElement prod in listproduct )
            {
                if (expproduct.Contains(prod.FindElement(Shop.selectproduct()).Text))
                {
                    prod.FindElement(Shop.addtokart()).Click();
                }
            }

            Checkoutpage checkoutpage = Shop.getcheckout();

            IList<IWebElement> checkoutlist = checkoutpage.getCheckoutlist();

            for(int i =0; i<checkoutlist.Count; i++)
            {
                actual[i] = checkoutlist[i].Text;
            }

            Assert.That(actual,Is.EqualTo(expproduct));

            Confirmpage confirmpage = checkoutpage.getCheckoutclick();

            confirmpage.gettypeind("ind");

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            confirmpage.waitfortext();

            //driver.FindElement(By.LinkText("India")).Click();

            //driver.FindElement(By.CssSelector("label[for*='checkbox2'")).Click();

            //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

            confirmpage.gettextindia();

            confirmpage.getconfirmpagecheckbox();

            confirmpage.getpurchase();

            String conftext = confirmpage.getalert().Text;
                
            //driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", conftext);

            TestContext.Progress.WriteLine("Test completed");

        }



    }
}
