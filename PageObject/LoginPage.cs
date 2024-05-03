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

        
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']/label/span/input")]
        private IWebElement checkbox1;

        [FindsBy(How = How.XPath, Using = "//input[@id='signInBtn']")]
        private IWebElement signin;

        public void validlogin(string user, string pass)
        {
            username.SendKeys(user);

            password.SendKeys(pass);

            checkbox1.Click();

            signin.Click();
        }

       
    }
}
