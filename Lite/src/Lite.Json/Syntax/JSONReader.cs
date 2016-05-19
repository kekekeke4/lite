using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Syntax
{
    public class JSONReader : IJSONReader
    {
        public static readonly char EOI = (char)0x1A;

        protected StringReader reader;
        protected char ch;
        protected int pos;
        protected int bp;
        protected int sp;
        protected int np;
        protected bool isEOF;

        public JSONReader(StringReader reader)
        {
            this.reader = reader;
        }

        public JSONToken Token
        {
            get;
            private set;
        }

        public void Read()
        {
            for (;;)
            {
                pos = bp;

                if (ch == '/')
                {
                    //skipComment();
                    continue;
                }

                if (ch == '"')
                {
                    ReadString();
                    return;
                }

                if (ch == ',')
                {
                    ReadChar();
                    Token = JSONToken.COMMA;
                    return;
                }

                if (ch >= '0' && ch <= '9')
                {
                    //scanNumber();
                    return;
                }

                if (ch == '-')
                {
                    //scanNumber();
                    return;
                }

                switch (ch)
                {
                    case '\'':
                        //if (!isEnabled(Feature.AllowSingleQuotes))
                        //{
                        //    throw new JSONException("Feature.AllowSingleQuotes is false");
                        //}
                        //scanStringSingleQuote();
                        return;
                    case ' ':
                    case '\t':
                    case '\b':
                    case '\f':
                    case '\n':
                    case '\r':
                        ReadChar();
                        break;
                    case 't':
                        //scanTrue();
                        return;
                    case 'f':
                        //scanFalse();
                        return;
                    case 'n':
                        //sacnNullOrNew();
                        return;
                    case 'T':
                    case 'N': // NULL
                    case 'S':
                    case 'u': // undefined
                        //scanIdent();
                        return;
                    case '(':
                        ReadChar();
                        Token = JSONToken.LPAREN;
                        return;
                    case ')':
                        ReadChar();
                        Token = JSONToken.RPAREN;
                        return;
                    case '[':
                        ReadChar();
                        Token = JSONToken.LBRACKET;
                        return;
                    case ']':
                        ReadChar();
                        Token = JSONToken.RBRACKET;
                        return;
                    case '{':
                        ReadChar();
                        Token = JSONToken.LBRACE;
                        return;
                    case '}':
                        ReadChar();
                        Token = JSONToken.RBRACE;
                        return;
                    case ':':
                        ReadChar();
                        Token = JSONToken.COLON;
                        return;
                    default:
                        if (IsEOF())
                        {
                            if(Token== JSONToken.EOF)
                            {
                                //throw new JSONException("EOF error");
                            }
                            Token = JSONToken.EOF;
                        }
                        else
                        {
                            if (ch == 31 || ch == 127)
                            {
                                ReadChar();
                                break;
                            }
                            ReadChar();
                        }
                        return;
                }
            }
        }

        public void ReadTo(JSONToken token)
        {
            throw new NotImplementedException();
        }

        public char ReadChar()
        {
            int ret = reader.Read();
            if (ret == -1)
            {
                ch= EOI;
                isEOF = true;
            }
            else
            {
                ch = (char)ret;
                isEOF = false;
            }

            return ch;
        }

        public bool IsEOF()
        {
            return ch == EOI || isEOF;
        }


        public void ReadString()
        {
            for (;;)
            {
                char tmpch = ReadChar();
                if (tmpch == '\"')
                {
                    break;
                }

                if (tmpch == EOI)
                {
                    //throw new JSONException("unclosed string : " + ch);
                }

                if (ch == '\\')
                {

                }
            }
        }
    }
}
