using Order.IServices.BASE;
using Order.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.IServices
{
    public interface ITopicDetailServices : IBaseServices<TopicDetail>
    {
        Task<List<TopicDetail>> GetTopicDetails();
    }
}
