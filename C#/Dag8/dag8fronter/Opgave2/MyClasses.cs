using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Opgave2
{
    class Staff
    {
        string fullName;
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        string initials;
        public string Initials
        {
            get { return this.initials; }
            set { this.initials = value; }
        }

        string fileName;
        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        public Staff(string fullName, string initials, string fileName)
        {
            this.fullName = fullName;
            this.initials = initials;
            this.fileName = fileName;
        }

    }

    class imageConverter : IValueConverter
    {
        public imageConverter() { }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string location = @"C:\Users\Erik\Desktop\Skole\Skole\C#\Dag8\dag8fronter\Opgave2\eaa_images\"; //stationær
            //string location = @"C:\Users\User\Desktop\Erik\Skole\C#\Dag8\dag8fronter\Opgave2\eaa_images\"; //bærbar
            
            Uri uri = new Uri(location + (string)value);
            BitmapImage img = new BitmapImage(uri);

            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
