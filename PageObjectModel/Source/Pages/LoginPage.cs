using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Reports;
using PageObjectModel.Source.Drivers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Source.Pages
{
    public class LoginPage:Driver
    {
        //Element değerleri alma
        [FindsBy(How = How.Id, Using = "ap_email")]
        private IWebElement _signemail;

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement _signcontinue;

        [FindsBy(How = How.Id, Using = "ap_password")]
        private IWebElement _signpassword;

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        private IWebElement _signbtn;
        //homepage de public de yapabilirsin
        [FindsBy(How = How.Id, Using = "sp-cc-accept")]
        private IWebElement _advsbtn;

        //Constructor methot
        public LoginPage()
        {
          //Driver için
            PageFactory.InitElements(_driver, this);
        }

        //Test için gerekli methotlar
        public void login(string usermail, string password)
        {
            //Rapordaki işlem basamağı
            ExtentReporting.LogInfo($"Write '{usermail}','{password}' Writed");
            //Örnek bekleme için
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Örnek element gözükene kadar bekleme
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//a/h3")));
            _advsbtn.Click();
            ExtentReporting.LogInfo("Click Button");
            //HomePagedeki login kısmına tıklama
            HomePage hp = new HomePage();
            hp._signlink.Click();
            //sendkeys veri yolluyor teste
            _signemail.SendKeys(usermail);
            _signcontinue.Click();
            _signpassword.SendKeys(password);
            _signbtn.Click();
        }
    }
}
