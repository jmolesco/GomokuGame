﻿using System.Text;
using System.Text.RegularExpressions;

namespace PG.API.Util
{
    public class CommonFuncs
    {
        public static bool IsValidStringContentExist(string input, string comparison)
        {
                   return Regex.IsMatch(input, @"\b"+comparison+@"\b");
        }
    }
}
