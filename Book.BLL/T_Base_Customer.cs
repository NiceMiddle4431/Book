using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Customer
    {
        public List<Book.Model.T_Base_Customer> GetAll()
        {
            Book.DAL.T_Base_Customer user = new DAL.T_Base_Customer();

            return user.GetAll();
        }

        public List<Book.Model.T_Base_Customer> GetList(int pageSize, int pageNumber)
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            List<Book.Model.T_Base_Customer> list = dal.GetList(pageSize, pageNumber);
            return list;
        }
        public int GetCount()
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.GetCount();
        }
        public int AddSave(Book.Model.T_Base_Customer user)
        {
            Book.DAL.T_Base_Customer userAddSave = new DAL.T_Base_Customer();
            int result = userAddSave.AddSave(user);
            return result;
        }



        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.Delete(ids);
        }


        public Book.Model.T_Base_Customer Alter(int Id)
        {

            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.Alter(Id);
        }

        public void AlterSave(Model.T_Base_Customer alterBook)
        {
            Book.DAL.T_Base_Customer dll = new DAL.T_Base_Customer();
            dll.AlterSave(alterBook);
        }

        public List<Model.T_Base_Customer> GetSearch(string query, int mathCount)
        {
            DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.GetSearch(query, mathCount);
        }
    }
}
