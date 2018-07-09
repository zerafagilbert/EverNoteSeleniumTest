using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{

    class UserProfilePageObjects
    {
        public UserProfilePageObjects()
        {
            PageFactory.InitElements(PageProperties.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "GJDCG5COP")]
        private IList<IWebElement> imgUser { get; set; }

        [FindsBy(How = How.Id, Using = "gwt-debug-AccountMenu-name")]
        private IWebElement lblUsername { get; set; }

        [FindsBy(How = How.Id, Using = "gwt-debug-AccountMenu-logout")]
        private IWebElement btnLogout { get; set; }

        [FindsBy(How = How.ClassName, Using = "focus-NotesView-Note-noteTitle")]
        private IList<IWebElement> lblNotesTile { get; set; }

        [FindsBy(How = How.ClassName, Using = "focus-NotesView-Note-snippet")]
        private IList<IWebElement> lblNotesBody { get; set; }

        [FindsBy(How = How.ClassName, Using = "GJDCG5CP3 GJDCG5CFK GJDCG5CHK")]
        private IList<IWebElement> btnProfileOptions { get; set; }

        [FindsBy(How = How.Id, Using = "gwt-debug-Sidebar-newNoteButton-container")]
        private IWebElement btnAddNote { get; set; }

        [FindsBy(How = How.ClassName, Using = "focus-NotesView-Note focus-NotesView-Note-hasImagesAndText")]
        private IWebElement lstNotes { get; set; }
        
        public bool isNoteListVisible()
        {
            return lstNotes.GetVisibilityState();
        }

        public void ClickUserImageIcon()
        {
            imgUser.ElementAt(0).Clicks();
        }

        public void ClickLogout()
        {
            //Logout is on the 4th option
            btnProfileOptions.ElementAt(4).Clicks();
        }

        public string GetUsername()
        {
            return lblUsername.GetText();
        }

        public void ClickAddNote()
        {
            btnAddNote.Clicks();
        }

        public bool CheckIfNoteListedByTitle(string noteTitle/* , string noteBody*/)
        {
            return (lblNotesTile[0].GetText() == noteTitle ? true : false);
        }

        public bool CheckIfNoteListedByBody(int index, string noteBody)
        {
            if (lblNotesBody.ElementAt(index).GetText() == noteBody)
            {
                Console.WriteLine("Log: Note Found In The List!");
                return true;
            }
            else
                return false;
        }

        public void Logout ()
        {
            btnLogout.Clicks();
        }

    }
}
