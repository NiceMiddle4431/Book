using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Stock_Report
    {
        //数据库连接
        private SqlConnection SQLServerOpen()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uId=book;pwd=book;" +
                           "database=Book";
            co.Open();
            return co;
        }
        //分页查询总记录数
        public int GetCount()
        {
            List<Book.Model.T_Stock_Report> list = new List<Model.T_Stock_Report>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from v_report_book";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }
        ///分页实现过程
        public List<Book.Model.T_Stock_Report> GetList(int pageNumber, int pageSize)
        {
            List<Book.Model.T_Stock_Report> list = new List<Model.T_Stock_Report>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + pageSize + " * from v_report_book where BookId not in(select top " + (pageNumber - 1) * pageSize + " BookId from v_report_book)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Stock_Report item = new Model.T_Stock_Report();
                item.BookId = Convert.ToInt32(reader["BookId"]);
                item.BookName = Convert.ToString(reader["BookName"]);
                item.Amount = Convert.ToInt32(reader["Amount"]);
                item.Img = Convert.ToString(reader["Img"]);
                list.Add(item);
            }
            reader.Close();
            co.Close();
            int result = GetCount();
            return list;
        }
    }
}
