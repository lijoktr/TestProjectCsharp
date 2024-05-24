

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
    [Parallelizable(ParallelScope.Self)]
    public class Tests2_1 : Base
    {
        //[Test]
        [Test, TestCaseSource("addTestDataConfig")]
        //[TestCaseSource("addTestDataConfig")]

        [Parallelizable(ParallelScope.All)]
        public void Test2_1(string username, string password, String[] expproduct)
        {
            //String[] expproduct = { "product" };
            String[] actual = { "product" };

            TestContext.Progress.WriteLine(driver.Value.Url);
            TestContext.Progress.WriteLine(driver.Value.Title);
                        
            LoginPage loginpage = new LoginPage(driver.Value);

            shoppage Shop = loginpage.validlogin(username, password);
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

            confirmpage.waitfortext();

            confirmpage.gettextindia();

            confirmpage.getconfirmpagecheckbox();

            confirmpage.getpurchase();

            String conftext = confirmpage.getalert().Text;
                
            StringAssert.Contains("Success", conftext);

            TestContext.Progress.WriteLine("Test completed");

        }

        [Test, TestCaseSource("addTestDataConfig")]
        //[TestCaseSource("addTestDataConfig")]

        [Parallelizable(ParallelScope.All)]
        public void Test2(string username, string password, String[] expproduct)
        {
            //String[] expproduct = { "product" };
            String[] actual = { "product" };

            TestContext.Progress.WriteLine(driver.Value.Url);
            TestContext.Progress.WriteLine(driver.Value.Title);

            LoginPage loginpage = new LoginPage(driver.Value);

            shoppage Shop = loginpage.validlogin(username, password);
            Shop.waitfordisplay();

            IList<IWebElement> listproduct = Shop.getproductlist();

            foreach (IWebElement prod in listproduct)
            {
                if (expproduct.Contains(prod.FindElement(Shop.selectproduct()).Text))
                {
                    prod.FindElement(Shop.addtokart()).Click();
                }
            }

            Checkoutpage checkoutpage = Shop.getcheckout();

            IList<IWebElement> checkoutlist = checkoutpage.getCheckoutlist();

            for (int i = 0; i < checkoutlist.Count; i++)
            {
                actual[i] = checkoutlist[i].Text;
            }

            Assert.That(actual, Is.EqualTo(expproduct));

            Confirmpage confirmpage = checkoutpage.getCheckoutclick();

            confirmpage.gettypeind("ind");

            confirmpage.waitfortext();

            confirmpage.gettextindia();

            confirmpage.getconfirmpagecheckbox();

            confirmpage.getpurchase();

            String conftext = confirmpage.getalert().Text;

            StringAssert.Contains("Success", conftext);

            TestContext.Progress.WriteLine("Test completed");

        }

        public static IEnumerable<TestCaseData> addTestDataConfig()
        {
            //yield - multiple returns
            //yield
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataarray("products"));
            yield return new TestCaseData(getDataParser().extractData("wrong_username"),getDataParser().extractData("wrong_password"), getDataParser().extractDataarray("products"));
        }



    }
}
