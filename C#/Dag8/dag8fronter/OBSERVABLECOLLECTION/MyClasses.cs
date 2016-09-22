using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfObservableCollection
{
    public class Person : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                else
                {
                    name = value;

                    Notify("Name");
                }
            }
        }

        int birthYear;

        public int BirthYear
        {
            get { return birthYear; }
            set
            {
                if (birthYear == value)
                    return;
                else
                {
                    birthYear = value;

                    Notify("BirthYear");
                }
            }
        }


    }

}
