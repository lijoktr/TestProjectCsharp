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
    public class shoppage
    {
        By Selectproduct = By.CssSelector("h4.card-title a");

        By Addkart = By.CssSelector(".card-footer button");

        private IWebDriver driver;
        public shoppage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }                
        
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> listproduct;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutbutton;
        
        public void waitfordisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getproductlist()
        {
            return listproduct;
        }

        public By selectproduct()
        {
            return Selectproduct;
        }

        public By addtokart()
        {
            return Addkart;
        }

        public Checkoutpage getcheckout()
        {
            checkoutbutton.Click();
            return new Checkoutpage(driver);
        }
    }




}
