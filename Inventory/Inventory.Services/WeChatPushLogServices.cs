using Inventory.Common;
using Inventory.Common.Helper;
using Inventory.IRepository.Base;
using Inventory.IServices;
using Inventory.Model;
using Inventory.Model.Models;
using Inventory.Model.ViewModels;
using Inventory.Services.BASE;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services
{
    /// <summary>
	/// WeChatPushLogServices
	/// </summary>
    public class WeChatPushLogServices : BaseServices<WeChatPushLog>, IWeChatPushLogServices
    {

    }
}