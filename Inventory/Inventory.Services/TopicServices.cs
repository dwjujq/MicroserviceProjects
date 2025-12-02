using Inventory.Common;
using Inventory.IRepository.Base;
using Inventory.IServices;
using Inventory.Model.Models;
using Inventory.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class TopicServices: BaseServices<Topic>, ITopicServices
    {
        /// <summary>
        /// 获取开Bug专题分类（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 60)]
        public async Task<List<Topic>> GetTopics()
        {
            return await base.Query(a => !a.tIsDelete && a.tSectendDetail == "tbug");
        }

    }
}
