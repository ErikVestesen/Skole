﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace Opgave3
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
            //Scan(@"C:\Users\Erik\Desktop");
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Scan(@"C:\Users\Erik\Desktop");
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string filename = (string)e.UserState;
            lBox.Items.Add(filename);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        public void Scan(string path) {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path,"*.txt");
            foreach (string dir in dirs)
            {
                Scan(dir);
                foreach(string file in files)
                {
                    worker.ReportProgress(0, file);
                }
            }
            

    }


        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
