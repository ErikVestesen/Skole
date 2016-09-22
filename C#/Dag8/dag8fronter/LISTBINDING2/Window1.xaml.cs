using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;          // INotifyPropertyChanged
using System.Collections.ObjectModel; // ObserverableCollection<T>
using System.Collections;


namespace ListBinding2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();

        ListCollectionView view = null;

        public Window1()
        {
            InitializeComponent();

            this.btnBirthday.Click += btnBirthday_Click;
            this.btnPrevious.Click += btnPrevious_Click;
            this.btnNext.Click += btnNext_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnSort.Click += btnSort_Click;
            this.btnFilter.Click += btnFilter_Click;

            // initialse the Observable collection
            persons.Add(new Person { Name = "Tom", Age = 18 });
            persons.Add(new Person { Name = "John", Age = 21 });
            persons.Add(new Person { Name = "Melissa", Age = 34 });

            // get DefaultView for persons
            view = (ListCollectionView)CollectionViewSource.GetDefaultView(persons);
            lBoxPerson.ItemsSource = view;
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = persons;
        }

        void btnBirthday_Click(object sender, RoutedEventArgs e)
        {
            // get the currently selected Person
            Person person = (Person)view.CurrentItem;

            if (person != null)
            {
                person.Age++;
                MessageBox.Show(
                  string.Format("Happy Birthday, {0}, age {1}!", person.Name, person.Age), "Birthday");
            }
        }

        void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
        }

        void btnNext_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
        }

        void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            persons.Add(new Person("Chris", 37));
        }

        void btnSort_Click(object sender, RoutedEventArgs e)
        {
            // CustomSort is defines as: 
            // public IComparer CustomSort { get; set; }

            if (view.CustomSort == null)
            {
                view.CustomSort = new PersonSorter();
            }
            else
            {
                view.CustomSort = null;
            }
        }

        void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            // Filter is define as:
            // public virtual Predicate<Object> Filter { get; set; }

            if (view.Filter == null)
                view.Filter = item => (item as Person).Age >= 25;
            else
                view.Filter = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("" + lBoxPerson.SelectedIndex);
        }

    }

}
