using Inventory.IRepository.Base;
using Inventory.IServices;
using Inventory.Model.Models;
using Inventory.Services.BASE;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.FrameWork.Services
{
    /// <summary>
    /// sysUserInfoServices
    /// </summary>	
    public class SplitDemoServices : BaseServices<SplitDemo>, ISplitDemoServices
    {
        private readonly IBaseRepository<SplitDemo> _splitDemoRepository;
        public SplitDemoServices(IBaseRepository<SplitDemo> splitDemoRepository)
        {
            _splitDemoRepository = splitDemoRepository;
        }


    }
}
