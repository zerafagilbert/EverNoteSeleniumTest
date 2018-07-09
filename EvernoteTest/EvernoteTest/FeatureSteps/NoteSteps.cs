using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace EvernoteTest.FeatureSteps
{
    [Binding]
    class NoteSteps : PageProperties
    {
        HomePageObjects homePageObjects = new HomePageObjects();
        LoginPageObjects loginPageObjects = new LoginPageObjects();
        UserProfilePageObjects userProfilePageObjects = new UserProfilePageObjects();
        NotePageObjects notePageObjects = new NotePageObjects();

        [When(@"I click on the add note button")]
        public void WhenIClickOnTheAddNoteButton()
        {
            Thread.Sleep(6000);
            userProfilePageObjects.ClickAddNote();
            Console.WriteLine("Log: Add note button selected");
        }

        [When(@"I confirm that a new note is provided")]
        public void WhenIConfirmThatANewNoteIsProvided()
        {
            Thread.Sleep(4000);
            Assert.IsTrue(notePageObjects.isDoneButtonVisible() , "Log: New note not provided");
            Console.WriteLine("Log: New note provided");
        }

        [When(@"I enter (.*) note title")]
        public void WhenIEnterNoteTitle(string title)
        {
            Thread.Sleep(4000);
            notePageObjects.EnterNoteTitle(title);
            Console.WriteLine("Log: Note Title Entered");
        }

        [Then(@"I click on the done button")]
        public void ThenIClickOnTheDoneButton()
        {
            Thread.Sleep(4000);
            notePageObjects.ClickDoneButton();
            Console.WriteLine("Log: Done button clicked");
        }

        [When(@"I see the note list")]
        public void WhenISeeTheNoteList()
        {
            Thread.Sleep(4000);
            Assert.IsTrue(!userProfilePageObjects.isNoteListVisible() , "Log: Note List Not provided");
            Console.WriteLine("Log: Note list provided");
        }

        [Then(@"I confirm that the new note (.*) is added")]
        public void ThenIConfirmThatTheNewNoteIsAdded(string title)
        {
            Thread.Sleep(4000);
            Assert.IsTrue(userProfilePageObjects.CheckIfNoteListedByTitle(title),"Log: Added note Not Found!");
            Console.WriteLine("Log: Added note listed!");
        }

        [When(@"I will logout")]
        public void WhenIWillLogout()
        {
            Thread.Sleep(4000);
            userProfilePageObjects.Logout();
        }

        [Then(@"I shall be directed to page (.*)")]
        public void ThenIShallBeDirectedToPageHttpsEvernote_ComLogged_Out(string url)
        {
            Thread.Sleep(2000);
            Assert.IsTrue(PageProperties.driver.Url.ToString().Contains(url), "Log: Intended page not loaded");
            Console.WriteLine("Log: Intended page loaded");
        }

    }
}
