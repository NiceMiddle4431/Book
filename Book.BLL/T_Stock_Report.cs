using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Stock_Report
    {
        public List<Book.Model.T_Stock_Report> GetList(int pageNumber, int pageSize)
        {
            Book.DAL.T_Stock_Report dal = new DAL.T_Stock_Report();
            return dal.GetList(pageNumber, pageSize);
        }
        public int GetCount()
        {
            Book.DAL.T_Stock_In dal = new DAL.T_Stock_In();
            return dal.GetCount();
        }
    }
}
