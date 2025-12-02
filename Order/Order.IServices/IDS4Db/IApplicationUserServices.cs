using System.Threading.Tasks;
using Order.IServices.BASE;
using Order.Model.IDS4DbModels;

namespace Order.IServices
{
    public partial interface IApplicationUserServices : IBaseServices<ApplicationUser>
    {
        bool IsEnable();
    }
}