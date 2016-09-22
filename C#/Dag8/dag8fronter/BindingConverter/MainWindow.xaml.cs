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

namespace BindingConverter
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

        Car car = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            car = new Car { Model = "VW Passat", ProdYear = 2010, IsRegistered = true, RegNr = "EH20345" };
            TopStackPanel.DataContext = car;

            Binding b = new Binding();
            b.Converter = new MyBoolToVisibleConverter();
            b.Mode = BindingMode.OneWay;
            b.Path = new PropertyPath("IsRegistered");

            tBoxRegNr.SetBinding(TextBox.VisibilityProperty, b);

            b = new Binding();
            b.Converter = new MyBoolToBackgroundConverter();
            b.Mode = BindingMode.OneWay;
            b.Path = new PropertyPath("IsRegistered");

            tBoxModel.SetBinding(TextBox.ForegroundProperty, b);

        }

        private void btnShowCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(car.ToString());
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            car.ProdYear++;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            car.ProdYear--;
        }

    }
}
