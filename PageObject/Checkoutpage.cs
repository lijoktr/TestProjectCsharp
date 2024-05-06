using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_C_seleniumframework.PageObject
{
    public class Checkoutpage
    {
        private IWebDriver driver;
        public Checkoutpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4")]
        private IList<IWebElement> checkoutlist;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutclick;

        public IList<IWebElement> getCheckoutlist()
        {
            return checkoutlist;
        }

        public Confirmpage getCheckoutclick()
        {
            checkoutclick.Click();
            return new Confirmpage(driver);
        }

    }
}
