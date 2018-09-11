using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Base_User
    {
        public int GetCount()
        {
            List<Book.Model.T_Base_User> list = new List<Model.T_Base_User>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from t_base_user";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Base_User> GetList(int PageNumber, int PageSize)
        {
            List<Book.Model.T_Base_User> list = new List<Model.T_Base_User>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + PageSize + " * from t_base_user where Id not in(select top " + (PageNumber - 1) * PageSize + " Id from t_base_user)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Base_User user = new Model.T_Base_User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.LoginName = Convert.ToString(reader["LoginName"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.RoleId = Convert.ToInt32(reader["RoleId"]);
                list.Add(user);
            }
            reader.Close();
            co.Close();
            return list;
        }

        public int AddSave(Book.Model.T_Base_User user)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_user values(@LoginName,@PassWord,@RoleId)";
            cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
            cmd.Parameters.AddWithValue("@PassWord", user.PassWord);
            cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
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
            cmd.CommandText = "delete from t_base_user where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public Model.T_Base_User Alter(int Id)
        {
            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select * from t_base_user where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            Book.Model.T_Base_User user = new Model.T_Base_User();
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.LoginName = Convert.ToString(reader["LoginName"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.RoleId = Convert.ToInt32(reader["RoleId"]);
            }
            reader.Close();
            co.Close();
            return user;
        }

        public void AlterSave(Model.T_Base_User user)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update t_base_user set LoginName = @LoginName," +
                "PassWord = @PassWord,RoleId = @RoleId where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
            cmd.Parameters.AddWithValue("@PassWord", user.PassWord);
            cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
            cmd.ExecuteNonQuery();
            co.Close();
        }

        public List<Model.T_Base_User> GetSearch(string query, int mathCount)
        {
            List<Model.T_Base_User> list = new List<Model.T_Base_User>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select top " + mathCount + " * from t_base_user where LoginName like '%" + query + "%' or RoleId like '%" + query + "%'";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Model.T_Base_User user = new Model.T_Base_User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.LoginName = Convert.ToString(reader["LoginName"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.RoleId = Convert.ToInt32(reader["RoleId"]);
                list.Add(user);
            }
            co.Close();
            return list;
        }

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
