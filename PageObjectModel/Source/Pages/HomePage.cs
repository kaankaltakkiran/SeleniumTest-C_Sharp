using OpenQA.Selenium;
using PageObjectModel.Source.Drivers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Source.Pages
{
    public class HomePage:Driver
    {
 
        [FindsBy(How =How.Id,Using = "twotabsearchtextbox")]
        private IWebElement _searchtxtbox;

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        private IWebElement _searchbtn;

        [FindsBy(How = How.Id, Using = "sp-cc-accept")]
        private IWebElement _advsbtn;
        //loginpage giriş yap
        [FindsBy(How=How.Id,Using = "nav-link-accountList")]
        public IWebElement _signlink;



        public HomePage() { 
            PageFactory.InitElements(_driver, this);
        }
        public void Search(string searchtext)
        {
            _advsbtn.Click();
            Thread.Sleep(2000);
            _searchtxtbox.SendKeys(searchtext);
            Thread.Sleep(2000);
            _searchbtn.Click();
        }
    }
}
