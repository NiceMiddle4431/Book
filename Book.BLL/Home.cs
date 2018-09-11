using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class Home
    {
        public List<Book.Model.T_Base_Menu> GetList(int RoleId)
        {
            Book.DAL.Home dal = new DAL.Home();
            return dal.GetList(RoleId);
        }
        public Book.Model.Home GetCount()
        {
            Book.Model.Home home = new Model.Home();
            Book.DAL.T_Base_Book book_dal = new DAL.T_Base_Book();
            home.BookCount = book_dal.GetCount();
            Book.DAL.T_Base_Provider provider_dal = new DAL.T_Base_Provider();
            home.ProviderCount = provider_dal.GetCount();
            Book.DAL.T_Base_Customer customer_dal= new DAL.T_Base_Customer();
            home.CustomerCount = customer_dal.GetCount();
            Book.DAL.T_Stock_In in_dal = new DAL.T_Stock_In();
            home.InHeadCount = in_dal.GetCount();
            Book.DAL.T_Stock_Out out_dal = new DAL.T_Stock_Out();
            home.OutHeadCount = in_dal.GetCount();
            return home;
        }

        public Book.Model.T_Base_User Check(string LoginName, string Password)
        {
            Book.DAL.Home dal = new DAL.Home();
            return dal.Check(LoginName, Password);
        }
        public List<Book.Model.T_Base_Menu> GetList(int RoleId,string Controller,string Action)
        {
            Book.DAL.Home dal = new DAL.Home();
            return dal.GetList(RoleId, Controller, Action);
        }
    }
}
