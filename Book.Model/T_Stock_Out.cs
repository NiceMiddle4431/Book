using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Stock_Out
    {
        public T_Stock_OutHead Head { get; set; }
        public List<T_Stock_OutItems> Items { get; set; }
    }
    public class T_Stock_OutHead
    {
        /// <summary>
        /// OutHead的Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 创建人的名字
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 买家Id
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public Book.Model.T_Base_Customer Customer { get; set; }
    }
    public class T_Stock_OutItems
    {
        /// <summary>
        /// OutItems的Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// OutHead的Id
        /// </summary>
        public int HeadId { get; set; }
        /// <summary>
        /// Head
        /// </summary>
        public T_Stock_OutHead Head { get; set; }
        /// <summary>
        /// Book的id
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Book对象
        /// </summary>
        public T_Base_Book Book { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
    }
}
