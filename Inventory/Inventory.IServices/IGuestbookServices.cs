using Inventory.IServices.BASE;
using Inventory.Model;
using Inventory.Model.Models;
using System.Threading.Tasks;

namespace Inventory.IServices
{
    public partial interface IGuestbookServices : IBaseServices<Guestbook>
    {
        Task<MessageModel<string>> TestTranInRepository();
        Task<bool> TestTranInRepositoryAOP();

        Task<bool> TestTranPropagation();

        Task<bool> TestTranPropagationNoTran();

        Task<bool> TestTranPropagationTran();
        Task TestTranPropagationTran2();
        Task TestTranPropagationTran3();
    }
}