using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Book.Model;

namespace Book.DAL
{
    public class Home
    {
        
        public List<Book.Model.T_Base_Menu> GetList(int RoleId)
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from v_role_menu where roleId = "+RoleId;
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book.Model.T_Base_Menu> list = new List<Model.T_Base_Menu>();
            while (reader.Read())
            {
                Book.Model.T_Base_Menu menu = new Model.T_Base_Menu();
                menu.Id = Convert.ToInt32(reader["Id"]);
                menu.Controller = Convert.ToString(reader["Controller"]);
                menu.Action = Convert.ToString(reader["Action"]);
                menu.Display = Convert.ToString(reader["Display"]);
                menu.Type = Convert.ToInt32(reader["Type"]);
                menu.ParentId = Convert.ToInt32(reader["ParentId"]);

                list.Add(menu);
            }
            reader.Close();
            co.Close();
            return list;
        }

        public Book.Model.T_Base_User Check(string LoginName, string Password)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from t_base_user where loginName = '"+ LoginName + "' and password = '"+ Password+"'";
            SqlDataReader reader = cmd.ExecuteReader();
            Book.Model.T_Base_User user = new Model.T_Base_User();
            while (reader.Read())
            {
                user.LoginName = Convert.ToString(reader["LoginName"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.RoleId = Convert.ToInt32(reader["RoleId"]);
            }

            return user;
        }
        public List<Book.Model.T_Base_Menu> GetList(int RoleId, string Controller, string Action)
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from v_role_menu where roleId = " 
                + RoleId+ " and Controller = '"+ Controller + "' and Action='"
                + Action+"'";
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book.Model.T_Base_Menu> list = new List<Model.T_Base_Menu>();
            while (reader.Read())
            {
                Book.Model.T_Base_Menu menu = new Model.T_Base_Menu();
                menu.Id = Convert.ToInt32(reader["Id"]);
                menu.Controller = Convert.ToString(reader["Controller"]);
                menu.Action = Convert.ToString(reader["Action"]);
                menu.Display = Convert.ToString(reader["Display"]);
                menu.Type = Convert.ToInt32(reader["Type"]);
                menu.ParentId = Convert.ToInt32(reader["ParentId"]);
                list.Add(menu);
            }
            reader.Close();
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
