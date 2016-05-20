using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json
{
    public enum JSONValueType
    {
        Int,
        Bool,
        Float,
        String,
        DateTime,
        Array,
        Object,
        Null
    }

    public class JSONValue
    {
        public JSONValueType ValueType
        {
            get; set;
        }

        public string Name { get; set; }

        public string StringValue { get; set; }
        
        public double FloatValue { get; set; }

        public int IntegerValue { get; set; }

        public bool BoolValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        public JSONObject ObjectValue { get; set; }
        
    }
}
