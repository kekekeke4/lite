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
            string json = "{"+
                "\""+"$type"+"\":"+"\""+"hikang"+"\","+
                "\"" + "name" + "\":" + "\"" + "海康" + "\"," +
                "\"" + "age" + "\":"  + "123" + "," +
                "\"" + "score" + "\":"  + "0.555" + "," +
                "\"" + "isself" + "\":" +  "true" + "," +
                "\"" + "sex" + "\":" + "\"" + "男" + "\","+
                "}";

            Json.Encoding.JSONDecoder jdecoder = new Json.Encoding.JSONDecoder(json);
            JSONObject jobj = jdecoder.Parse();
        }
    }
}
