using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Project_Blog.Classes
{
    public class Utils
    {
        public static string CutText(string text, int maxLen = 100)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Length > maxLen)
            {
                return text.Substring(0, maxLen) + "...";
            }
            return text;
        }
    }
}