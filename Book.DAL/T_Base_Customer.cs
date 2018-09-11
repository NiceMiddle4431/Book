using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DAL
{
    public class T_Base_Customer
    {
        public List<Book.Model.T_Base_Customer> GetAll()
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from t_base_customer";
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book.Model.T_Base_Customer> list = new List<Model.T_Base_Customer>();
            while (reader.Read())
            {
                Book.Model.T_Base_Customer user = new Model.T_Base_Customer();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.CustomerName = Convert.ToString(reader["CustomerName"]);
                user.CustomerPwd = Convert.ToString(reader["CustomerPwd"]);
                user.CustomerPostbox = Convert.ToString(reader["CustomerPostbox"]);
                user.CustomerTel = Convert.ToString(reader["CustomerTel"]);
                list.Add(user);
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

            cmd.CommandText = "select count(1) from t_base_customer";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Base_Customer> GetList(int pageNumber, int pageSize)
        {
            List<Book.Model.T_Base_Customer> list = new List<Model.T_Base_Customer>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + pageSize + " * from t_base_Customer where Id not in(select top " + (pageNumber - 1) * pageSize + " Id from t_base_customer)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Base_Customer item = new Model.T_Base_Customer();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.CustomerName = Convert.ToString(reader["CustomerName"]);
                item.CustomerPwd = Convert.ToString(reader["CustomerPwd"]);
                item.CustomerPostbox = Convert.ToString(reader["CustomerPostbox"]);
                item.CustomerTel = Convert.ToString(reader["CustomerTel"]);
                
                list.Add(item);
            }
            reader.Close();
            co.Close();
            return list;
        }

        public int AddSave(Book.Model.T_Base_Customer user)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_customer values(@CustomerName,@CustomerPwd," +
               "@CustomerPostbox,@CustomerTel)";
            cmd.Parameters.AddWithValue("@CustomerName", user.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerPwd", user.CustomerPwd);
            cmd.Parameters.AddWithValue("@CustomerPostbox", user.CustomerPostbox);
            cmd.Parameters.AddWithValue("@CustomerTel", user.CustomerTel);
            
            int result = cmd.ExecuteNonQuery();

            cmd.Clone();
            co.Close();

            return result;
        }

        public int Delete(string Ids)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from t_base_customer where "
                + "Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public Model.T_Base_Customer Alter(int Id)
        {
            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select * from t_base_customer where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            Book.Model.T_Base_Customer user = new Model.T_Base_Customer();
            while (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                user.CustomerName = Convert.ToString(dr["CustomerName"]);
                user.CustomerPwd = Convert.ToString(dr["CustomerPwd"]);
                user.CustomerPostbox = Convert.ToString(dr["CustomerPostbox"]);
                user.CustomerTel = Convert.ToString(dr["CustomerTel"]);
                
            }
            dr.Close();
            co.Close();
            return user;
        }

        public void AlterSave(Model.T_Base_Customer alterCustomer)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update t_base_customer set CustomerName = @CustomerName," +
                "CustomerPwd = @CustomerPwd,CustomerPostbox = @CustomerPostbox,CustomerTel = @CustomerTel" + " where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", alterCustomer.Id);
            cmd.Parameters.AddWithValue("@CustomerName", alterCustomer.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerPwd", alterCustomer.CustomerPwd);
            cmd.Parameters.AddWithValue("@CustomerPostbox", alterCustomer.CustomerPostbox);
            cmd.Parameters.AddWithValue("@CustomerTel", alterCustomer.CustomerTel);
            cmd.ExecuteNonQuery();
            co.Close();
        }
        public List<Model.T_Base_Customer> GetSearch(string query, int mathCount)
        {
            List<Model.T_Base_Customer> list = new List<Model.T_Base_Customer>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select top " + mathCount + " * from t_base_customer where CustomerName like '%" + query + "%' or CustomerTel like '%" + query + "%' or CustomerPostbox like '%"+query+"%'";
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Model.T_Base_Customer user = new Model.T_Base_Customer();
                user.Id = Convert.ToInt32(read["Id"]);
                user.CustomerName = Convert.ToString(read["CustomerName"]);
                user.CustomerPwd = Convert.ToString(read["CustomerPwd"]);
                user.CustomerPostbox = Convert.ToString(read["CustomerPostbox"]);
                user.CustomerTel = Convert.ToString(read["CustomerTel"]);
                list.Add(user);
            }
            co.Close();
            return list;
        }

        private SqlConnection SQLServerOpen()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uid=book;pwd=book;" +
                "database=Book";
            co.Open();
            return co;
        }
    }
}
