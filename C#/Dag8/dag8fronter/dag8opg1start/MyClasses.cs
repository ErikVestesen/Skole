using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace dag8opg1start
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            { name = value;
                Notify("Name");
            }
        }

        double height;
        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                Notify("Height");
                Notify("BMI");

            }
        }

        int weight;



        public int Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                Notify("Weight");
                Notify("BMI");

            }
        }

        public double BMI
        {
            get { return weight / height / height; }
        }

        public override string ToString()
        {
            string s = String.Format("{0}, h={1}, w={2}: BMI={3:##.#}", name, height, weight, BMI);
            return s;
        }

    }

    class RectangleColorConverter : IValueConverter
    {
        public RectangleColorConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush result = null;
            if ((double)value < 18.5)
            {
                result = new SolidColorBrush(System.Windows.Media.Colors.LightYellow);
            }
            else if ((double)value < 25)
            {
                result = new SolidColorBrush(System.Windows.Media.Colors.LightGreen);
            }
            else if ((double)value < 30)
            {
                result = new SolidColorBrush(System.Windows.Media.Colors.LightYellow);
            }
            else { // BMI > 30 
                result = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class BMIConverter : IValueConverter
    {
        public BMIConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * 10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class HeightConverter : IValueConverter
    {
        public HeightConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / 100;
        }
    }


}
