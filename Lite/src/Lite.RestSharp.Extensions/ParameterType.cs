using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions
{
    public enum ParameterType
    {
        Query = 0,
        Path = 1,
        File = 2,
        Form = 3,
        Body = 4
    }
}
