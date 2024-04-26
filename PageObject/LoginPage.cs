using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_C_seleniumframework.PageObject
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacadem");

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        public IWebElement getusername()
        {
            return username;
        }

    }
}
