using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Stock_Report
    {
        /// <summary>
        /// 书籍ID
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 书籍名称
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Img { get; set; }
    }
}
