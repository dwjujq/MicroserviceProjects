using Inventory.Common;
using Inventory.IRepository.Base;
using Inventory.IServices;
using Inventory.Model.Models;
using Inventory.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
        /// <summary>
        /// 获取开Bug数据（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<TopicDetail>> GetTopicDetails()
        {
            return await base.Query(a => !a.tdIsDelete && a.tdSectendDetail == "tbug");
        }
    }
}
