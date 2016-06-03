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
            IEnumerable<T> attrs = GetAttributes<T>(instance, inherit);
            if (attrs == null)
            {
                return null;
            }

            foreach (T att in attrs)
            {
                return att;
            }

            return null;
        }

        public static IEnumerable<T> GetAttributes<T>(object instance, bool inherit = false) where T : Attribute
        {
            if (instance == null)
            {
                yield break;
            }

            Type insType = instance.GetType();
            object[] attrs = insType.GetCustomAttributes(typeof(T), inherit);
            if (attrs == null || attrs.Length == 0)
            {
                yield break;
            }

            foreach (object att in attrs)
            {
                yield return (T)att;
            }
        }
    }
}
