using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianz.MagentoPages
{
    class HomePage
    {
        private By myAccLoc = By.LinkText("My Account");
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
           this.driver = driver;
        }

        public void ClickOnMyAccount()
        {
            IWebElement myAccEle = driver.FindElement(myAccLoc);
            myAccEle.Click();
        }
    }
}
