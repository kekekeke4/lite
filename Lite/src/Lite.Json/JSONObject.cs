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

    public class JSONObject: IJSONString
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

        public string ToJSONString()
        {
            string startStr = "";
            string endStr = "";
            if (ObjectType == JSONObjectType.Object)
            {
                startStr = "{";
                endStr = "}";
            }
            else
            {
                startStr = "[";
                endStr = "]";
            }

            StringBuilder valSb = new StringBuilder();

            foreach (JSONValue val in Values)
            {
                if (valSb.Length > 0)
                {
                    valSb.Append(",");
                }
                valSb.Append(val.ToJSONString());
            }

            return string.Format("{0}{1}{2}", startStr, valSb, endStr);
        }
    }
}
