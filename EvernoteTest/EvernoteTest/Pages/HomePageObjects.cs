using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{
    class HomePageObjects
    {
        public HomePageObjects()
        {
            PageFactory.InitElements(PageProperties.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "button-cta sign-in-with-email")]
        private IWebElement btnSignIn { get; set; }

        [FindsBy(How = How.ClassName, Using = "utility-nav")]
        private IWebElement btnLoginHeader { get; set; }
        
        public LoginPageObjects SignIn()
        {
            btnSignIn.Clicks();
            return new LoginPageObjects();
        }

        public LoginPageObjects LoginIn()
        {
            btnLoginHeader.GetIndexedTagName("li", 0).GetIndexedTagName("a", 0).Click();
            return new LoginPageObjects();
        }

        public bool isLoginDisplayed()
        {
            return btnLoginHeader.GetVisibilityState();
        }
    }
}
