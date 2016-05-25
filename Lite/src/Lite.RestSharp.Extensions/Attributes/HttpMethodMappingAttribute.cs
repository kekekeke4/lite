using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public abstract class HttpMethodMappingAttribute:Attribute
    {
        protected HttpMethodMappingAttribute(string path)
        {
            Path = path;
        }
        
        public abstract HttpMethod MethodType { get; }
        
        public string Path { get; set; }
    }
}
