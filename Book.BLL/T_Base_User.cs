using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_User
    {
        public List<Book.Model.T_Base_User> GetList(int PageNumber, int PageSize)
        {
            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            List<Book.Model.T_Base_User> list = dal.GetList(PageNumber, PageSize);

            return list;
        }

        public int GetCount()
        {
            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            int result = dal.GetCount();
            return result;
        }

        public int AddSave(Book.Model.T_Base_User book)
        {
            Book.DAL.T_Base_User bookAddSave = new DAL.T_Base_User();
            int result = bookAddSave.AddSave(book);
            return result;
        }

        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            return dal.Delete(ids);
        }

        public Book.Model.T_Base_User Alter(int Id)
        {

            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            return dal.Alter(Id);
        }

        public void AlterSave(Model.T_Base_User alterBook)
        {
            Book.DAL.T_Base_User dll = new DAL.T_Base_User();
            dll.AlterSave(alterBook);
        }

        public List<Model.T_Base_User> GetSearch(string query, int mathCount)
        {
            DAL.T_Base_User dal = new DAL.T_Base_User();
            return dal.GetSearch(query, mathCount);
        }
    }
}
