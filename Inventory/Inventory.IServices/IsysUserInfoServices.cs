    

using Inventory.IServices.BASE;
using Inventory.Model.Models;
using System.Threading.Tasks;

namespace Inventory.IServices
{	
	/// <summary>
	/// sysUserInfoServices
	/// </summary>	
    public interface ISysUserInfoServices :IBaseServices<SysUserInfo>
	{
        Task<SysUserInfo> SaveUserInfo(string loginName, string loginPwd);
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
