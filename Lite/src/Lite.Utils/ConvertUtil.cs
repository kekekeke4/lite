using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class ConvertUtil
    {
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

    }
}
