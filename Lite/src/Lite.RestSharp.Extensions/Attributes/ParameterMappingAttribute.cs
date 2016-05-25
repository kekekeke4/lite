using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public abstract class ParameterMappingAttribute : Attribute
    {
        protected ParameterMappingAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract ParameterType ParameterType { get; }
    }
}
