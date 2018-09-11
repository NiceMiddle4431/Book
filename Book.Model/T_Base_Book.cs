using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Book
    {
        /// <summary>
        /// id标示
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 书籍名称
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 书籍唯一ISBN码
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        public string PressName { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 书记价格及初始化
        /// </summary>
        private decimal price = 0;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Img { get; set; }
    }
}
