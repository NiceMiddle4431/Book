using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Book.Model;

namespace Book.DAL
{
    public class T_Base_Provider
    {
        public int GetCount()
        {
            List<Book.Model.T_Base_Provider> list = new List<Model.T_Base_Provider>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from t_base_provider";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Base_Provider> GetList(int PageNumber, int PageSize)
        {
            List<Book.Model.T_Base_Provider> list = new List<Model.T_Base_Provider>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;


            cmd.CommandText = "select top " + PageSize + " * from t_base_provider where Id not in(select top " + (PageNumber - 1) * PageSize + " Id from t_base_provider)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(reader["Id"]);
                provider.ProviderName = Convert.ToString(reader["ProviderName"]);
                provider.ProviderTel = Convert.ToString(reader["ProviderTel"]);
                provider.Memo = Convert.ToString(reader["Memo"]);
                list.Add(provider);
            }
            reader.Close();
            co.Close();
            return list;
        }

        public int AddSave(Book.Model.T_Base_Provider provider)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_provider values(@ProviderName,@ProviderTel,@Memo)";
            cmd.Parameters.AddWithValue("@ProviderName", provider.ProviderName);
            cmd.Parameters.AddWithValue("@ProviderTel", provider.ProviderTel);
            cmd.Parameters.AddWithValue("@Memo", provider.Memo);
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
            cmd.CommandText = "delete from t_base_provider where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public Model.T_Base_Provider Alter(int Id)
        {
            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select * from t_base_provider where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
            while (reader.Read())
            {
                provider.Id = Convert.ToInt32(reader["Id"]);
                provider.ProviderName = Convert.ToString(reader["ProviderName"]);
                provider.ProviderTel = Convert.ToString(reader["ProviderTel"]);
                provider.Memo = Convert.ToString(reader["Memo"]);
            }
            reader.Close();
            co.Close();
            return provider;
        }

        public void AlterSave(Model.T_Base_Provider provider)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update t_base_provider set ProviderName = @ProviderName," +
                "ProviderTel = @ProviderTel,Memo = @Memo where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", provider.Id);
            cmd.Parameters.AddWithValue("@ProviderName", provider.ProviderName);
            cmd.Parameters.AddWithValue("@ProviderTel", provider.ProviderTel);
            cmd.Parameters.AddWithValue("@Memo", provider.Memo);
            cmd.ExecuteNonQuery();
            co.Close();
        }

        public List<Model.T_Base_Provider> GetSearch(string query, int mathCount)
        {
            List<Model.T_Base_Provider> list = new List<Model.T_Base_Provider>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select top " + mathCount + " * from t_base_provider where ProviderName like '%" + query + "%' or ProviderTel like '%" + query + "%'";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(reader["Id"]);
                provider.ProviderName = Convert.ToString(reader["ProviderName"]);
                provider.ProviderTel = Convert.ToString(reader["ProviderTel"]);
                provider.Memo = Convert.ToString(reader["Memo"]);
                list.Add(provider);
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
