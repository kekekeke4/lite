using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class MatchUtil
    {
        /// <summary>
        /// match the uint
        /// </summary>
        /// <returns></returns>
        public static bool MatchUInteger(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^-?[1-9]\d*$");
        }
    }
}
