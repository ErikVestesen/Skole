using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> list=null;

        // ObeservableCollection is defined in namespace: System.Collections.ObjectModel
        ObservableCollection<Person> obsList = null;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnAddBS_Click(object sender, RoutedEventArgs e)
        {
            Person bs = new Person { Name="Bjarne Stroustrup", BirthYear=1950 };

            list.Add(bs);
            obsList.Add(bs);

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // this is a dirty trick!!!!!
            listBox1.ItemsSource = null;
            listBox1.ItemsSource = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new List<Person>();

            // namespace: System.Collections.ObjectModel
            obsList = new ObservableCollection<Person>();

            Person p1 = new Person { Name = "Albert Einstein", BirthYear = 1879 };
            Person p2 = new Person { Name = "Niels Bohr", BirthYear = 1885 };
            Person p3 = new Person { Name = "Holger Bech Nielsen", BirthYear = 1941 };
            Person p4 = new Person { Name = "Lene Hau", BirthYear = 1959 };

            list.Add(p1); list.Add(p2); list.Add(p3); list.Add(p4);
            obsList.Add(p1); obsList.Add(p2); obsList.Add(p3); obsList.Add(p4);

            listBox1.ItemsSource = list;
            listBox2.ItemsSource = obsList;
        }
    }
}
