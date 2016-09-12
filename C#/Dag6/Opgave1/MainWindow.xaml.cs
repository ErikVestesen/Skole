using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            comboBox.ItemsSource = countries;
            InitializeComponent();
        }

        public List<string> countries {
            get
            {
                return CountryList();
            }
        }

        public List<string> CountryList()
        {
            List<string> result = new List<string>();

             
                string connStr = @"Data Source=localhost\sqlExpress;" + "Integrated security=true; " + "database=Northwind";
            SqlConnection con = new SqlConnection(connStr);
                string sql = "SELECT c.Country FROM Customers c";
                SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
            
                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                // handled exception 
            }
            finally
            {
                if (con.State==ConnectionState.Open) con.Close();
            }



                return result;
        }
    }
}
