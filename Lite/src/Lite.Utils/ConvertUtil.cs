using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class ConvertUtil
    {
        private static readonly DateTime DEFAULT_DATETIME = DateTime.MinValue;
        private static readonly Guid DEFAULT_GUID = new Guid("00000000-0000-0000-0000-000000000000");

        public static int ToInt(string input, int defVal=0)
        {
            int ret = defVal;
            int.TryParse(input, out ret);
            return ret;
        }
        
        public static int ToInt(object obj,int defVal = 0)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToInt(obj.ToString(), defVal);
        }

        public static short ToShort(string input,short defVal = 0)
        {
            short ret = defVal;
            short.TryParse(input, out ret);
            return ret;
        }

        public static short ToShort(object obj,short defVal = 0)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToShort(obj.ToString(), defVal);
        }

        public static long ToLong(string input,long defVal = 0)
        {
            long ret = defVal;
            long.TryParse(input, out ret);
            return ret;
        }
        
        public static long ToLong(object obj, long  defVal = 0)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToLong(obj.ToString(), defVal);
        }

        public static double ToDouble(string input ,double defVal = 0.0)
        {
            double ret = defVal;
            double.TryParse(input, out ret);
            return ret;
        }

        public static double ToDouble(object obj,double defVal = 0.0)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToDouble(obj.ToString(), defVal);
        }

        public static float ToFloat(string input,float defVal = 0.0f)
        {
            float ret = defVal;
            float.TryParse(input, out ret);
            return ret;
        }

        public static float ToFloat(object obj,float defVal = 0.0f)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToFloat(obj.ToString(), defVal);
        }

        public static DateTime ToDateTime(string input, DateTime defVal)
        {
            DateTime ret = defVal;
            DateTime.TryParse(input, out ret);
            return ret;
        }

        public static DateTime ToDateTime(string input)
        {
            return ToDateTime(input, DEFAULT_DATETIME);
        }

        public static DateTime ToDateTime(object obj,DateTime defVal)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToDateTime(obj.ToString(), defVal);
        }

        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, DEFAULT_DATETIME);
        }

        public static Guid ToGuid(string input,Guid defVal)
        {
            Guid ret = defVal;
            Guid.TryParse(input, out ret);
            return ret;
        }

        public static Guid ToGuid(string input)
        {
            return ToGuid(input, DEFAULT_GUID);
        }

        public static Guid ToGuid(object obj,Guid defVal)
        {
            if (obj == null)
            {
                return defVal;
            }

            return ToGuid(obj.ToString(), defVal);
        }

        public static Guid ToGuid(object obj)
        {
            return ToGuid(obj, DEFAULT_GUID);
        }
    }
}
