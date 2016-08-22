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

namespace Opgaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tal = -1;
        Random r = null;
        public MainWindow() {
            InitializeComponent();
            label2.Content = "Insert number";
            r = new Random();
            tal = r.Next(1, 101);
            textBox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if(textBox.Text != "") { 
                int a = Convert.ToInt32(textBox.Text);

                if (a > tal) {
                    label2.Content = "Too high!";
                } else if (a < tal) {
                    label2.Content = "Too low!";
                } else {
                    label2.Content = "Correct. Congratulation!";
                }
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e){
            
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text = " ";
            r = new Random();
            label2.Content = "Insert a number";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
            MessageBoxResult mr = MessageBox.Show("Do you want to stop guessing?",
             "Stopping?", MessageBoxButton.YesNo);
            if (mr == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
