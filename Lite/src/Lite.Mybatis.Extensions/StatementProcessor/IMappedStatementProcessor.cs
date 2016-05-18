using Castle.DynamicProxy;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Mybatis.Extensions
{
    internal interface IMappedStatementProcessor
    {
        void Process(IInvocation invocation, ISqlMapper sqlMapper, string statementId);

        Type StatementProcessedType { get; }
    }

   
}
