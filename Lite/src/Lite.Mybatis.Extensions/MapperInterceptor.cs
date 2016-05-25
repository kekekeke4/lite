using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    public class MapperInterceptor : IInterceptor
    {
        private static readonly Dictionary<Type, IMappedStatementProcessor> processors;

        static MapperInterceptor()
        {
            processors = new Dictionary<Type, IMappedStatementProcessor>();

            IMappedStatementProcessor[] ps = new IMappedStatementProcessor[] {
                new SelectStatementProcessor(),
                new DeleteStatementProcessor(),
                new UpdateStatementProcessor(),
                new InsertStatementProcessor()
            };

            foreach (IMappedStatementProcessor p in ps)
            {
                processors.Add(p.StatementProcessedType, p);
            }
        }

        public void Intercept(IInvocation invocation)
        {
            MapperProxy baseMapper = (MapperProxy)invocation.Proxy;
            ISqlMapper sqlMapper = baseMapper.SqlMapper;

            MethodInfo method = invocation.Method;
            if (method.DeclaringType == null)
            {
                return;
            }

            string mapFullName = method.DeclaringType.FullName;
            string statementId = string.Format("{0}.{1}", mapFullName, method.Name);
            IMappedStatement ms = sqlMapper.GetMappedStatement(statementId);
            Type type = ms.GetType();
            if (processors.ContainsKey(type))
            {
                IMappedStatementProcessor p = processors[type];
                p.Process(invocation, sqlMapper, statementId);
            }
        }
    }
}
