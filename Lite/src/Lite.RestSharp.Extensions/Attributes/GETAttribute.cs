using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public class GETAttribute : HttpMethodMappingAttribute
    {
        public GETAttribute(string path) : base(path)
        {

        }

        public override HttpMethod MethodType
        {
            get
            {
                return HttpMethod.GET;
            }
        }
    }
}
