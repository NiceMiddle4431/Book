using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Menu
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Display { get; set; }
        public int Type { get; set; }
        public int ParentId { get; set; }
    }
}
