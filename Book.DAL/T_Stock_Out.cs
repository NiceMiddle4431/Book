using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Stock_Out
    {
        //查询全部
        public List<Book.Model.T_Stock_Out> GetAll()
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from V_InHead_Customer";
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book.Model.T_Stock_Out> list = new List<Model.T_Stock_Out>();
            while (reader.Read())
            {
                Book.Model.T_Stock_Out item = new Model.T_Stock_Out();
                Book.Model.T_Stock_OutHead head = new Model.T_Stock_OutHead();
                Book.Model.T_Base_Customer customer = new Model.T_Base_Customer();
                head.Id = Convert.ToInt32(reader["Id"]);
                head.UserName = Convert.ToString(reader["UserName"]);
                head.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                head.TotalMoney = Convert.ToDecimal(reader["TotalMoney"]);
                head.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                customer.Id = Convert.ToInt32(reader["CustomerId"]);
                customer.CustomerName = Convert.ToString(reader["CustomerName"]);
                customer.CustomerTel = Convert.ToString(reader["CustomerTel"]);
                customer.CustomerPwd = Convert.ToString(reader["CustomerPwd"]);
                customer.CustomerPostbox = Convert.ToString(reader["CustomerPostbox"]);
                head.Customer = customer;
                item.Head = head;
                item.Items = null;
                list.Add(item);
            }
            reader.Close();
            co.Close();
            return list;
        }

        //分页查询总记录数
        public int GetCount()
        {
            List<Book.Model.T_Stock_Out> list = new List<Model.T_Stock_Out>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from v_outhead_customer";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Stock_Out> GetList(int pageNumber, int pageSize)
        {
            List<Book.Model.T_Stock_Out> list = new List<Model.T_Stock_Out>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + pageSize + " * from v_outhead_customer where Id not in(select top " + (pageNumber - 1) * pageSize + " Id from v_outhead_customer)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Stock_Out item = new Model.T_Stock_Out();
                Book.Model.T_Stock_OutHead head = new Model.T_Stock_OutHead();
                Book.Model.T_Base_Customer customer = new Model.T_Base_Customer();
                head.Id = Convert.ToInt32(reader["Id"]);
                head.UserName = Convert.ToString(reader["UserName"]);
                head.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                head.TotalMoney = Convert.ToDecimal(reader["TotalMoney"]);
                head.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                customer.Id = Convert.ToInt32(reader["CustomerId"]);
                customer.CustomerName = Convert.ToString(reader["CustomerName"]);
                customer.CustomerTel = Convert.ToString(reader["CustomerTel"]);
                customer.CustomerPwd = Convert.ToString(reader["CustomerPwd"]);
                customer.CustomerPostbox = Convert.ToString(reader["CustomerPostbox"]);
                head.Customer = customer;
                item.Head = head;
                item.Items = null;
                list.Add(item);
            }
            reader.Close();
            co.Close();
            return list;
        }

        //子表数据查询
        public List<Book.Model.T_Stock_OutItems> GetModel(int headId)
        {
            List<Book.Model.T_Stock_OutItems> list = new List<Model.T_Stock_OutItems>();
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from v_outItem_book where HeadId = " + headId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Stock_OutItems item = new Model.T_Stock_OutItems();
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.id = Convert.ToInt32(reader["BookId"]);
                book.BookName = Convert.ToString(reader["BookName"]);
                book.Author = Convert.ToString(reader["Author"]);
                book.PressName = Convert.ToString(reader["PressName"]);
                book.ISBN = Convert.ToString(reader["ISBN"]);
                book.Price = Convert.ToDecimal(reader["Price"]);
                book.Version = Convert.ToInt32(reader["Version"]);
                item.Book = book;
                item.HeadId = headId;
                item.Discount = Convert.ToDecimal(reader["Discount"]);
                item.Amount = Convert.ToInt32(reader["Amount"]);
                list.Add(item);
            }
            co.Close();
            return list;
        }

        //删除
        public int Delete(string HeadIds)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from t_stock_outHead where "
                + "Id in (" + HeadIds + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public bool AddSave(Book.Model.T_Stock_Out outStock)
        {
            SqlConnection co = SQLServerOpen();

            SqlTransaction tran = co.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.Transaction = tran;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into t_stock_outhead (UserName,CreateTime,TotalMoney,CustomerId) "
                    + "values (@UserName,@CreateTime,@TotalMoney,@CustomerId);select @@identity";
                cmd.Parameters.AddWithValue("@UserName", outStock.Head.UserName);
                cmd.Parameters.AddWithValue("@CreateTime", outStock.Head.CreateTime);
                cmd.Parameters.AddWithValue("@CustomerId", outStock.Head.CustomerId);
                cmd.Parameters.AddWithValue("@TotalMoney", outStock.Head.TotalMoney);
                object result = cmd.ExecuteScalar();
                int headId = Convert.ToInt32(result);
                foreach (Book.Model.T_Stock_OutItems item in outStock.Items)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "insert into t_stock_outitems (HeadId,BookId,Amount,Discount) " +
                       "values (@HeadId,@BookId,@Amount,@Discount)";
                    cmd.Parameters.AddWithValue("@HeadId", headId);
                    cmd.Parameters.AddWithValue("@BookId", item.BookId);
                    cmd.Parameters.AddWithValue("@Amount", item.Amount);
                    cmd.Parameters.AddWithValue("@Discount", item.Discount);
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                co.Close();
            }
            return false;
        }

        //数据库连接
        private SqlConnection SQLServerOpen()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uId=book;pwd=book;" +
                            "database=Book";
            co.Open();
            return co;
        }
    }
}
