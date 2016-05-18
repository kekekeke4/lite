using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    public class BaseMapper
    {
        public BaseMapper(ISqlMapper sqlMapper)
        {
            SqlMapper = sqlMapper;
        }

        public ISqlMapper SqlMapper { get; private set; }
    }
}
