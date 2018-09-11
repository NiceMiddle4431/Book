using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Stock_Out
    {
        public List<Book.Model.T_Stock_Out> GetAll()
        {
            Book.DAL.T_Stock_Out dal = new DAL.T_Stock_Out();
            return dal.GetAll();
        }
        public List<Book.Model.T_Stock_Out> GetList(int pageNumber, int pageSize)
        {
            Book.DAL.T_Stock_Out dal = new DAL.T_Stock_Out();
            return dal.GetList(pageNumber, pageSize);
        }
        public int GetCount()
        {
            Book.DAL.T_Stock_Out dal = new DAL.T_Stock_Out();
            return dal.GetCount();
        }
        public List<Book.Model.T_Stock_OutItems> GetModel(int headId)
        {
            Book.DAL.T_Stock_Out dal = new Book.DAL.T_Stock_Out();
            List<Book.Model.T_Stock_OutItems> list = dal.GetModel(headId);
            return list;
        }

        public int Delete(string[] HeadIds)
        {
            //防止注入式漏洞
            string headIds = string.Join(",", HeadIds);
            Book.DAL.T_Stock_Out dal = new DAL.T_Stock_Out();
            return dal.Delete(headIds);
        }
        public bool AddSave(Book.Model.T_Stock_Out inStock)
        {
            decimal totalMoney = 0;
            foreach (Book.Model.T_Stock_OutItems item in inStock.Items)
            {
                totalMoney += item.Amount * item.Discount * item.Price;
            }
            inStock.Head.TotalMoney = totalMoney;
            DAL.T_Stock_Out dal = new DAL.T_Stock_Out();
            return dal.AddSave(inStock);
        }
    }
}
