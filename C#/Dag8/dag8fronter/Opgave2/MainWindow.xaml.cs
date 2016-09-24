using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Opgave2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Staff> members = new ObservableCollection<Staff>();
        ListCollectionView view = null;
        public MainWindow()
        {
            InitializeComponent();
            
            members.Add(new Staff("Arne Tolstrup Madsen", "atm", "atm.jpg"));
            members.Add(new Staff("Torben Krøjmand", "tk", "tk.jpg"));
            members.Add(new Staff("Karsten Rasmussen", "kr", "kr.jpg"));
            members.Add(new Staff("Hanne Sommer", "haso", "haso.jpg"));
            members.Add(new Staff("Gert Simonsen", "gs", "gs.jpg"));

            view = (ListCollectionView)CollectionViewSource.GetDefaultView(members);

            Staff p = (Staff)view.CurrentItem;
            updateinfo();
        }
        

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
            updateinfo();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
            updateinfo();
        }

        private void updateinfo()
        {
            Staff p = (Staff)view.CurrentItem;
            lbl.Content = p.Initials;
            tBox.Text = p.FullName;

            Binding iBinding = new Binding();
            iBinding.Source = view.CurrentItem;
            iBinding.Converter = new imageConverter();
            iBinding.Path = new PropertyPath("FileName");
            iBinding.Mode = BindingMode.TwoWay;
            img.SetBinding(Image.SourceProperty, iBinding);
        }
        
    }
}
