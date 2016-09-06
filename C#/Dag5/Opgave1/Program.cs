using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Opgave1
{
    class Person { public string Name { get; set; } public int Age { get; set; } }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name = "Bent", Age = 25 });
            persons.Add(new Person { Name = "Susan", Age = 34 });
            persons.Add(new Person { Name = "Mikael", Age = 60 });
            persons.Add(new Person { Name = "Klaus", Age = 44 });
            persons.Add(new Person { Name = "Birgitte", Age = 17 });
            persons.Add(new Person { Name = "Liselotte", Age = 9 });

            Console.WriteLine(persons[persons.FindIndex(i => i.Age == 44)].Name); // Klaus
            Console.WriteLine(persons[persons.FindIndex(i => i.Name.StartsWith("S"))].Name); //Susan
            Console.WriteLine(persons[persons.FindIndex(i => Regex.Matches(i.Name,"i").Count > 1)].Name); //Birgitte
            Console.WriteLine(persons[persons.FindIndex(i => i.Age == i.Name.Length)].Name); // Liselotte

            Console.ReadLine();
        }
    }
}
