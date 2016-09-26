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

namespace dag8opg4start
{
  public partial class MainWindow : Window
  {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = Service.Instance.Cars;
            listBox1.ItemTemplateSelector = new CarSelector();
        }


        double x = 1;
        double y = 1;
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            x += 0.25;
            y += 0.25;
            
            Transform scale = new ScaleTransform(x, y);
            //listBox1.RenderTransform = scale;
            //btnDown.RenderTransform = scale;
            //btnUp.RenderTransform = scale;

            stPnlMain.RenderTransform = scale;
            Application.Current.MainWindow.Height *= y;
            Application.Current.MainWindow.Width *= x;

        }


        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (x > 0) { 
                x -= 0.25;
                y -= 0.25;
            Transform scale = new ScaleTransform(x, y);
                //listBox1.RenderTransform = scale;
                //btnDown.RenderTransform = scale;
                //btnUp.RenderTransform = scale;
                //grid1.RenderTransform = scale;
                stPnlMain.RenderTransform = scale;
                Application.Current.MainWindow.Height *= y;
            Application.Current.MainWindow.Width *= x;
            }
        }
    }
}
