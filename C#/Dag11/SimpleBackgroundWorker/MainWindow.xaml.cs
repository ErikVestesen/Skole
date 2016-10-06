using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SimpleBackgroundWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool completed=MyProcess((Data)e.Argument);
            e.Cancel = !completed;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int nr=e.ProgressPercentage;
            string nrStr = (string)e.UserState;
            lbl1.Content = ""+nr;
            lBox1.Items.Add(nr+": "+nrStr);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                lbl1.Content="Cancelled";
            else
                lbl1.Content="Normal stop";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lBox1.Items.Clear();

            Data data = new Data { Min = 1000000, Max = 9000000 };
            worker.RunWorkerAsync(data);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private bool MyProcess(Data data)
        {
            int nr=0;
            for (int n = data.Min; n <= data.Max; n++)
            {
                if (worker.CancellationPending)
                {
                    return false;
                }

                string s = "" + n;
                //test for palindrom
                bool ok = true;
                for(int i=0; i<s.Length; i++) // ineffektiv da der sammenlignes dobbelt!!!
                    if (s[i]!=s[s.Length-1-i])
                        ok=false;

                if (ok) {
                    nr++;
                    worker.ReportProgress(nr,s);
                }
            }

            return true;
        }
    }
}
