using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Arne", "Mikael", "Erik",
                "Margrethe", "Stine", "Jørn", "Morten",
                "Søren", "Hanne", "Gert", "Torben",
                "Karsten", "Anne Dorte", "Kaj" };

            Console.WriteLine("Starter med A:");
            string[] A = Array.FindAll(names,i => i.StartsWith("A"));
            Array.ForEach(A, x => Console.WriteLine(x)); Console.WriteLine();

            Console.WriteLine("Indeholder I:");
            string[] I = Array.FindAll(names, i => i.Contains("i") || i.Contains("I"));
            Array.ForEach(I, x => Console.WriteLine(x)); Console.WriteLine();
                         
            Console.ReadLine();

            //TOSTRING

            Person[] persons = {
                new Person { Name = "Bent", Age = 25 },
                new Person { Name = "Susan", Age = 34 },
                new Person { Name = "Mikael", Age = 60 },
                new Person { Name = "Klaus", Age = 44 },
                new Person { Name = "Birgitte", Age = 17 },
                new Person { Name = "Liselotte", Age = 9 }
            };

            Console.WriteLine("Under 30:");
            Person[] young = Array.FindAll(persons, i => i.Age < 31);
            Array.ForEach(young, x => Console.WriteLine(x)); Console.WriteLine();

            Console.WriteLine("Navne med længden 5:");
            Person[] names5 = Array.FindAll(persons, i => i.Name.Length == 5);
            Array.ForEach(names5, x => Console.WriteLine(x)); Console.WriteLine();

            Console.ReadLine();
        }
    }

    class Person {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Navn: " + Name + ", Alder: " + Age;
        }
    }
    
}
