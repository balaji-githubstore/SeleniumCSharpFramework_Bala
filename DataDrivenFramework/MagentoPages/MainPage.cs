using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianz.MagentoPages
{
    class MainPage
    {
        By logOutLoc = By.PartialLinkText("Out");
        IWebDriver driver;
        WebDriverWait wait;

        public MainPage(IWebDriver driver,WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void WaitForLogOutPresent()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(logOutLoc));
        }

        public string GetCurrentTitle()
        {
            string actualTitle = driver.Title;
            return actualTitle;
        }

        public void ClickOnLogOut()
        {
            IWebElement logOutEle = driver.FindElement(logOutLoc);
            logOutEle.Click();
        }
        
        public int GetTotalLinkCount()
        {
            ReadOnlyCollection<IWebElement> linksEle = driver.FindElements(By.TagName("a"));
            return linksEle.Count;
        }

    }
}
