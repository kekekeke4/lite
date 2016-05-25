using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    public class MybatisAdapter
    {
        public static T Create<T>()
        {
            ProxyGenerator generator = new ProxyGenerator();
            MapperInterceptor mapperInterceptor = new MapperInterceptor();
            object proxy = generator.CreateClassProxy(typeof(MapperProxy), new Type[] { typeof(T) }, ProxyGenerationOptions.Default, new object[] { Mapper.Get() }, mapperInterceptor);
            return (T)proxy;
        }
    }
}
