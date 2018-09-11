using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class Home
    {
        /// <summary>
        /// 书籍总数
        /// </summary>
        public int BookCount { get; set; }
        /// <summary>
        /// 供应商总数
        /// </summary>
        public int ProviderCount { get; set; }
        /// <summary>
        /// 客户总数
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 入库单总数
        /// </summary>
        public int InHeadCount { get; set; }
        /// <summary>
        /// 出库单总数
        /// </summary>
        public int OutHeadCount { get; set; }
    }
}
