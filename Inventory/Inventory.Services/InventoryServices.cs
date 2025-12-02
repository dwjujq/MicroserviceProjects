using Inventory.Common;
using Inventory.Common.Helper;
using Inventory.Common.Static;
using Inventory.Common.Utility;
using Inventory.IRepository.Base;
using Inventory.IServices;
using Inventory.Model;
using Inventory.Model.ViewModels;
using Inventory.Services.BASE;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public partial class InventoryServices : BaseServices<Model.Models.Inventory>, IInventoryServices
    {
        IHttpContextAccessor _httpContextAccessor;
        ILogger<InventoryServices> _logger;
        public InventoryServices(ILogger<InventoryServices> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Create(InventoryDto inventoryDto)
        {
            var inventory = new Model.Models.Inventory
            {
                Id = IdGeneratorUtility.NextId(),
                ProductId = inventoryDto.ProductId,
                Stock = inventoryDto.Stock
            };
            var id = await base.Add(inventory);
            return id>0;
        }

        public Task DeductInventory(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
