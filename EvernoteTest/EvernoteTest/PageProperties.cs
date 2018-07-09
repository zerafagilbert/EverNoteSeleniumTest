using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteTest
{
    //Base Page Property Class
    public class PageProperties
    {
        //enum PropertyType
        //{
        //    ClassName,
        //    CssSelector,
        //    Equals,
        //    Id,
        //    LinkText,
        //    Name,
        //    PartialLinkText,
        //    ReferenceEquals,
        //    TagName,
        //    XPath
        //}

        public static IWebDriver driver { get; set; }
    }
}
