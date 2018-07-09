using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{
    //Selenium Get Methods used for elements 
    public static class SeleniumGetMethods
    {
        /// <summary>
        /// Extend method to get text
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Extend method to get element from a list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="tagName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IWebElement GetIndexedTagName(this IWebElement element, string tagName, int index)
        {
            return element.FindElements(By.TagName(tagName))[index];
        }

        /// <summary>
        /// Extend method to get if element is enabled / disabled
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetDisableState(this IWebElement element)
        {
            try
            {
                return element.Enabled;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Extend method to get if element is visible or not
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetVisibilityState(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
