using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Provider
    {
        /// <summary>
        /// 出版社Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 出版社电话号
        /// </summary>
        public string ProviderTel { get; set; }
        /// <summary>
        /// 出版社备注
        /// </summary>
        public string Memo { get; set; }
    }

    public class T_Base_Provider_Page
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 按钮最多存在个数(默认为5个
        /// </summary>
        private int maxbuttoncount = 5;

        public int maxButtonCount
        {
            get { return maxButtonCount = maxbuttoncount; }
            set { maxbuttoncount = value; }
        }

        /// <summary>
        /// 每页显示数
        /// </summary>
        private int pagesize = 5;

        public int pageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        /// <summary>
        /// 待加载的信息
        /// </summary>
        public List<Book.Model.T_Base_Provider> list { get; set; }

    }
}
