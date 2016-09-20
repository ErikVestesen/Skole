using MyClassLib;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Opgave1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!dal.CheckConnection())
            {
                MessageBox.Show("Forbindelse til database eksisterer ikke.\nProgrammet kan ikke fortsætte.");
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable kategorier = Service.getCategories();
            cBox_Categories.ItemsSource = kategorier.DefaultView;
            cBox_Categories.DisplayMemberPath = "CategoryName";
            cBox_Categories.SelectedValuePath = "CategoryID";
            cBox_Categories.SelectedIndex = 0;
            lbl_number.Visibility = System.Windows.Visibility.Hidden;
            lbl_købt.Visibility = System.Windows.Visibility.Hidden;
        }
        
        private void cBox_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int supplId = (int)cBox_Categories.SelectedValue;

            DataTable products = Service.getProducts(supplId);
          
            dataGrid.ItemsSource = products.DefaultView;
            dataGrid.AutoGenerateColumns = true;
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dataGrid.SelectedValue != null) { 
            int id = (int)dataGrid.SelectedIndex;

            int sold = Service.GetItemsSold(id);
        //        int sold = 1;
            lbl_number.Content = sold;
            lbl_købt.Visibility = System.Windows.Visibility.Visible;
                lbl_number.Visibility = System.Windows.Visibility.Visible;
            } else {
                lbl_number.Visibility = System.Windows.Visibility.Hidden;
                lbl_købt.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
