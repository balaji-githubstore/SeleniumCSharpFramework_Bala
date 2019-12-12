/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDrivenFramework.DataUtlis;
using NUnit.Framework;

namespace DataDrivenFramework
{
    class NunitFeatureTest
    {
        //one parameter
        *//*public static object[] ProvideName()
        {
            object[] main = new object[4];
            main[0] = "bala";
            main[1] = "john";
            main[2] = "peter";
            main[3] = "Paul";

            return main;
        }


        [Test,TestCaseSource("ProvideName")]
        public void TestMethod(string name)
        {
            Console.WriteLine(name);
        }

*//*

        //bala@gmail.com, bala123
        //peter@gmail.com,peter123
        //john@gmail.com, john123


        *//*public static object[] ProvideNameAndPassword()
        {
            object[] temp1 = new object[3]; //temp --> no of columns
            temp1[0] = "bala@gmail.com";
            temp1[1] = "bala123";
            temp1[2] = "my account";

            object[] temp2 = new object[3];
            temp2[0] = "peter@gmail.com";
            temp2[1] = "peter123";
            temp2[2] = "my account";

            object[] temp3 = new object[3];
            temp3[0] = "john@gmail.com";
            temp3[1] = "john123";
            temp3[2] = "my account";

            object[] main = new object[3]; //main --> no.of rows //3 temp
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }*//*
        //public static object[] ProvideNameAndPassword()
        //{
        //    object[] main = ExcelUtlis.ConvertSheetToObject();
        //    return main;
        //}

      //  [Test, TestCaseSource("ProvideNameAndPassword")]
        public void TestMethod(string name, string password)
        {
            Console.WriteLine(name);
            Console.WriteLine(password);
        }










        *//*   [Test]
           public void TestMethod1([Range(0,20,2)]int phoneNumber)
           {
               Console.WriteLine(phoneNumber);
           }
           [Test]
           public void TestMethod2([Random(100000, 200000, 5)]int phoneNumber)
           {
               Console.WriteLine(phoneNumber);
           }
           [Test]
           public void TestMethod3([Values(200, 300, 400)]int phoneNumber)
           {
               Console.WriteLine(phoneNumber);
           }*//*

    }
}
*/