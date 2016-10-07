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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<object> ansatte
        {
            get
            {
                return getPersonsByCountry();
            }
        }

        public List<object> countries {
            get
            {
                return CountryList();
            }
        }

        public List<object> CountryList()
        {
            List<object> result = new List<object>();

                string connStr = @"Data Source=localhost\sqlExpress;"
                + "Integrated security=true; "
                + "database=Northwind";

            SqlConnection con = new SqlConnection(connStr);
                string sql = "SELECT DISTINCT c.Country FROM Customers c";
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
                Console.WriteLine(ex);
                Console.ReadLine();

            }
            finally
            {
                if (con.State==ConnectionState.Open) con.Close();
            }



                return result;
        }


        private List<object> getPersonsByCountry()
        {
            //object value = cbox_land.SelectedValue
            List<object> result = new List<object>();

            string connStr = @"Data Source=localhost\sqlExpress;"
                + "Integrated security=true; "
                + "database=Northwind";

            SqlConnection con = new SqlConnection(connStr);
            string sql = "SELECT c.Country FROM Customers c WHERE c.Country = " + cbox_land.SelectedValue;
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
                Console.WriteLine(ex);
                Console.ReadLine();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return result;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbox_land.ItemsSource = countries;
            cbox_land.SelectedValue = "Denmark";
            //lbox_ansatte.ItemsSource = ansatte;
            //tBlock_ansatte.Item
        }

        private void cbox_land_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lbox_ansatte.ItemsSource = ansatte;
        }
    }
}
