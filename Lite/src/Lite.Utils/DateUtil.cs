using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class DateUtil
    {
        private const string Rfc822DateFormat = "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T";
        private const string Iso8601DateFormat = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";

        public static long GetNowTimestamp()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }


        public static string FormatRfc822Date(DateTime dtime)
        {
            return dtime.ToUniversalTime().ToString(Rfc822DateFormat,
                               CultureInfo.InvariantCulture);
        }

        public static DateTime ToRfc822Date(DateTime dtime)
        {
            string utcStr = FormatRfc822Date(dtime);
            return ParseRfc822Date(utcStr);
        }
       
        public static DateTime ParseRfc822Date(string s)
        {
            return DateTime.SpecifyKind(
                DateTime.ParseExact(s, Rfc822DateFormat, CultureInfo.InvariantCulture),
                DateTimeKind.Utc);
        }

       
        public static string FormatIso8601Date(DateTime dtime)
        {

            return dtime.ToUniversalTime().ToString(Iso8601DateFormat,
                               CultureInfo.CurrentCulture);
        }
    }
}
