using Order.Common;
using Order.Common.Helper;
using Order.IRepository.Base;
using Order.IServices;
using Order.Model;
using Order.Model.Models;
using Order.Model.ViewModels;
using Order.Services.BASE;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Services
{
    /// <summary>
	/// WeChatPushLogServices
	/// </summary>
    public class WeChatPushLogServices : BaseServices<WeChatPushLog>, IWeChatPushLogServices
    {

    }
}