using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Model;

namespace Book.BLL
{
    public class T_Base_Book
    {
        public List<Book.Model.T_Base_Book> GetAll()
        {
            Book.DAL.T_Base_Book book = new DAL.T_Base_Book();

            return book.GetAll();
        }

        public List<Book.Model.T_Base_Book> GetList(int PageNumber, int PageSize, string Query)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            List <Book.Model.T_Base_Book> list = dal.GetList(PageNumber, PageSize,Query);
            
            return list;
        }

        public int GetCount(string Query)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            int result = dal.GetCount(Query);
            return result;
        }

        public int AddSave(Book.Model.T_Base_Book book)
        {
            Book.DAL.T_Base_Book bookAddSave = new DAL.T_Base_Book();
            int result = bookAddSave.AddSave(book);
            return result;
        }

        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.Delete(ids);
        }

        public Book.Model.T_Base_Book Alter(int Id)
        {

            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.Alter(Id);
        }

        public void AlterSave(Model.T_Base_Book alterBook)
        {
            Book.DAL.T_Base_Book dll = new DAL.T_Base_Book();
            dll.AlterSave(alterBook);
        }

        public List<Model.T_Base_Book> GetSearch(string query, int mathCount)
        {
            DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.GetSearch(query, mathCount);
        }
    }
}
