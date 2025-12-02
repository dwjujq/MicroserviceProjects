using System.Threading.Tasks;
using Order.IServices.BASE;
using Order.Model.Models;

namespace Order.IServices;

public interface ITenantService : IBaseServices<SysTenant>
{
    public Task SaveTenant(SysTenant tenant);

    public Task InitTenantDb(SysTenant tenant);
}