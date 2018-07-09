using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{
    class LoginPageObjects
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(PageProperties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "loginButton")]
        private IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Id, Using = "responseMessage")]
        private IWebElement lblMessage { get; set; }

        public void EnterEmail(string email)
        {
            txtEmail.EnterText(email);
        }

        public void ClickLoginButton()
        {
            btnLogin.Submits();
        }

        public void EnterPassword(string password)
        {
            txtPassword.EnterText(password);
        }

        public bool isPasswordFieldDisabled()
        {
            return txtPassword.GetDisableState();
        }

        public string errorMessage()
        {
            return lblMessage.GetText();
        }

        public UserProfilePageObjects SignIn(string email, string password)
        {
            EnterEmail(email);
            ClickLoginButton();
            EnterPassword(password);
            ClickLoginButton();
            return new UserProfilePageObjects();
        }
    }
}
