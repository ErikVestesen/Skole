using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace binding_threading
{
    public class TextBoxData: INotifyPropertyChanged
    {
        int n = 0; int threadID=0;

        public string Value
        {
            get
            {
                return "Num " + n+" (from ThreadId="+threadID+")";
            }
        }

        public void Count(int threadID)
        {
            lock (this)
            {
                n++;
                this.threadID = threadID;
            }

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


    // class for Items in collection
    class Stock : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; NotifyPropertyChanged("Symbol"); }
        }

        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged("Value"); }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // modelklasse med collection af 
    class MyListModel
    {
        public ObservableCollection<Stock> Stocks { get; set; }

        private object _stocksLock = new object();

        public MyListModel()
        {
            Stocks = new ObservableCollection<Stock>();

//            BindingOperations.EnableCollectionSynchronization(Stocks, _stocksLock);

        }


        private Random _random = new Random();

        public void AddNewItems(object o)
        {
            int n = (int)o;

            for (int i = 0; i < n; i++)
            {
                var item = new Stock();
                for (int j = 0; j < _random.Next(2, 4); j++)
                {
                    item.Symbol += char.ConvertFromUtf32(_random.Next(
                        char.ConvertToUtf32("A", 0),
                        char.ConvertToUtf32("Z", 0)));
                }

                item.Value = (decimal)(_random.Next(100, 6000) / 100.0);
                Stocks.Add(item);
                Debug.WriteLine(item.Symbol);
            }
        }


    }
}
