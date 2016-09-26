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
        ScaleTransform scale = new ScaleTransform(1, 1);
        public MainWindow()
        {
            InitializeComponent();
            stPnlMain.RenderTransform = scale;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = Service.Instance.Cars;
            listBox1.ItemTemplateSelector = new CarSelector();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if(scale.ScaleX < 1.5)
            scale = new ScaleTransform(scale.ScaleX*1.25, scale.ScaleY*1.25);
            stPnlMain.LayoutTransform = scale;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (scale.ScaleX > 0.5) {
                scale = new ScaleTransform(scale.ScaleX*0.8, scale.ScaleY*0.8);
                stPnlMain.LayoutTransform = scale;
            }
        }
    }
}
