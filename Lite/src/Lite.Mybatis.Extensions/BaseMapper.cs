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
        private readonly Dictionary<Type, IMappedStatementProcessor> processors;
        public BaseMapper(ISqlMapper sqlMapper)
        {
            SqlMapper = sqlMapper;
            processors = new Dictionary<Type, IMappedStatementProcessor>();
        }

        public ISqlMapper SqlMapper { get; private set; }
    }
}
