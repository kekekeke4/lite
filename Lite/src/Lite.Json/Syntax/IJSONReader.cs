using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Syntax
{
    public interface IJSONReader
    {
        void Read();

        void ReadTo(JSONToken token);

        char ReadChar();

        JSONToken Token { get; }

        bool IsEOF();
    }
}
