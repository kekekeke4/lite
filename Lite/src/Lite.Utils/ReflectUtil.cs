using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class ReflectUtil
    {
        public static Dictionary<string, T> GetEnumDictionary<T>()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new NotSupportedException("the type not support,type must enum");
            }

            Array arr = Enum.GetValues(type);
            Dictionary<string, T> dic = new Dictionary<string, T>(arr.Length);
            foreach (object obj in arr)
            {
                dic.Add(obj.ToString(), (T)obj);
            }

            return dic;
        }

        public static T GetAttribute<T>(object instance, bool inherit = false) where T : Attribute
        {
            if (instance == null)
            {
                return null;
            }

            Type insType = instance.GetType();
            object[] attrs = insType.GetCustomAttributes(typeof(T), inherit);
            if (attrs == null)
            {
                return null;
            }

            if (attrs.Length == 0)
            {
                return null;
            }

            return (T)attrs[0];
        }
    }
}
