using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色信息
        /// </summary>
        public Book.Model.T_Base_Menu Role { get; set; }
    }
}
