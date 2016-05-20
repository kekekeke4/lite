using Lite.Json.Utils;
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

    public class JSONValue : IJSONString
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

        public string ToJSONString()
        {
            StringBuilder sb = new StringBuilder();
            switch (ValueType)
            {
                case JSONValueType.String:
                    WriteStringValue(sb);
                    break;
                case JSONValueType.Array:
                case JSONValueType.Object:
                    WrietObjectValue(sb);
                    break;
                case JSONValueType.Int:
                    WriteIntegerValue(sb);
                    break;
                case JSONValueType.Float:
                    WriteFloatValue(sb);
                    break;
                case JSONValueType.Bool:
                    WriteBoolValue(sb);
                    break;
                case JSONValueType.Null:
                    WriteNullValue(sb);
                    break;
            }
            return sb.ToString();
        }

        private void WriteStringValue(StringBuilder sb)
        {
            WritrName(sb);

            sb.Append("\"");
            
            int pos = 0;
            while (pos != StringValue.Length)
            {
                char ch = StringValue[pos];
                if (ch == MarkerConst.DoubleQuote)
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append(MarkerConst.DoubleQuote);
                    pos++;
                    continue;
                }
                else if (ch == '\b')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('b');
                    pos++;
                    continue;
                }
                else if (ch == '\r')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('r');
                    pos++;
                    continue;
                }
                else if (ch == '\f')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('f');
                    pos++;
                    continue;
                }
                else if (ch == '\t')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('t');
                    pos++;
                    continue;
                }
                else if (ch == '\n')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('n');
                    pos++;
                    continue;
                }
                else if (ch == '\\')
                {
                    sb.Append(MarkerConst.EscapeCharacter);
                    sb.Append('\\');
                    pos++;
                    continue;
                }
                else if (ch > 0 && ch <= 0x1F)
                {
                    sb.AppendFormat("\\u%04X", (int)ch);
                    pos++;
                    continue;
                }
                
                sb.Append(ch);
                pos++;
            }
            
            sb.Append("\"");
        }

        private void WriteIntegerValue(StringBuilder sb)
        {
            WritrName(sb);

            sb.Append(IntegerValue.ToString());
        }

        private void WriteFloatValue(StringBuilder sb)
        {
            WritrName(sb);
            sb.Append(FloatValue.ToString());
        }

        private void WriteBoolValue(StringBuilder sb)
        {
            WritrName(sb);
            sb.Append(BoolValue ? "true" : "false");
        }

        private void WriteNullValue(StringBuilder sb)
        {
            WritrName(sb);
            sb.Append("null");
        }

        private void WrietObjectValue(StringBuilder sb)
        {
            WritrName(sb);

            sb.Append(ObjectValue.ToJSONString());
        }

        private void WritrName(StringBuilder sb)
        {
            if (string.IsNullOrEmpty(Name))
            {
                sb.Append("\"");
                sb.Append(Name);
                sb.Append("\"");
                sb.Append(":");
            }
        }
    }
}
