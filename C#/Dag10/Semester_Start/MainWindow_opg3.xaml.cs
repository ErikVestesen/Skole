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
using Semester_classes;

namespace SemesterGUI
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

        List<Semester> semesterList = new List<Semester>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // generer semesterlisten
            for (int n = 7; n <= 20; n++)
            {
                string y2 = ("" + n).PadLeft(2, '0');

                semesterList.Add(new Semester("F" + y2, "Forårssemester 20" + y2));
                semesterList.Add(new Semester("E" + y2, "Efterårssemester 20" + y2));
            }

            // fill ComboBox with 'F10' til 'E20' 

            cBoxSemester.ItemsSource = semesterList;
            cBoxSemester.DisplayMemberPath = "Desc";
            cBoxSemester.SelectedValuePath = "Init";

            // calculate current semester for application
            DateTime now = DateTime.Now;

            string currentSemesterInit = null;

            int d = now.Day;
            int m = now.Month;
            int y = now.Year - 2000;

            if ((m - 1) * 30 + d > 45 && m < 10) currentSemesterInit = "E" + y;
            else
              if (m >= 10) currentSemesterInit = "F" + (y + 1);
            else currentSemesterInit = "F" + y;

            if (currentSemesterInit.Length == 2)
                currentSemesterInit = currentSemesterInit.Insert(1, "0");

            // select current semester i ComboBox
            cBoxSemester.SelectedValue = currentSemesterInit;

        }

    }
}
