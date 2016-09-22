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

namespace DataBinding_Light2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      List<Novel> novels = new List<Novel>();

      novels.Add(new Novel { Author = "Robert Goddard", Title = "Caugth in the light", Rating = 9, ISBN = "978-08-05-06155-0" });
      novels.Add(new Novel { Author = "Elsebeth Egholm", Title = "Selvrisiko", Rating = 5, ISBN = "978-87-03-00353-5" });
      novels.Add(new Novel { Author = "Lisa Marklund", Title = "Nobels testamente", Rating = 7, ISBN = "978-87-03-02238-3" });
      novels.Add(new Novel { Author = "Jo Nesbø", Title = "Snemanden", Rating = 9, ISBN = "978-87-7053-166-5" });

      ListBox1.ItemsSource = novels;
      ListBox1.SelectedValuePath = "ISBN";
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      ListBox1.DisplayMemberPath = "Author";
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
      ListBox1.DisplayMemberPath = "Title";
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
      ListBox1.DisplayMemberPath = "";
    }

    private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      lblValue.Content = ListBox1.SelectedValue;
    }
  }
}
