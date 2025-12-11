using DotNetCore.CAP;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace JCZY.CAP
{
    public static class Extensions
    {
        public static ICapTransaction BeginCapTransaction(this ISqlSugarClient sugarClient, ICapPublisher publisher, bool autoCommit = false)
        {
            var dispatcher = publisher.ServiceProvider.GetRequiredService<IDispatcher>();
            sugarClient.Ado.BeginTran();
            var transaction = new SqlSugarTransaction(dispatcher, sugarClient.Ado)
            {
                AutoCommit = autoCommit
            };
            return publisher.Transaction = transaction;
        }
    }
}
