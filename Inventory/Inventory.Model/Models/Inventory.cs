using SqlSugar;
using System;

namespace Inventory.Model.Models
{
    /// <summary>
    /// 库存
    /// </summary>
    public class Inventory : RootEntityTkey<long>
    {
        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }
    }
}
