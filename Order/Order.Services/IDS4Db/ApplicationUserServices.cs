using System.Threading.Tasks;
using Order.Common.DB;
using Order.Common.DB.Extension;
using Order.IRepository.Base;
using Order.Model.IDS4DbModels;
using Order.Services.BASE;

namespace Order.IServices
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