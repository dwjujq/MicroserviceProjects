using DotNetCore.CAP;
using DotNetCore.CAP.Transport;
using SqlSugar;

namespace JCZY.CAP
{
    public class SqlSugarTransaction : CapTransactionBase
    {
        public SqlSugarTransaction(IDispatcher dispatcher, IAdo ado) : base(dispatcher)
        {
            Ado = ado;
            DbTransaction = ado.Transaction;
        }

        public IAdo Ado { get; set; }

        public override void Commit()
        {
            Ado.CommitTran();
            Flush();
        }

        public override async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await Ado.CommitTranAsync();
            Flush();
        }

        public override void Dispose()
        {
            Ado.Dispose();
        }

        public override void Rollback()
        {
            Ado.RollbackTran();
        }

        public override async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await Ado.RollbackTranAsync();
        }
    }
}
