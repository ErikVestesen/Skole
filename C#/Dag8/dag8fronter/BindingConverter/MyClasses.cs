using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BindingConverter
{
    public class Car : INotifyPropertyChanged
    {
        string model;
        public string Model
        {
            get { return model; }
            set { 
                if (this.model == value)  return; 

                model = value;

                Notify("Model");
            }
        }

        int prodYear;
        public int ProdYear
        {
            get { return prodYear; }
            set
            { 
                if (this.prodYear == value) return;

                prodYear = value;
                Notify("ProdYear");
            }
        }

        bool isRegistered;
        public bool IsRegistered
        {
            get { return isRegistered; }
            set
            {
                if (this.isRegistered == value) return;

                isRegistered = value;
                Notify("IsRegistered");
            }
        }

        string regNr;
        public string RegNr
        {
            get { return regNr; }
            set
            {
                if (this.regNr == value) return;

                regNr = value;
                Notify("RegNr");
            }
        }

        public override string ToString()
        {
            return model + ", " + prodYear + ", " + isRegistered + ", " + regNr;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    class MyBoolToVisibleConverter : IValueConverter
    {
        public MyBoolToVisibleConverter() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (bValue)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class MyBoolToBackgroundConverter : IValueConverter
    {
        public MyBoolToBackgroundConverter() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (bValue)
                return Brushes.Black;
            else
                return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}
