using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace EvernoteTest
{
    //Selenium Set Methods used for elements 
    public static class SeleniumSetMethods
    {
        /// <summary>
        /// Entended method to enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText (this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        /// Entend method to click
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Entend method to submit
        /// </summary>
        /// <param name="element"></param>
        public static void Submits(this IWebElement element)
        {
            element.Submit();
        }
    }
}
