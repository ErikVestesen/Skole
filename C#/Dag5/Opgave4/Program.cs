using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4
{
    public class Book {
        public string Author { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public override string ToString()
        {
            return "Navn: " + Name + ", Published: " +Published.Year;
        }

        public void WhenPublished(Predicate<Book> bog, List<Book> bøger) {
            foreach(Book b in bøger) {
                if(bog(b)){
                    Console.WriteLine(b);
                }
            }
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book> {
                new Book { Author="McConnell",Name="Code Complete",
                    Published =new DateTime(1993,05,14) },
                new Book { Author="Sussman",Name="SICP (2nd)",
                    Published =new DateTime(1996,06,01) },
                new Book { Author="Hunt",Name="Pragmatic Programmer",
                    Published =new DateTime(1999,10,30) }
            };
            var after1995 = books.FindAll(i => i.Published.Year > 1995);
            var between1991and1997 = books.FindAll(i => i.Published.Year > 1990 && i.Published.Year < 1998);

            Console.WriteLine("After 1995:");
            after1995.ForEach(i => Console.WriteLine(i)); Console.WriteLine();
            Console.WriteLine("Between 1991 and 1997:");
            between1991and1997.ForEach(i => Console.WriteLine(i)); Console.WriteLine();
            Console.ReadLine();
        }
    }
}
 