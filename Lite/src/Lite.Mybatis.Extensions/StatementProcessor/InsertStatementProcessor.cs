using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    internal class InsertStatementProcessor : IMappedStatementProcessor
    {
        public Type StatementProcessedType
        {
            get
            {
                return typeof(InsertMappedStatement);
            }
        }

        public void Process(IInvocation invocation, ISqlMapper sqlMapper, string statementId)
        {
            invocation.ReturnValue = sqlMapper.Insert(statementId, invocation.Arguments[0]);
        }
    }
}
