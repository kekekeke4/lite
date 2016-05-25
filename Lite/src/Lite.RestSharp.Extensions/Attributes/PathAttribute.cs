using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public class PathAttribute : ParameterMappingAttribute
    {
        public PathAttribute(string name) : base(name)
        {
        }

        public override ParameterType ParameterType
        {
            get
            {
                return ParameterType.Path;
            }
        }
    }
}
