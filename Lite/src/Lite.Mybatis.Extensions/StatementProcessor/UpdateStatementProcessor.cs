using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;

namespace Lite.Mybatis.Extensions
{
    internal class UpdateStatementProcessor : IMappedStatementProcessor
    {
        public Type StatementProcessedType
        {
            get
            {
                return typeof(UpdateMappedStatement);
            }
        }

        public void Process(IInvocation invocation, ISqlMapper sqlMapper, string statementId)
        {
            invocation.ReturnValue = sqlMapper.Update(statementId, invocation.Arguments[0]);
        }
    }
}
