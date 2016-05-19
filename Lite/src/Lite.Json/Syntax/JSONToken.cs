using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Syntax
{
    public enum JSONToken :int
    {
        LITERAL_FLOAT = 3,

        LITERAL_STRING = 4,

        LITERAL_ISO8601_DATE = 5,

        TRUE = 6,

        FALSE = 7,

        NULL = 8,

        NEW = 9,

        LPAREN = 10, // ("("),

        RPAREN = 11, // (")"),

        LBRACE = 12, // ("{"),

        RBRACE = 13, // ("}"),

        LBRACKET = 14, // ("["),

        RBRACKET = 15, // ("]"),

        COMMA = 16, // (","),

        COLON = 17, // (":"),

        IDENTIFIER = 18,

        FIELD_NAME = 19,

        EOF = 20,

        SET = 21,

        TREE_SET = 22,

        UNDEFINED = 23, // undefined
    }
}
