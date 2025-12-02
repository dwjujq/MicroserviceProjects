using System.Threading.Tasks;
using Inventory.IServices.BASE;
using Inventory.Model.IDS4DbModels;

namespace Inventory.IServices
{
    public partial interface IApplicationUserServices : IBaseServices<ApplicationUser>
    {
        bool IsEnable();
    }
}