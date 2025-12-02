using System.Threading.Tasks;
using Inventory.Common.DB;
using Inventory.Common.DB.Extension;
using Inventory.IRepository.Base;
using Inventory.Model.IDS4DbModels;
using Inventory.Services.BASE;

namespace Inventory.IServices
{
    public class ApplicationUserServices : BaseServices<ApplicationUser>, IApplicationUserServices
    {
        public bool IsEnable()
        {
            var configId = typeof(ApplicationUser).GetEntityTenant();
            return Db.AsTenant().IsAnyConnection(configId);
        }
    }
}