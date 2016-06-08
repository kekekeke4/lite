using Lite.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string json = "{"+
            //    "\""+"$type"+"\":"+"\""+"hikang"+"\","+
            //    "\"" + "name" + "\":" + "\"" + "海康" + "\"," +
            //    "\"" + "age" + "\":"  + "123" + "," +
            //    "\"" + "score" + "\":"  + "0.555" + "," +
            //    "\"" + "isself" + "\":" +  "true" + "," +
            //    "\"" + "sex" + "\":" + "\"" + "男" + "\","+
            //    "}";

            string json = "[{\"sex\":\"man\"},{\"sex\":\"woman\"}]";

            Json.Encoding.JSONDecoder jdecoder = new Json.Encoding.JSONDecoder(json);
            JSONObject jobj = jdecoder.Parse();

            string dataStr = "2016-03-31T15:32:32.8655104+08:00";
            DateTime dt = DateTime.Parse(dataStr);
        }
    }
}
