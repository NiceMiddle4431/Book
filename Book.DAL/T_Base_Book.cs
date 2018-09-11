using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Book.Model;

namespace Book.DAL
{
    public class T_Base_Book
    {
        public List<Book.Model.T_Base_Book> GetAll()
        {

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from t_base_book";
            SqlDataReader dr = cmd.ExecuteReader();

            List<Book.Model.T_Base_Book> list = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.ISBN = Convert.ToString(dr["ISBN"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                list.Add(book);
            }
            dr.Close();
            co.Close();
            return list;
        }
        //分页查询总记录数
        public int GetCount(string Query)
        {
            List<Book.Model.T_Base_Book> list = new List<Model.T_Base_Book>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from t_base_book where BookName like '%" + Query + "%' or Author like '%" + Query + "%' or ISBN like '%" + Query + "%'";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return (int)result;
        }
        public int GetCount() { 
            List<Book.Model.T_Base_Book> list = new List<Model.T_Base_Book>();

            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select count(1) from t_base_book";
            Object result = cmd.ExecuteScalar();
            co.Close();
            return(int)result;
        }

        ///分页实现过程
        public List<Book.Model.T_Base_Book> GetList(int PageNumber, int PageSize, string Query)
        {
            List<Book.Model.T_Base_Book> list = new List<Model.T_Base_Book>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            

            cmd.CommandText = "select top " + PageSize + " * from t_base_book where Id not in(select top " + (PageNumber - 1) * PageSize + " Id from t_base_book "+
                "where BookName like '%"+Query+"%' or Author like '%"+Query+"%' or ISBN like '%"+Query+ "%') and (BookName like '%"+Query+"%' or Author like '%"+Query+"%' or ISBN like '%"+Query+"%')";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.id = Convert.ToInt32(reader["Id"]);
                book.BookName = Convert.ToString(reader["BookName"]);
                book.Author = Convert.ToString(reader["Author"]);
                book.ISBN = Convert.ToString(reader["ISBN"]);
                book.PressName = Convert.ToString(reader["PressName"]);
                book.Version = Convert.ToInt32(reader["Version"]);
                book.Price = Convert.ToDecimal(reader["Price"]);
                book.Img = Convert.ToString(reader["Img"]);
                list.Add(book);
            }
            reader.Close();
            co.Close();
            return list;
        }

        public int AddSave(Book.Model.T_Base_Book book)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_book values(@BookName,@Author," +
               "@ISBN,@PressName,@Version,@Price,@Img)";
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@PressName", book.PressName);
            cmd.Parameters.AddWithValue("@Version", book.Version);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Img", book.Img);
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
            cmd.CommandText = "delete from t_base_book where "
                + "Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public Model.T_Base_Book Alter(int Id)
        {
            SqlConnection co = SQLServerOpen();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;

            cmd.CommandText = "select * from t_base_book where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            while (dr.Read())
            {
                book.id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.ISBN = Convert.ToString(dr["ISBN"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
            }
            dr.Close();
            co.Close();
            return book;
        }

        public void AlterSave(Model.T_Base_Book book)
        {
            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update t_base_book set BookName = @BookName," +
                "Author = @Author,ISBN = @ISBN,PressName = @PressName," +
                "Price = @Price,Img=@Img" + " where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", book.id);
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@PressName", book.PressName);
            cmd.Parameters.AddWithValue("@Version", book.Version);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Img", book.Img);
            cmd.ExecuteNonQuery();
            co.Close();
        }

        public List<Model.T_Base_Book> GetSearch(string query, int mathCount)
        {
            List<Model.T_Base_Book> list = new List<Model.T_Base_Book>();

            SqlConnection co = SQLServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select top " + mathCount + " * from t_base_book where BookName like '%" 
                + query + "%' or ISBN like '%"+ query + "%' or Author like '%" + query + "%'";
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Model.T_Base_Book book = new Model.T_Base_Book();
                book.id = Convert.ToInt32(read["Id"]);
                book.BookName = Convert.ToString(read["BookName"]);
                book.Author = Convert.ToString(read["Author"]);
                book.ISBN = Convert.ToString(read["ISBN"]);
                book.PressName = Convert.ToString(read["PressName"]);
                book.Version = Convert.ToInt32(read["Version"]);
                book.Price = Convert.ToDecimal(read["Price"]);
                book.Img = Convert.ToString(read["Img"]);
                list.Add(book);
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
