using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    public class MapperProxy
    {
        public MapperProxy(ISqlMapper sqlMapper)
        {
            SqlMapper = sqlMapper;
        }

        public ISqlMapper SqlMapper { get; private set; }
    }
}
