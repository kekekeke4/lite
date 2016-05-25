using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public class DELETEAttribute : HttpMethodMappingAttribute
    {
        public DELETEAttribute(string path) : base(path)
        {
        }

        public override HttpMethod MethodType
        {
            get
            {
                return HttpMethod.DELETE;
            }
        }
    }
}
