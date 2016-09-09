using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave7
{
    class Program
    {
        static void Main(string[] args)
        {
            // a
            Console.WriteLine("LONDON: ");
            var query = from kunde in CreateCustomers()
                        where kunde.City == "London"
                        orderby kunde.CustomerID
                        select kunde;

            foreach(Customer k in query) {
                Console.WriteLine(k);
            } Console.WriteLine();


            //b
            Console.WriteLine("NOT LONDON: ");
            var query1 = from kunde in CreateCustomers()
                        where kunde.City != "London"
                        orderby kunde.CustomerID
                        select kunde.CustomerID;

            foreach (var k in query1)
            {
                Console.WriteLine(k);
            }
            Console.ReadLine();
        }


        static IEnumerable<Customer> CreateCustomers() {
            return new List<Customer> {
            new Customer { CustomerID = "ALFKI", City = "Berlin" },
            new Customer { CustomerID = "BONAP", City = "Marseille" },
            new Customer { CustomerID = "CONSH", City = "London" },
            new Customer { CustomerID = "EASTC", City = "London" },
            new Customer { CustomerID = "FRANS", City = "Torino" },
            new Customer { CustomerID = "LONEP", City = "Portland" },
            new Customer { CustomerID = "NORTS", City = "London" },
            new Customer { CustomerID = "THEBI", City = "Portland" }
            };
        }

        public class Customer
        {
            public string CustomerID { get; set; }
            public string City { get; set; }
            public override string ToString()
            {
                return CustomerID + "\t" + City;
            }
        }
    }
}

   
    
