using System.Threading.Tasks;
using Inventory.IServices.BASE;
using Inventory.Model.Models;

namespace Inventory.IServices;

public interface ITenantService : IBaseServices<SysTenant>
{
    public Task SaveTenant(SysTenant tenant);

    public Task InitTenantDb(SysTenant tenant);
}