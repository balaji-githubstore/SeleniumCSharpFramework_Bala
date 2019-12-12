using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianz.MagentoPages
{
    class RegisterPage
    {
        private By firstNameLoc = By.Id("");
        private IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillAndSubmitRegistrationForm()
        {
            driver.FindElement(firstNameLoc).SendKeys("Bala");

        }
    }
}
