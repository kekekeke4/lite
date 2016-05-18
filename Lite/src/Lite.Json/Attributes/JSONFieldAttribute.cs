using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Attributes
{
    public class JSONFieldAttribute : Attribute
    {
        public JSONFieldAttribute(string field)
        {
            Field = field;
        }

        public string Field { get; set; }
    }
}
