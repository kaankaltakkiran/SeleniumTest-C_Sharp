using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Reports;
using PageObjectModel.Source.Drivers;
using PageObjectModel.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectModel.Tests
{
    //Hepsini aynı anda çalıştırıyor
    //Daha hızlı çalıştırma
    //Paralel Test
    [Parallelizable(ParallelScope.All)]
    public class HomeTests:Driver
    {
        [Test]
        public void SearchBook()
        {
            ExtentReporting.LogInfo("Starting test ");
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("https://www.amazon.com.tr/");
            hp.Search("Nutuk");
            Assert.True(_driver.Title.Contains("Nutuk"));
        }
        [Test]
        public void SearchPhone()
        {
            ExtentReporting.LogInfo("Starting test ");
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("https://www.amazon.com.tr/");
            hp.Search("Samsung");
            Assert.True(_driver.Title.Contains("Samsung"));
        }
        [Test]
        public void SearchWatch()
        {
            ExtentReporting.LogInfo("Starting test ");
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("https://www.amazon.com.tr/");
            hp.Search("Watch");
            Assert.True(_driver.Title.Contains("Watch"));
        }

    }
}
