using Trianz.DataUtlis;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trianz.MagentoPages;
//using Trianz.ApplicationSetup;
using System.Collections.ObjectModel;
using AventStack.ExtentReports;

namespace DataDrivenFramework
{
    class LoginTest : MagentoSetup
    {
        [Test,Category("valid")]
        public void ValidCredentialTest()
        {
           // test = extent.CreateTest("ValidCredentialTest");

            try
            {
                HomePage home = new HomePage(driver);
                home.ClickOnMyAccount();

                LoginPage login = new LoginPage(driver);
                login.EnterEmailAddress("balaji0017@gmail.com");
                login.EnterPassword("welcome@123");
                login.ClickOnLogin();

                MainPage main = new MainPage(driver, wait);
                main.WaitForLogOutPresent();

                string actualTitle = main.GetCurrentTitle();
                Console.WriteLine(actualTitle);

                Assert.AreEqual("My Account", actualTitle, "Assertion on ValidCredentialTest");

                main.ClickOnLogOut();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Error message " + ex.Message);
                Assert.Fail();
            }

        }

        //bala@gmail.com, bala123
        //john@gmail.com,john@123

        //[TestCase("bala@gmail.com","bala123")]
        //[TestCase("john@gmail.com", "john@123")]

        public static object[] InvalidCredentialsData()
        {
            object[] main = ExcelUtlis.ConvertSheetToObject(@"D:\Mine\Company\Trianz\DataDrivenFramework\DataDrivenFramework\TestData\MagentoData.xlsx", "InvalidCredentials");
            return main;
        }

        [Test, TestCaseSource("InvalidCredentialsData"),Category("invalid"),Ignore("not req")]
        public void InvalidCredentialTest(string userName, string password)
        {
           // test = extent.CreateTest("InvalidCredentialTest");
            try
            {
                HomePage home = new HomePage(driver);
                home.ClickOnMyAccount();

                LoginPage login = new LoginPage(driver);
                login.EnterEmailAddress(userName);
                login.EnterPassword(password);
                login.ClickOnLogin();

                string actualErrorText = login.GetInvalidErrorMessage();

                string expectedErrorText = "Invalid login or password.";

                Assert.AreEqual(expectedErrorText, actualErrorText, "Assertion on InvalidCredentialTest");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Error message " + ex.Message);
                Assert.Fail();
            }
        }


        [Test,Category("valid")]
        public void CheckLinksCountInDashboard()
        {
           // test = extent.CreateTest("CheckLinksCountInDashboard");
            try
            {
                HomePage home = new HomePage(driver);
                home.ClickOnMyAccount();
                test.Log(Status.Info, "HomePage Completed");

                LoginPage login = new LoginPage(driver);
                login.EnterEmailAddress("balaji0017@gmail.com");
                login.EnterPassword("welcome@123");
                login.ClickOnLogin();
                test.Log(Status.Info, "LoginPage Completed");

                MainPage main = new MainPage(driver, wait);
                main.WaitForLogOutPresent();
                test.Log(Status.Info, "MainPage Completed");

                int linkCount = main.GetTotalLinkCount();

                Assert.IsTrue(linkCount == 26, "Assertion failed on link count");
                test.Log(Status.Info, "Assertion Completed with linkcount "+linkCount);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Error message " + ex.Message);
                Assert.Fail();
            }
        }

    }
}
