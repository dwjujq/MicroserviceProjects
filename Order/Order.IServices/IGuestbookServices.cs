using Order.IServices.BASE;
using Order.Model;
using Order.Model.Models;
using System.Threading.Tasks;

namespace Order.IServices
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