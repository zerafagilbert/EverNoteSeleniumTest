using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EvernoteTest.FeatureSteps
{
    [Binding]
        
    class LoginSteps : PageProperties
    {
        HomePageObjects homePageObjects = new HomePageObjects();
        LoginPageObjects loginPageObjects = new LoginPageObjects();
        UserProfilePageObjects userProfilePageObjects = new UserProfilePageObjects();

        [Given(@"I have visted (.*)")]
        public void GivenIHaveVistedWww_Evernote_Com(string url)
        {
            driver.Navigate().GoToUrl(url);
            Console.WriteLine("Log: Page passed to be navigated");
            //Assert.IsTrue(PageProperties.driver.Url.ToString() == url);
        }

        [When(@"I confirn the page is loaded")]
        public void WhenIConfirnThePageIsLoaded()
        {
            Assert.IsTrue(homePageObjects.isLoginDisplayed() , "Log: Page not loaded") ;
            Console.WriteLine("Log: Intended page loaded");
        }

        [When(@"I have to click on sign button")]
        public void WhenIHaveToClickOnSignButton()
        {
            homePageObjects.LoginIn();
            Console.WriteLine("Log: Login button pressed");
        }

        [Then(@"the new page should be (.*)")]
        public void ThenTheNewPageShouldBeHttpsWww_Evernote_ComLogin_Action(string url)
        {
            Thread.Sleep(3000);
            Assert.IsTrue(PageProperties.driver.Url.ToString() == url, "Log: Intended page not loaded");
            Console.WriteLine("Log: Intended page loaded");
        }


        [When(@"login page is loaded fill email with (.*)")]
        public void WhenLoginPageIsLoadedFillEmailWithUsername(string email)
        {
            loginPageObjects.EnterEmail(email);
            Console.WriteLine("Log: Email / Username Entered");
        }

        [When(@"I press the continue button")]
        public void WhenIPressTheContinueButton()
        {
            loginPageObjects.ClickLoginButton();
            Console.WriteLine("Log: Continue Button Pressed");
        }

        [Then(@"I should see the password field")]
        public void ThenIShouldSeeThePasswordField()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(loginPageObjects.isPasswordFieldDisabled(), "Log: Password Field Disabled");
            Console.WriteLine("Log: Password Field Visable");
        }

        [When(@"the password field is displayed fill it with (.*)")]
        public void WhenThePasswordFieldIsDisplayedFillItWithPassword(string password)
        {
            Thread.Sleep(2000);
            loginPageObjects.EnterPassword(password);
            Console.WriteLine("Log: Password Field Filled");
        }

        [When(@"I press the sign-in button")]
        public void WhenIPressTheSign_InButton()
        {
            loginPageObjects.ClickLoginButton();
            Console.WriteLine("Log: Sign-in Button Pressed");
        }

        [Then(@"the new page should contain (.*)")]
        public void ThenTheNewPageShouldContain(string url)
        {
            Thread.Sleep(6000);
            Assert.IsTrue(PageProperties.driver.Url.ToString().Contains(url) , "Log: Intended page not loaded");
            Console.WriteLine("Log: Intended page loaded");
        }

        [When(@"I click on the account image")]
        public void WhenIClickOnTheAccountImage()
        {
            Thread.Sleep(2000);
            userProfilePageObjects.ClickUserImageIcon();
        }

        [When(@"the username should be (.*)")]
        public void ThenTheUsernameShouldBe(string username)
        {
            Assert.IsTrue(userProfilePageObjects.GetUsername().ToLower() == username.ToLower(), "Log: Wrong user profile loaded");
            Console.WriteLine("Log: Correct user profile loaded!");
        }

        [Then(@"I should leave")]
        public void ThenIShouldLeave()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"login page is loaded with empty email")]
        public void WhenLoginPageIsLoadedWithEmptyEmail()
        {
            loginPageObjects.EnterEmail("");
            Console.WriteLine("Log: Email / Username Empty");
        }

        [Then(@"I should see an error (.*)")]
        public void ThenIShouldSeeAnErrorRequiredDataMissing(string errMessage)
        {
            Thread.Sleep(2000);
            Assert.IsTrue(loginPageObjects.errorMessage().ToLower() == errMessage.ToLower(), "Log: Wrong error message");
            Console.WriteLine("Log: Correct Error message!");
        }
    }
}
