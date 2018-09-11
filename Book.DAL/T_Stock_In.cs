using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DAL
{
    public class T_Stock_In
    {
        //查询全部
        public List<Book.Model.T_Stock_In> GetAll()
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from V_InHead_Provider";
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book.Model.T_Stock_In> list = new List<Model.T_Stock_In>();
            while (reader.Read())
            {
                Book.Model.T_Stock_In item = new Model.T_Stock_In();
                Book.Model.T_Stock_InHead head = new Model.T_Stock_InHead();
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                head.Id = Convert.ToInt32(reader["Id"]);
                head.UserName = Convert.ToString(reader["UserName"]);
                head.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                head.TotalMoney = Convert.ToDecimal(reader["TotalMoney"]);
                head.ProviderId = Convert.ToInt32(reader["ProviderId"]);
                provider.Id = Convert.ToInt32(reader["ProviderId"]);
                provider.ProviderName = Convert.ToString(reader["ProviderName"]);
                provider.ProviderTel = Convert.ToString(reader["ProviderTel"]);
                provider.Memo = Convert.ToString(reader["Memo"]);
                head.Provider = provider;
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
            List<Book.Model.T_Stock_In> list = new List<Model.T_Stock_In>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from v_inhead_provider";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Stock_In> GetList(int pageNumber, int pageSize)
        {
            List<Book.Model.T_Stock_In> list = new List<Model.T_Stock_In>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + pageSize + " * from v_InHead_Provider where Id not in(select top " + (pageNumber - 1) * pageSize + " Id from v_InHead_Provider)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Stock_In item = new Model.T_Stock_In();
                Book.Model.T_Stock_InHead head = new Model.T_Stock_InHead();
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                head.Id = Convert.ToInt32(reader["Id"]);
                head.UserName = Convert.ToString(reader["UserName"]);
                head.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                head.TotalMoney = Convert.ToDecimal(reader["TotalMoney"]);
                head.ProviderId = Convert.ToInt32(reader["ProviderId"]);
                provider.Id = Convert.ToInt32(reader["ProviderId"]);
                provider.ProviderName = Convert.ToString(reader["ProviderName"]);
                provider.ProviderTel = Convert.ToString(reader["ProviderTel"]);
                provider.Memo = Convert.ToString(reader["Memo"]);
                head.Provider = provider;
                item.Head = head;
                item.Items = null;
                list.Add(item);
            }
            reader.Close();
            co.Close();
            int result = GetCount();
            return list;
        }

        //子表数据查询
        public List<Book.Model.T_Stock_InItems> GetModel(int headId)
        {
            List<Book.Model.T_Stock_InItems> list = new List<Model.T_Stock_InItems>();
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from V_InItem_Book where HeadId = "+ headId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Stock_InItems item = new Model.T_Stock_InItems();
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
            cmd.CommandText = "delete from t_stock_inHead where "
                +"Id in ("+HeadIds+")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public bool AddSave(Book.Model.T_Stock_In inStock)
        {
            SqlConnection co = SQLServerOpen();

            SqlTransaction tran = co.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.Transaction = tran;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into t_stock_inhead (UserName,CreateTime,TotalMoney,ProviderId) "
                    + "values (@UserName,@CreateTime,@TotalMoney,@ProviderId);select @@identity";
                cmd.Parameters.AddWithValue("@UserName", inStock.Head.UserName);
                cmd.Parameters.AddWithValue("@CreateTime", inStock.Head.CreateTime);
                cmd.Parameters.AddWithValue("@ProviderId", inStock.Head.ProviderId);
                cmd.Parameters.AddWithValue("@TotalMoney", inStock.Head.TotalMoney);
                object result = cmd.ExecuteScalar();
                int headId = Convert.ToInt32(result);
                foreach (Book.Model.T_Stock_InItems item in inStock.Items)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "insert into t_stock_initems (HeadId,BookId,Amount,Discount) " +
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
