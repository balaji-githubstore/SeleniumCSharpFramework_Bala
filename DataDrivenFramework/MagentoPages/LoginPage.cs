using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianz.MagentoPages
{
    class LoginPage
    {
        private By emailLoc = By.Id("email");
        private By passLoc = By.Id("pass");
        private By loginLoc = By.XPath("//span[text()='Login']");
        private By invalidLoc = By.XPath("//span[contains(text(),'Invalid')]");
        private By registerLoc = By.XPath("//span[text()='Register']");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EnterEmailAddress(string emailAddress)
        {
            IWebElement emailEle = driver.FindElement(emailLoc);
            emailEle.SendKeys(emailAddress);
        }

        public void EnterPassword(string password)
        {
            IWebElement passEle = driver.FindElement(passLoc);
            passEle.SendKeys(password);
        }

        public void ClickOnLogin()
        {
            IWebElement loginEle = driver.FindElement(loginLoc);
            loginEle.Click();
        }


        public string GetInvalidErrorMessage()
        {
            IWebElement errorEle = driver.FindElement(invalidLoc);
            return errorEle.Text;
        }

        public void ClickOnRegister()
        {
            IWebElement regEle = driver.FindElement(registerLoc);
            regEle.Click();
        }


        /*public void ProvideLoginCredential(string emailAddress, string password)
        {
            IWebElement emailEle = driver.FindElement(emailLoc);
            emailEle.SendKeys(emailAddress);
            IWebElement passEle = driver.FindElement(passLoc);
            passEle.SendKeys(password);
            IWebElement loginEle = driver.FindElement(loginLoc);
            loginEle.Click();
        }*/


    }
}
