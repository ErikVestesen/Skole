using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace subwindowmanager
{
    public delegate void CarSelectionChanged(string carId);
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public event CarSelectionChanged carSelectedChanged;

        public MainWindow()
    {
      InitializeComponent();

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      lBoxCars.ItemsSource = Service.Instance.CarList;
      lBoxCars.DisplayMemberPath = "Ident";
      lBoxCars.SelectedValuePath = "Id";
    }

    private void btnShowImage_Click(object sender, RoutedEventArgs e)
    {
      if (lBoxCars.SelectedItem != null)
      {
        WinCarImage win = new WinCarImage();
        win.Owner = this;

        string id = (string)lBoxCars.SelectedValue;
        win.setCarId(id);

        win.Show();
      }
      else
      {
        MessageBox.Show("No car selected");
      }
    }

    private void btnShowSpec_Click(object sender, RoutedEventArgs e)
    {
      if (lBoxCars.SelectedItem != null)
      {
        WinCarSpec win = new WinCarSpec();
        win.Owner = this;
        
        string id = (string)lBoxCars.SelectedValue;
        win.setCarId(id);

        win.Show();
      }
      else
      {
        MessageBox.Show("No car selected");
      }
    }

    private void btnClearSelection_Click(object sender, RoutedEventArgs e)
    {
      lBoxCars.SelectedItem = null;
    }

    private void lBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            //string id = (string)(sender as ListBox).SelectedValue;
            carSelectedChanged?.Invoke((string)(sender as ListBox).SelectedValue);
        }
    }
}
