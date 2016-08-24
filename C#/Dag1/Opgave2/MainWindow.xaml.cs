using System;
using System.Collections.Generic;
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

namespace Opgave2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            patter.ItemsSource = Service.list;
            patter.DisplayMemberPath = "Cpr";
        }

        private void patter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = (Person)patter.SelectedItem;
            tBoxFName.Text = p.FirstName;
            tBoxLName.Text = p.LastName;
            tBoxBirth.Text = Convert.ToString(p.YearOfBirth);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service.list.Add(new Person
            { Cpr = "56789", FirstName = "Bill", LastName = "Doe", YearOfBirth = 1986 });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Service.list.RemoveAt(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Service.list.RemoveAt(Service.list.Count-1);
        }
    }
}
