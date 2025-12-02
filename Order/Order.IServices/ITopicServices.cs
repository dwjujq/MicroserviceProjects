using Order.IServices.BASE;
using Order.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.IServices
{
    public interface ITopicServices : IBaseServices<Topic>
    {
        Task<List<Topic>> GetTopics();
    }
}
