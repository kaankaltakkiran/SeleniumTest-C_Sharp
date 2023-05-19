using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using PageObjectModel.Reports;
using NUnit.Framework.Interfaces;

namespace PageObjectModel.Source.Drivers
{
    //Test ayarları ve yönlendirmeleri
    public class Driver
    {
        //Aynı Anda çalıştırma İçin Eklendi
        [ThreadStatic]

        public static IWebDriver _driver;
        [SetUp]
        public void InitScript()
        {
            //Test oluşturma
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            //Driver başlatma
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        //Test bittiğinde
        [TearDown]
        public void Cleanup()
        {
           
            EndTest();
            ExtentReporting.EndReporting();
            _driver.Quit();
        }

        //Ekran görüntüsü alma
        public string GetScreenshot()
        {
            var file=((ITakesScreenshot)_driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }
        //Test sonlandırma durum ile mesaj bilgisi
        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            //Test fail veya pass olma durumlarında mesajları raporda gösterme
            switch(testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}"); break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test has skipped {message}"); break;
                default:
                    break;
            }
            //Test bittiğinde ekran görüntüsü al
            ExtentReporting.LogScreenShot("Ending Test",GetScreenshot());
        }
    }
}
