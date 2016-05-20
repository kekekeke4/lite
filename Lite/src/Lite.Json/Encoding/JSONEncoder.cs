using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Encoding
{
    public class JSONEncoder
    {
        public string Encode(JSONObject jobj)
        {
            if (jobj == null)
            {
                return "";
            }
            return jobj.ToJSONString();
        }
    }
}
