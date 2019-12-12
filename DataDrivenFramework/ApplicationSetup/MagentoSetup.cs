using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trianz.DataUtlis;

namespace DataDrivenFramework
{
    class MagentoSetup
    {
        public IWebDriver driver;
        public WebDriverWait wait;


        public static ExtentReports extent;
        public static ExtentTest test;

        public static string screenShotPath;
        public static string path;



        [OneTimeSetUp]
        public void Init()
        {
            if(extent ==null)
            {
                //path = @"D:\Mine\Company\Trianz\DataDrivenFramework\DataDrivenFramework\Reports\magentoreport.html";
                path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                path = path.Substring(0, path.LastIndexOf("bin"));
                path = new Uri(path).LocalPath;
                string reportPath = path + @"Reports\";
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }


        [SetUp]
        public void Intialization()
        {
            string browserName = ConfigurationUtils.GetValueFromAppSettings("browser");

            LaunchBrowser(browserName);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            driver.Url = ConfigurationUtils.GetValueFromAppSettings("url");

            string testName = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testName);
        }

        [TearDown]
        public void AddTestResultAndQuitBrowser()
        {
            string testName = TestContext.CurrentContext.Test.Name;

            TestStatus status =  TestContext.CurrentContext.Result.Outcome.Status;

            if (status ==TestStatus.Failed)
            {      
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                TakeScreenShot(testName);
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Failed - Snapshot below:");
                test.AddScreenCaptureFromPath(screenShotPath,title:testName);
            }
            else if (status == TestStatus.Passed)
            {
                TakeScreenShot(testName);
                test.Log(Status.Pass, "Passed - Snapshot below:"); 
                test.AddScreenCaptureFromPath(screenShotPath, title: testName) ;
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - "+testName);
            }
            driver.Quit();
        }

        public void TakeScreenShot(string testName)
        {
            if (driver != null)
            {
                string name = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
                // screenShotPath = @"D:\Mine\Company\Trianz\DataDrivenFramework\DataDrivenFramework\Reports\screenshot_" + testName + "_" + name;
                screenShotPath = path + @"\Reports\screenshot_" + testName + "_" + name;
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);
            }
        }
        public void LaunchBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "ff":
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ch":
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

    }
}




/*if(browserName.ToLower().Equals("ff") || browserName.ToLower().Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if(browserName.ToLower().Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }*/
