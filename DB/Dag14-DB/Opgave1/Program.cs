using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dag14Entities db = new Dag14Entities();

            //-------Insert
            //person p = new person();
            //p.cpr = "1234567890";
            //p.navn = "jørgen";
            //p.stilling = "Stolt faktamedarbejder";
            //p.loen = 100;
            //p.postnr = "8000";

            //db.people.Add(p);
            //db.SaveChanges();

            //-------Delete
            //db.people.Remove((
            //        from x in db.people
            //        where x.cpr == "1234567890"
            //        select x).First());
            //db.SaveChanges();

            //-------Update
            //Console.WriteLine("Indtast cpr");
            //string input = Console.ReadLine();
            //person pe = (from y in db.people
            //             where y.cpr == input
            //             select y).FirstOrDefault();
            //if (pe != null)
            //{
            //    pe.loen = 123456;
            //    Console.WriteLine("Løn ændret");
            //    Console.ReadLine();
            //    db.SaveChanges();
            //} else  {
            //    Console.WriteLine("Person ikke fundet");
            //    Console.ReadLine();
            //}

            //-------Writeline for all persons
            //foreach(person k in from z in db.people select z) {
            //    Console.WriteLine(k.navn + ", " + k.cpr);
            //}
            //Console.ReadLine();


            //-------Sql
            // ??
            //var r =
            //    from q in db.people
            //    from w in db.postnummers
            //    where q.postnr == w.postnr
            //    select new { q.cpr, q.navn, w.postdistrikt };
            //foreach (var g in r)
            //{
            //    Console.WriteLine(g);
            //}
            //Console.ReadLine();


            //-------link attributes
            printPersons(db);

            //----------14.2
            //-- de finder løn der er over 350k, jeg ka ikk li nr 2 fordi den bruger if istedet for where

            //----------14.3
            //--metode 1
            //Console.WriteLine("Indtast cpr"); // 1212121212
            //string input1 = Console.ReadLine();
            //Console.WriteLine("Indtast postdistrikt"); //Egå
            //string input2 = Console.ReadLine();
            //person p1 = findPerson(db, input1);
            //if(p1 != null) {
            //    postnummer pn1 = (from k in db.postnummers
            //                      where k.postdistrikt == input2
            //                      select k).FirstOrDefault();
            //    if (pn1 != null) {
            //        p1.postnr = pn1.postnr;
            //        Console.WriteLine("Postdistrikt ændret");
            //        db.SaveChanges();
            //    } else {
            //        Console.WriteLine("Postdistrikt ikke fundet");
            //    }
            //} else {
            //    Console.WriteLine("Person ikke fundet");
            //}
            //Console.ReadLine();
            string inputCpr = "asd";
            string inputPostNr = "";
            person p2 = (from p in db.people where p.cpr == inputCpr select p).First();
                p2.postnr = inputPostNr;
            //printPersons(db);

            //--metode 2
            Console.WriteLine("Indtast cpr"); // 1212121212
            string input1 = Console.ReadLine();
            Console.WriteLine("Indtast postdistrikt"); //Egå
            string input2 = Console.ReadLine();
            
                postnummer pn1 = (from k in db.postnummers
                                  where k.postdistrikt == input2
                                  select k).FirstOrDefault();
                if (pn1 != null) {
                    person p1 = findPerson(db, input1);
                    if (p1 != null) {
                        p1.postnr = pn1.postnr;
                        Console.WriteLine("Postdistrikt ændret");
                        db.SaveChanges();
                    } else {
                        Console.WriteLine("Person ikke fundet");
                    }
                } else {
                    Console.WriteLine("Postdistrikt ikke fundet");
                }
            
            Console.ReadLine();

            printPersons(db);

        }

        /*
         *metode 1
         *Find person
         * find postnummer
         *  sæt persons postnummer
         * 
         *metode 2
         *Find postnummer
         * find person
         *  sæt persons postnummer
         *  
         *   
         * 
         */

        private static person findPerson(Dag14Entities db, string input)
        {
            person p = (from p1 in db.people
                         where p1.cpr == input
                         select p1).FirstOrDefault();
            return p;
        }

        private static void printPersons(Dag14Entities db) {
            var asd =
                from h in db.people
                select new { h.cpr, h.navn, h.postnummer.postdistrikt };

            foreach (var g in asd)
            {
                Console.WriteLine(g);
            }
            Console.ReadLine();
        }
    }
}
