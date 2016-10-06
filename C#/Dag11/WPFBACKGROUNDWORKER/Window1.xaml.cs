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
using System.ComponentModel;
using System.Diagnostics;

namespace WpfBackGroundWorker
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    private int prime;
    int lastPrime = 1;

    System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();

    public Window1()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      worker.DoWork += new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
      worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(worker_ProgressChanged);
      worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

      worker.WorkerSupportsCancellation = true;
      worker.WorkerReportsProgress = true;
    }

    private void btnStartWorker_Click(object sender, RoutedEventArgs e)
    {
      Trace("btnStartWorker_Click");
      lbxPrimes.Items.Clear();
      pgbPrimes.Value = 0;
      lblProgress.Content = "0";
      lblStatus.Content = "Worker Working";
      btnStartWorker.IsEnabled = false;
      btnCancelWorker.IsEnabled = true;

      Init init = new Init { Start = 4000000, Slut = 4003000 };
      worker.RunWorkerAsync(init);
    }

    private void btnCancelWorker_Click(object sender, RoutedEventArgs e)
    {
      Trace("btnCancelWorker_Click");

      worker.CancelAsync();
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        Trace("Form1_FormClosing");

        if (worker.WorkerSupportsCancellation)
        {
            worker.CancelAsync();
            if (worker != null && worker.IsBusy)
            {
                e.Cancel = true;
                Trace("Can't close, Worker is running");
            }
        }
    }

    public void Trace(string msg)
    {
      Debug.WriteLine("ThreadID: "+Thread.CurrentThread.ManagedThreadId+" msg="+msg);
    }

    private bool isPrime(int x)
    {
      int i = 2;
      bool divisorFound = false;
      while (!divisorFound && i < x)
      {
        if (x % i == 0)
          divisorFound = true;
        i++;
      }
      return !divisorFound;
    }

    public int GeneratePrimes(int lower, int upper)
    {
      Trace("GeneratePrimes");
      int candidate = lower;
      while (!worker.CancellationPending && candidate <= upper)
      {
        if (isPrime(candidate))
        {
          prime = candidate;
          lastPrime = candidate;

          int pct = (int)(100.0 * (candidate - lower) / (upper - lower) +0.5);
          worker.ReportProgress(pct,lastPrime);
        }
        candidate += 1;
      }
      // ReportProgress to reach 100%
      // worker.ReportProgress(100);
      return lastPrime;
    }

    // i denne metode er InvokeRequired på Formens Controls 
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      Trace("DoWork");
      Init init = (Init)e.Argument;
      int lastCandidate = GeneratePrimes(init.Start,init.Slut);
      e.Result = lastCandidate;
      if (worker.CancellationPending)
      {
        e.Cancel = true;
      }
    }

    // i denne metode kan Controls i Formen opdateres uden videre
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      int lastPrime = (int)e.UserState;
      Trace("ProgressChanged "+e.UserState);
      lbxPrimes.Items.Add(lastPrime);
      lblProgress.Content = e.ProgressPercentage + " %";
      pgbPrimes.Value = e.ProgressPercentage;
    }

    // i denne metode kan Controls i Formen opdateres uden videre
    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Trace("RunWorkerCompleted");
      btnStartWorker.IsEnabled = true;
      btnCancelWorker.IsEnabled = false;

      if (e.Cancelled)
        lblStatus.Content = "Worker Cancelled. Last prime: " + prime;
      else
        lblStatus.Content = "Worker Completed. Last prime: " + (int)e.Result;
    }


  }
}
