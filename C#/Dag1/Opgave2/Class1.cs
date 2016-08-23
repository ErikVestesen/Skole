using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    class Person
    {
        string cpr;
        public string Cpr
        {
            get { return cpr; }
            set { cpr = value; }
        }
        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        int yearOfBirth;
        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }
    }
    class Service
    {
        public static ObservableCollection<Person> list = new ObservableCollection<Person>();
        static Service()
        {
            list.Add(new Person
            { Cpr = "12345", FirstName = "Bill", LastName = "Smith", YearOfBirth = 1980 });
            list.Add(new Person
            { Cpr = "23456", FirstName = "Chris", LastName = "Larsson", YearOfBirth = 1988 });
            list.Add(new Person
            { Cpr = "34567", FirstName = "Susan", LastName = "Ford", YearOfBirth = 1995 });
            list.Add(new Person
            { Cpr = "45678", FirstName = "Jane", LastName = "Doe", YearOfBirth = 1977 });
            list.Add(new Person
            { Cpr = "56789", FirstName = "Bill", LastName = "Doe", YearOfBirth = 1986 });
        }

    }
}
