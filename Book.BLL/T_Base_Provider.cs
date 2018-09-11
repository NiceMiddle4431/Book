using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Provider
    {
        public List<Book.Model.T_Base_Provider> GetList(int PageNumber, int PageSize)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> list = dal.GetList(PageNumber, PageSize);

            return list;
        }

        public int GetCount()
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            int result = dal.GetCount();
            return result;
        }

        public int AddSave(Book.Model.T_Base_Provider provider)
        {
            Book.DAL.T_Base_Provider providerAddSave = new DAL.T_Base_Provider();
            int result = providerAddSave.AddSave(provider);
            return result;
        }

        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.Delete(ids);
        }

        public Book.Model.T_Base_Provider Alter(int Id)
        {

            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.Alter(Id);
        }

        public void AlterSave(Model.T_Base_Provider provider)
        {
            Book.DAL.T_Base_Provider dll = new DAL.T_Base_Provider();
            dll.AlterSave(provider);
        }

        public List<Model.T_Base_Provider> GetSearch(string query, int mathCount)
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.GetSearch(query, mathCount);
        }
    }
}
