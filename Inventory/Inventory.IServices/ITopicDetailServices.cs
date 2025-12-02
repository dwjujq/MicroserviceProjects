using Inventory.IServices.BASE;
using Inventory.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.IServices
{
    public interface ITopicDetailServices : IBaseServices<TopicDetail>
    {
        Task<List<TopicDetail>> GetTopicDetails();
    }
}
