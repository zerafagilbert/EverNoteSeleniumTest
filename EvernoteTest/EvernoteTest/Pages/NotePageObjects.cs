using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{
    class NotePageObjects
    {
        public NotePageObjects()
        {
            PageFactory.InitElements(PageProperties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "gwt-debug-NoteTitleView-textBox")]
        private IWebElement txtNoteTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div")]
        private IWebElement txtNoteBody { get; set; }

        [FindsBy(How = How.Id, Using = "gwt-debug-NoteAttributes-doneButton")]
        private IWebElement btnDone { get; set; }

        public bool isDoneButtonVisible()
        {
            return btnDone.GetVisibilityState();
        }

        public void EnterNoteTitle(string title)
        {
            txtNoteTitle.EnterText(title);
            txtNoteTitle.SendKeys(Keys.Tab); 
        }

        public void EnterNoteBody(string body)
        {
            txtNoteBody.SendKeys(body);
        }

        public void ClickDoneButton()
        {
            btnDone.Clicks();
        }
    }
}
