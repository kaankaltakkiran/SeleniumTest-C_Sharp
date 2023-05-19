using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PageObjectModel.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using PageObjectModel.Source.Drivers;
using PageObjectModel.Reports;

namespace PageObjectModel.Tests
{
    public class LoginPageTests:Driver
    {
      
        //Test Oluşturma
        [Test]
        public void InvalidLogin() {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            //Sayfa nesneni üretme
            LoginPage lg = new LoginPage();
            //Hangi sayfaya yönlendirme
            _driver.Navigate().GoToUrl("https://www.amazon.com.tr/");
            //Oluşturduğumuz methota değer yollama
            lg.login("kaan_fb_aslan@hotmail.com", "123456789");
            //Assert ile test kontrol istenen olumuş mu ? fail veya pass
            Assert.True(_driver.Title.Contains("Amazon Giriş Yap"));

        }
        [Test]
        public void InvalidLogin2()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            //Sayfa nesneni üretme
            LoginPage lg = new LoginPage();
            //Hangi sayfaya yönlendirme
            _driver.Navigate().GoToUrl("https://www.amazon.com.tr/");
            //Oluşturduğumuz methota değer yollama
            lg.login("kaan_fb_aslan@hotmail.com", "123456789");
            //Assert ile test kontrol istenen olumuş mu ? fail veya pass durumu
            Assert.True(_driver.Title.Contains("Anasayfa"));

        }



    }
}
