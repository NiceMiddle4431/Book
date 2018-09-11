using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Stock_In
    {
        public T_Stock_InHead Head { get; set; }
        public List<T_Stock_InItems> Items { get; set; }
    }
    public class T_Stock_InHead
    {
        /// <summary>
        /// InHead的Id
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
        /// 供应商Id
        /// </summary>
        public int ProviderId { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public Book.Model.T_Base_Provider Provider{ get; set; }
    }
    public class T_Stock_InItems
    {
        /// <summary>
        /// InItems的Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// InHead的Id
        /// </summary>
        public int HeadId { get; set; }
        /// <summary>
        /// Head
        /// </summary>
        public T_Stock_InHead Head { get; set; }
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

    public class T_Stock_In_Page
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 待加载的信息
        /// </summary>
        public List<Book.Model.T_Stock_In> list { get; set; }
    }

}
