using Lite.Json.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Encoding
{
    public class JSONDecoder
    {
        private string curToken;
        private string prefToken;
        private int curPos;
        private string jsonStr;

        public JSONDecoder(string jsonStr)
        {
            this.jsonStr = jsonStr;
        }

        public JSONObject Parse()
        {
            curPos = 0;

            JSONObject jobj = null;
            while (curPos < jsonStr.Length)
            {
                int ch = jsonStr[curPos];
                if (ch == MarkerConst.LeftBrace)
                {
                    curPos++;
                    jobj = BuildJsonObj(null, JSONObjectType.Object);
                    break;
                }
                else if (ch == MarkerConst.LeftBracket)
                {
                    curPos++;
                    jobj = BuildJsonObj(null, JSONObjectType.Array);
                    break;
                }

                curPos++;
            }

            return jobj;
        }


        private JSONObject BuildJsonObj(JSONObject parent,JSONObjectType objType)
        {
            JSONObject jobj = new JSONObject(objType);
            string token = NextToken(false);
            while (curPos != jsonStr.Length)
            {
                if (TokenIsComment(token))
                {
                    GoCommentEnd(token);
                    token = NextToken(false);
                }
                else if (token == "\"")
                {
                    jobj.Values.Add(BuildJsonVal(jobj));
                    token = NextToken(false);
                }else if (token == "}")
                {
                    if(objType== JSONObjectType.Array)
                    {
                        token = NextToken(false);
                    }
                    else
                    {
                        break;
                    }
                }else if (token == "{")
                {
                    jobj.Values.Add(BuildJsonVal(jobj));
                    token = NextToken(false);
                }
                else if (token=="[")
                {
                    jobj.Values.Add(BuildJsonVal(jobj));
                    token = NextToken(false);
                }
                else if (token=="]")
                {
                    break;
                }
                else if (token==":")
                {
                    token = NextToken(false);
                }
                else if (token==",")
                {
                    token = NextToken(false);
                }
                else
                {
                    jobj.Values.Add(BuildJsonVal(jobj));
                    token = NextToken(false);
                }
            }

            //node.ok = 1;
            //return node;
            return jobj;
        }

        private JSONValue BuildJsonVal(JSONObject parent)
        {
            bool hashKey = false;
            int doubleQuoteMeet = 0;

            JSONValue jval = new JSONValue();
            string token = curToken;
            while (curPos < jsonStr.Length)
            {
                if (TokenIsComment(token))
                {
                    GoCommentEnd(token);
                    token = NextToken(false);
                }
                else if (token == "{")
                {
                    jval.ObjectValue = BuildJsonObj(parent, JSONObjectType.Object);
                    jval.ValueType = JSONValueType.Object;
                    //value.node.type = JavaEasyJson.JsonNodeType.NODE_OBJECT;
                    //value.ok = 1;
                    return jval;
                }
                else if (token == "[")
                {
                    jval.ObjectValue = BuildJsonObj(parent, JSONObjectType.Array);
                    jval.ValueType = JSONValueType.Array;
                    //value.node.type = JavaEasyJson.JsonNodeType.NODE_ARRAY;
                    //value.ok = 1;
                    return jval;
                }
                else if (token == "}")
                {
                    curPos--;
                    break;
                }
                else if (token == "]")
                {
                    curPos--;
                    break;
                }
                else if (token == "\"")
                {
                    doubleQuoteMeet++;
                    if (jval.Name==null)
                    {
                        jval.ValueType = JSONValueType.String;
                    }

                    token = NextToken((doubleQuoteMeet & 0x01) != 0);
                }
                else if (token == ":")
                {
                    if (doubleQuoteMeet == 2)
                    {
                        hashKey = jval.Name != null;
                    }
                    else if (doubleQuoteMeet == 3)
                    {
                        hashKey = true;
                    }
                    else
                    {
                        hashKey = false;
                    }

                    jval.ValueType = JSONValueType.Null;
                    token = NextToken(false);
                    if (curPos == jsonStr.Length)
                    {
                        curPos--;
                    }
                }
                else if (token == ",")
                {
                    break;
                }
                else
                {
                    if (jval.Name==null)
                    {
                        jval.Name = token;
                    }
                    else if (jval.StringValue==null)
                    {
                        AssignStringToJsonValue(jval, token);
                        if (jsonStr[curPos] == '"')
                        {
                            curPos++;
                        }
                        break;
                    }
                    token = NextToken(false);
                }
            }

            if (!hashKey)
            {
                AssignStringToJsonValue(jval, jval.Name);
                jval.Name = "";
                //value.ok = 1;
            }
            return jval;
        }

        private bool AssignStringToJsonValue(JSONValue jval, string str)
        {
            jval.StringValue = str;
            if (jval.ValueType == JSONValueType.String)
            {
                jval.StringValue = str;
            }
            else
            {
                string strObjRef = "";
                strObjRef += MarkerConst.ObjectRefrence;
                if (str == "null")
                {
                    jval.ValueType = JSONValueType.Null;
                }
                else if (str == "true")
                {
                    jval.ValueType = JSONValueType.Bool;
                    jval.BoolValue = true;
                }
                else if (str == "false")
                {
                    jval.ValueType = JSONValueType.Bool;
                    jval.BoolValue = false;
                }
                else if (str.Contains(strObjRef))
                {
                    jval.ValueType = JSONValueType.Float;
                    jval.FloatValue = double.Parse(str);
                }
                else
                {
                    jval.ValueType = JSONValueType.Int;
                    jval.IntegerValue = int.Parse(str);
                }
            }

            return false;
        }
        
        private string NextToken(bool toNextJsonDoubleQuote)
        {
            prefToken = curToken;
            string token = "";
            if (toNextJsonDoubleQuote)
            {
                if (jsonStr[curPos] == MarkerConst.DoubleQuote)
                {
                    curPos++;
                }

                while (curPos < jsonStr.Length)
                {
                    if (jsonStr[curPos] == MarkerConst.EscapeCharacter)
                    {
                        if (curPos + 1 != jsonStr.Length)
                        {
                            if (jsonStr[curPos + 1] == MarkerConst.DoubleQuote)
                            {
                                token += MarkerConst.DoubleQuote;
                                curPos += 2;
                            }
                            else
                            {
                                token += jsonStr[curPos];
                                curPos++;
                            }
                        }
                    }
                    else
                    {
                        if (jsonStr[curPos] == MarkerConst.DoubleQuote)
                        {
                            break;
                        }
                        else
                        {
                            token += jsonStr[curPos];
                            curPos++;
                        }
                    }
                }

                return curToken = token;
            }
            else
            {
                while (curPos < jsonStr.Length)
                {
                    char ch = jsonStr[curPos];

                    bool breakLoop = false;

                    switch (ch)
                    {
                        case MarkerConst.DoubleQuote:
                        case MarkerConst.RightBrace:
                        case MarkerConst.LeftBrace:
                        case MarkerConst.LeftBracket:
                        case MarkerConst.RightBracket:
                        case MarkerConst.Colon:
                        case MarkerConst.Comma:
                        case MarkerConst.Hash:
                            breakLoop = true;
                            if (string.IsNullOrEmpty(token))
                            {
                                token += ch;
                                curPos++;

                            }
                            break;
                        case MarkerConst.Slash:
                            int nextPos = curPos + 1;
                            if (nextPos != jsonStr.Length && jsonStr[nextPos] == MarkerConst.Slash)
                            {
                                token = "//";
                                curPos += 2;
                                breakLoop = true;
                            }
                            else if (nextPos != jsonStr.Length && jsonStr[nextPos] == MarkerConst.Star)
                            {
                                token = "/*";
                                curPos += 2;
                                breakLoop = true;
                            }
                            else
                            {
                                token += ch;
                            }
                            break;
                        case MarkerConst.EscapeCharacter:
                            if (!string.IsNullOrEmpty(token))
                            {
                                int nPos = curPos + 1;
                                char nCh = jsonStr[nPos];
                                if (nCh == MarkerConst.DoubleQuote)
                                {
                                    token += MarkerConst.DoubleQuote;
                                    curPos++;
                                }
                                else if (nCh == 'b')
                                {
                                    token += '\b';
                                    curPos++;
                                }
                                else if (nCh == 'f')
                                {
                                    token += '\f';
                                    curPos++;
                                }
                                else if (nCh == 't')
                                {
                                    token += '\t';
                                    curPos++;
                                }
                                else if (nCh == 'n')
                                {
                                    token += '\n';
                                    curPos++;
                                }
                                else if (nCh == 'r')
                                {
                                    token += '\r';
                                    curPos++;
                                }
                                else if (nCh == '\\')
                                {
                                    token += '\\';
                                    curPos++;
                                }
                                else if (nCh == '/')
                                {
                                    token += '/';
                                    curPos++;
                                }
                                else if (nCh == 'u')
                                {
                                    token += jsonStr[curPos];
                                }
                                else
                                {
                                    token += jsonStr[curPos];
                                }
                            }
                            break;
                        case ' ':
                        case '\t':
                        case '\n':
                        case '\r':
                            if (!string.IsNullOrEmpty(token))
                            {
                                breakLoop = true;
                            }
                            break;
                        default:
                            token += jsonStr[curPos];
                            break;
                    }

                    if (breakLoop)
                    {
                        break;
                    }

                    curPos++;
                }
            }

            return curToken = token;
        }

        private void GoCommentEnd(string commentStyle)
        {
            if (commentStyle == "//" ||   //cpp style
                commentStyle == "#") //yaml style
            {
                while (curPos < jsonStr.Length)
                {
                    if (jsonStr[curPos] == '\n') //unix linux style
                    {
                        curPos++;
                        break;
                    }
                    else if (jsonStr[curPos] == '\r' &&
                       jsonStr[curPos + 1] == '\n') //windows style
                    {
                        curPos += 2;
                        break;
                    }
                    curPos++;
                }
            }
            else if (commentStyle == "/*") //c style
            {
                while (curPos < jsonStr.Length)
                {
                    if (jsonStr[curPos] == '*' &&
                        jsonStr[curPos + 1] == '/')
                    {
                        curPos += 2;
                        break;
                    }
                    curPos++;
                }
            }
        }


        private bool TokenIsComment(string token)
        {
            return (token == "//" || token == "/*" || token == "*/" || token == "#");
        }
    }
}
