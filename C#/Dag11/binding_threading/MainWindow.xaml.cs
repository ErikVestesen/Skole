using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace binding_threading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBoxData pageData = new TextBoxData();
        MyListModel viewModel = new MyListModel();
        Thread infiniteThread = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainGrid.DataContext = pageData;

            listBox1.DataContext = viewModel;
            viewModel.AddNewItems(4);
        }

        private void BtnGUI_Click(object sender, RoutedEventArgs e)
        {
            pageData.Count(Thread.CurrentThread.ManagedThreadId);
        }

        private void BtnThread_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadCount));
            t.Start();
        }

        private void ThreadCount()
        {
            pageData.Count(Thread.CurrentThread.ManagedThreadId);
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            Thread t=new Thread(new ParameterizedThreadStart(viewModel.AddNewItems));
            t.Start(5);
        }

        private void btnContinously_Click(object sender, RoutedEventArgs e)
        {
            infiniteThread = new Thread(new ThreadStart(KeepAdding));
            infiniteThread.IsBackground = true;
            infiniteThread.Start();
        }

        private void KeepAdding()
        {
            while (true)
            {
                viewModel.AddNewItems(1);
                Thread.Sleep(100);
            }
        }

        private void btnStopContinously_Click(object sender, RoutedEventArgs e)
        {
            infiniteThread.Abort();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
