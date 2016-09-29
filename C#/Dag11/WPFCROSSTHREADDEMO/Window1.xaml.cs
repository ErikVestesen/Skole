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
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;

namespace WpfCrossThreadDemo
{
    delegate void TextBox1Delegate(object o);

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("GUI running on ThreadId=" + Thread.CurrentThread.ManagedThreadId);
        }

        private void Run(object o)
        {
            Debug.WriteLine("Run(" + o.ToString() + ") called from Thread=" + Thread.CurrentThread.ManagedThreadId);
            textBox1.Text += o.ToString() + Thread.CurrentThread.ManagedThreadId + " ";
        }

        // call from GUI-thread
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text+="GUI "+Thread.CurrentThread.ManagedThreadId+" ";
        }

        // illegal call from thread
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Run));
            t.Start("Illegal from Thread");
        }

        // correct call from thread
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new TextBox1Delegate(Run), DispatcherPriority.Normal, "Legal from thread");
        }



    }
}
