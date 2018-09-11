using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Customer
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string CustomerPwd { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string CustomerPostbox { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string CustomerTel { get; set; }
    }
}
