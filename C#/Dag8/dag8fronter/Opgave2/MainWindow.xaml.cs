using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ObservableCollection<Staff> members = new ObservableCollection<Staff>();
            
            members.Add(new Staff("Arne Tolstrup Madsen", "atm",null));
            members.Add(new Staff("Torben Krøjmand", "tk", null));
            members.Add(new Staff("Karsten Rasmussen", "kr", null));
            members.Add(new Staff("Hanne Sommer", "haso", null));
            members.Add(new Staff("Gert Simonsen", "gs", null));
        }
    }
}
