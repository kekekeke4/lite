using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.RestSharp.Extensions.Attributes
{
    public class POSTAttribute : HttpMethodMappingAttribute
    {
        public POSTAttribute(string path) : base(path)
        {
        }

        public override HttpMethod MethodType
        {
            get
            {
                return HttpMethod.POST;
            }
        }
    }
}
