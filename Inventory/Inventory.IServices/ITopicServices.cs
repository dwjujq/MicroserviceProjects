using Inventory.IServices.BASE;
using Inventory.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.IServices
{
    public interface ITopicServices : IBaseServices<Topic>
    {
        Task<List<Topic>> GetTopics();
    }
}
