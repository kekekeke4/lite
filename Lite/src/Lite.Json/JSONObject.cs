using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json
{
    public enum JSONObjectType
    {
        Object,
        Array,
    }

    public class JSONObject
    {
        public JSONObject()
        {
            Values = new List<JSONValue>();
        }

        public JSONObject(JSONObjectType type) :
            this()
        {
            ObjectType = type;
        }

        public List<JSONValue> Values { get; private set; }

        public JSONObjectType ObjectType { get; set; }
    }
}
