using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MyClassLib
{
    public class Service
    {
        public static DataTable getCategories()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Categories";
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = dal.getConnection();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

            }
            catch (SqlException ex)
            {
               
            }
            return dt;
        }        public static int GetItemsSold(int i)
        {
            int result = 0;
            
            string sql = "SELECT UnitsOnOrder FROM Products WHERE ProductID = @id";
            SqlConnection con = dal.getConnection();
            SqlCommand da = new SqlCommand(sql, con);
            da.Parameters.AddWithValue("@id", i);
            con.Open();
            result = (int)da.ExecuteScalar();
            con.Close();
            return result;
        }        public static DataTable getProducts(int categoryID)
        {
            string sql = "";
            sql += "SELECT ProductName 'Navn på skidtet', CategoryName, UnitPrice 'Pris på skidtet',p.CategoryID PID FROM Products p JOIN Categories c ON c.CategoryID = p.CategoryID WHERE c.CategoryID = @categoryID";

            DataTable dt = new DataTable();
          
            SqlConnection con = dal.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("@categoryID", categoryID);

            da.Fill(dt);
                
            return dt;
        }
    }
}
