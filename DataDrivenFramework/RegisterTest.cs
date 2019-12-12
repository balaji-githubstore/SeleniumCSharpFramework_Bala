using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Trianz.ApplicationSetup;
using Trianz.DataUtlis;
using Trianz.MagentoPages;

namespace DataDrivenFramework
{
    class RegisterTest : MagentoSetup
    {
        //static obj

        [Test,Category("valid")]
        public void RegistrationFormTest()
        {

           // Console.WriteLine(firstName);


            string name = "balajidinakaran1@gmail.com";


            /*HomePage home = new HomePage(driver);
            home.ClickOnMyAccount();

            LoginPage login = new LoginPage(driver);
            login.ClickOnRegister();

            RegisterPage register = new RegisterPage(driver);

            register.FillAndSubmitRegistrationForm();*/


            //page
            //Assert.AreEqual("", "", "");

            DataTable dt = DataAccessMSSQL.SelectQueryToDatatable("select * from tbl_magentotest");
            Console.WriteLine(dt.Rows.Count);

               

            string query = "SELECT count(*)  FROM [dbo].[tbl_magentotest] where mailid='" + name + "'";

            string cellValue = DataAccessMSSQL.GetFirstCellValue(query);
            Console.WriteLine(cellValue);


            Assert.IsTrue(Convert.ToInt32(cellValue) >= 1, "Assertion for database check");
            //assert with database 
        }
    }
}
