using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using System.Reflection;

namespace Lite.Mybatis.Extensions
{
    internal class SelectStatementProcessor : IMappedStatementProcessor
    {
        public Type StatementProcessedType
        {
            get
            {
                return typeof(SelectMappedStatement);
            }
        }

        public void Process(IInvocation invocation, ISqlMapper sqlMapper, string statementId)
        {
            MethodInfo method = invocation.Method;
            if (method.ReflectedType.IsGenericType)
            {
                Type type = typeof(List<>).MakeGenericType(method.ReturnType.GetGenericArguments());
                object list= Activator.CreateInstance(type);
                MethodInfo queryForList = typeof(ISqlMapper).GetMethod("QueryForList", new Type[] { typeof(string), typeof(object), typeof(List<>) });
                queryForList.Invoke(sqlMapper, new object[] { statementId, invocation.Arguments[0], list });
                invocation.ReturnValue = list;
            }
            else
            {
                invocation.ReturnValue = sqlMapper.QueryForObject(statementId, invocation.Arguments[0]);
            }
        }
    }
}
