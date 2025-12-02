using System.Threading.Tasks;
using Inventory.IServices.BASE;
using Inventory.Model.Models;

namespace Inventory.IServices
{
    public partial interface IPasswordLibServices :IBaseServices<PasswordLib>
    {
        Task<bool> TestTranPropagation2();
        Task<bool> TestTranPropagationNoTranError();
        Task<bool> TestTranPropagationTran2();
        Task<bool> TestTranPropagationTran3();
    }
}
