using AngleSharp.Dom;
using OpenQA.Selenium;
using PageObjectModel.Reports;
using PageObjectModel.Source.Drivers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PageObjectModel.Source.Pages
{
    public class ExamplePage:Driver
    {
        [FindsBy(How =How.Id,Using = "userName")]
        private IWebElement _fullName;

        [FindsBy(How=How.Id,Using = "submit")]
        private IWebElement _sendbtn;

        [FindsBy(How =How.Id,Using = "userEmail")]
        private IWebElement _usermail;
        [FindsBy(How = How.Id, Using = "currentAddress")]
        private IWebElement _currentaddress;
        [FindsBy(How = How.Id, Using = "permanentAddress")]
        private IWebElement _parmentetadress;

        [FindsBy(How=How.CssSelector,Using = ".show .textt")]
        private IWebElement _checkboxdiv;

        [FindsBy(How = How.CssSelector, Using = "[for='yesRadio']")]
        private IWebElement _checkbox;

        [FindsBy(How = How.Id, Using = "uploadFile")]
        private IWebElement _dowlandbtn;

        [FindsBy(How = How.CssSelector, Using = ".rct-icon.rct-icon-expand-all")]
        private IWebElement _pluscheckbox;

        [FindsBy(How = How.CssSelector, Using = "li:nth-of-type(2) > ol > li:nth-of-type(1) > ol > li:nth-of-type(1) > .rct-text > label > .rct-checkbox > .rct-icon.rct-icon-uncheck")]
        private IWebElement _selectcheckbox;

        public ExamplePage() {
            //Sekme büyütme
            _driver.Manage().Window.Maximize();
            PageFactory.InitElements(_driver, this);
        }

        public void textBoxForm(string name, string email,string currentAddress,string permanentAddress )
        {
            _fullName.SendKeys(name);
            _usermail.SendKeys(email);
            _currentaddress.SendKeys(currentAddress);
            _parmentetadress.SendKeys(permanentAddress);
            ExtentReporting.LogInfo($"Write '{name}','{email}','{currentAddress}','{permanentAddress}' Writed");
            Thread.Sleep(2000);
            _sendbtn.Click();
        }
        public void checkbox()
        {
           // _checkboxdiv.Click();
            Thread.Sleep(1000);
            _checkbox.Click();
            ExtentReporting.LogInfo("Checkbox Clickted");

        }
        public void download()
        {
            _dowlandbtn.SendKeys(@"C:\Users\kaan_\Desktop\pc.png");
            ExtentReporting.LogInfo("Upload Started ");

        }
        public void newcheckbox()
        {
            _pluscheckbox.Click();
            _selectcheckbox.Click();
            ExtentReporting.LogInfo("Checkbox Clickted");
        }
    }
}
