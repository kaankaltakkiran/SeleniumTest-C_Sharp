using AngleSharp.Io;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Reports;
using PageObjectModel.Source.Drivers;
using PageObjectModel.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PageObjectModel.Tests
{
    public class ExamplePageTests:Driver
    {
        [Test]
        //Textboxtaki değeri okuyup ona göre test işlemi
        public void textboxtest()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            //Form elaman yollama
            page.textBoxForm("Kaan","kaan_fb_aslan@hotmail.com","izmir","karşıyaka");
            //Beklenen Değer
            string expectedtext = "Kaan";
            //Okunan Değer
            string actualtext=_driver.FindElement(By.Id("userName")).GetAttribute("value");
            Assert.AreEqual(expectedtext, actualtext);
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //Sitedeki başlığa göre test işlemi
        public void titleVerify()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            page.textBoxForm("Kaan", "kaan_fb_aslan@hotmail.com", "izmir", "karşıyaka");
            string expectedttitle = "DEMOQAA";
            Assert.AreEqual(expectedttitle,_driver.Title);
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //Sitedeki url göre test işlemi
        public void urlVerify()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            page.textBoxForm("Kaan", "kaan_fb_aslan@hotmail.com", "izmir", "karşıyaka");
            string expectedUrl = "https://demoqa.com/text-box";
            Assert.AreEqual(expectedUrl,_driver.Url,"Url Not Match");
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //Textboxtaki değeri okuyup ona göre test işlemi
        public void textboxtestt()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            //Form elaman yollama
            page.textBoxForm("Kaan", "kaan_fb_aslan@hotmail.com", "izmir", "karşıyaka");
            //Beklenen Değer
            string expectedtext = "Kaan";
            //Okunan Değer
            string actualtext = _driver.FindElement(By.CssSelector("p#name")).Text;
            Assert.AreEqual("Name:Kaan", actualtext);
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //Checkbox kontrol
        public void checkboxtest()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            page.checkbox();
            //Checkbox kontrolü yapılamadı
            IWebElement element = _driver.FindElement(By.CssSelector("div:nth-of-type(2) > .custom-control-label"));
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //File Download
        public void fileDownload()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            page.download();
            ExtentReporting.LogInfo("Test Successful");
        }
        [Test]
        //Checkbox kontrol değer okuma ile
        public void checkboxTestKaan()
        {
            ExtentReporting.LogInfo("Starting test ");
            ExamplePage page = new ExamplePage();
            _driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            page.newcheckbox();
            //Beklenen Değer
            string expectedtext = "react";
            //Okunan Değer
            string actualtext = _driver.FindElement(By.CssSelector("div#result > .text-success")).Text;
            Assert.AreEqual(expectedtext, actualtext);
            ExtentReporting.LogInfo("Test Successful");
        }
    }
}
