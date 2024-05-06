using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_C_seleniumframework.PageObject
{
    public class Confirmpage
    {
            
        private IWebDriver driver;
        public Confirmpage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement typeind;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement textindia;

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2")]
        private IWebElement confirmpagecheckbox;

        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchase;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement alert;

        public void gettypeind(string countryname)
        {
            typeind.SendKeys(countryname);
            //return typeind;
        }

        public void waitfortext()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public void gettextindia()
        {
            textindia.Click();
        }

        public void getconfirmpagecheckbox()
        {
            confirmpagecheckbox.Click();
        }

        public void getpurchase()
        {
            purchase.Click();
        }

        public IWebElement getalert()
        {
            return alert;
        }
    }
}
