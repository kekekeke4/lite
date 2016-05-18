using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json
{
    public class JSONObject : JSON
    {
        public int Count
        {
            get; private set;
        }

        public bool IsEmpty { get; private set; }

        public bool ContainsKey(object key)
        {
            return false;
        }

        public bool ContainsValue(object value)
        {
            return false;
        }
    }
}
