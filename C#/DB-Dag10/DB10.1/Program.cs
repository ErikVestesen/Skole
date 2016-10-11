using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB10._1
{ 
    //Snapshot fejlkode: 3960
    class Program
    {
        static void Main(string[] args)
        {
            //E1();
            //E2();
            //E3();
            E4();
            //E5();
        }



        //Standard
        private static void E1()
        {
            string connStr = @"Data Source=localhost\sqlExpress;"
            + "Integrated security=true; "
            + "database=Dag10";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
                DoStuff(con);
            con.Close();
            E1();
        }

        //Transaktioner og traditionel pessimistisk låsning
        private static void E2()
        {
            string connStr = @"Data Source=localhost\sqlExpress;"
             + "Integrated security=true; "
             + "database=Dag10";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
                SqlTransaction tran = con.BeginTransaction();

                DoStuffTran(con, tran);

                tran.Commit();
            con.Close();
            E2();
        }
        
        //Transaktioner og traditionel pessimistisk låsning && deadlock by converion forhindres
        private static void E3()
        {
            string connStr = @"Data Source=localhost\sqlExpress;"
               + "Integrated security=true; "
               + "database=Dag10";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlTransaction tran = con.BeginTransaction(IsolationLevel.RepeatableRead);

            DoStuffTran(con, tran);

            tran.Commit();
            con.Close();
            E3();
        }

        //Transaktioner og optimistisk låsning
        private static void E4()
        {
            string connStr = @"Data Source=localhost\sqlExpress;"
               + "Integrated security=true; "
               + "database=Dag10";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();


            Console.WriteLine("Skriv CPR");
            string input = Console.ReadLine();
            string start = e4get(con, input);

            SqlTransaction tran = con.BeginTransaction(IsolationLevel.Snapshot);
            //begin tran
            string res = e4get(con, input);
            if (res == start)
                    {
                        Console.WriteLine("Skriv løn");
                        string loen = Console.ReadLine();
                        if (loen.Count() > 0)
                            sqlUpdateTran(loen, input, con, tran);
                        tran.Commit();
                    }
                    else
                    {
                        Console.WriteLine("DATA ER ÆNDRET, SUT PIK MAND");
                        tran.Rollback();
                    }
                    Console.ReadLine();
            con.Close();
            E4();
        }

        //Transaktioner og isolation level snapshot
        private static void E5()
        {

        }



        //----- Not Tran, kun til E1
        private static void sqlGet(string input, SqlConnection con)
        {
            string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@input", input);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
                Console.WriteLine(line);
            }
            reader.Close();
        }

        private static void sqlUpdate(string loen, string cpr, SqlConnection con)
        {
            string sql1 = "UPDATE person SET loen += " + @loen + " WHERE cpr = " + @cpr;
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue(@cpr, cpr);
            cmd1.Parameters.AddWithValue(@loen, loen);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Løn ændret");
            Console.ReadLine();
        }

        private static void DoStuff(SqlConnection con)
        {

            //---- Finder person
            Console.WriteLine("Skriv CPR");
            string cpr = Console.ReadLine();
            sqlGet(cpr, con);

            //---- Opdaterer Løn
            Console.WriteLine("Skriv løn");
            string loen = Console.ReadLine();
            sqlUpdate(loen, cpr, con);
        }


        //----- TRAN
        private static void DoStuffTran(SqlConnection con, SqlTransaction tran)
        {

            //---- Finder person
            Console.WriteLine("Skriv CPR");
            string cpr = Console.ReadLine();
            if (cpr.Count() > 0)
                sqlGetTran(cpr, con, tran);

            //---- Opdaterer Løn
            Console.WriteLine("Skriv løn");
            string loen = Console.ReadLine();
            if (loen.Count() > 0)
                sqlUpdateTran(loen, cpr, con, tran);
        }

        private static void sqlGetTran(string input, SqlConnection con, SqlTransaction tran)
        {
            string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Transaction = tran;
            cmd.Parameters.AddWithValue("@input", input);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
                Console.WriteLine(line);
            }
            reader.Close();

        }

        private static void sqlUpdateTran(string loen, string cpr, SqlConnection con, SqlTransaction tran)
        {
            string sql1 = "UPDATE person SET loen = " + @loen + " WHERE cpr = " + @cpr;
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Transaction = tran;
            cmd1.Parameters.AddWithValue(@cpr, cpr);
            cmd1.Parameters.AddWithValue(@loen, loen);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Løn ændret");
            Console.ReadLine();
        }
        
        private static string e4get(SqlConnection con, string input)
        {
            string res = "";
            if (input.Count() > 0)
            {
                //-- Get Start
                string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " +input;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
                    Console.WriteLine(line);
                    res = line;
                }
                reader.Close();
            }
            return res;
        }

        //----------OLD
        //private static void E1()
        //{
        //    string connStr = @"Data Source=localhost\sqlExpress;"
        //    + "Integrated security=true; "
        //    + "database=Dag10";


        //    SqlConnection con = new SqlConnection(connStr);
        //    //------- Finder Person
        //    Console.WriteLine("Skriv CPR");
        //    string input = Console.ReadLine();
        //    string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@input", input);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
        //        Console.WriteLine(line);

        //    }
        //    reader.Close();
        //    //------

        //    //------ Opdaterer Løn
        //    Console.WriteLine("Skriv løn");
        //    string input1 = Console.ReadLine();
        //    string sql1 = "UPDATE person SET loen += " + @input1 + " WHERE cpr = " + @input;
        //    SqlCommand cmd1 = new SqlCommand(sql1, con);
        //    cmd1.Parameters.AddWithValue(@input, input);
        //    cmd1.Parameters.AddWithValue(@input1, input1);
        //    cmd1.ExecuteNonQuery();
        //    Console.WriteLine("Løn ændret");
        //    Console.ReadLine();
        //    //------

        //    con.Close();
        //    E1();
        //}

        //Transaktioner og traditionel pessimistisk låsning

        //private static void E2()
        //{
        //    string connStr = @"Data Source=localhost\sqlExpress;"
        //    + "Integrated security=true; "
        //    + "database=Dag10";


        //    SqlConnection con = new SqlConnection(connStr);
        //    con.Open();
        //    //------- Finder Person
        //    Console.WriteLine("Skriv CPR");
        //    string input = Console.ReadLine();
        //    string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@input", input);

        //    SqlTransaction tran = con.BeginTransaction();
        //    cmd.Transaction = tran;
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
        //        Console.WriteLine(line);

        //    }
        //    reader.Close();
        //    //------

        //    //------ Opdaterer Løn
        //    Console.WriteLine("Skriv løn");
        //    string input1 = Console.ReadLine();
        //    string sql1 = "UPDATE person SET loen += " + @input1 + " WHERE cpr = " + @input;
        //    SqlCommand cmd1 = new SqlCommand(sql1, con);
        //    cmd1.Parameters.AddWithValue(@input, input);
        //    cmd1.Parameters.AddWithValue(@input1, input1);
        //    cmd1.Transaction = tran;
        //    cmd1.ExecuteNonQuery();
        //    tran.Commit();
        //    Console.WriteLine("Løn ændret");
        //    Console.ReadLine();

        //    //------

        //    con.Close();
        //    E2();
        //}

        ////Transaktioner og traditionel pessimistisk låsning && deadlock by converion forhindres
        //private static void E3()
        //{
        //    string connStr = @"Data Source=localhost\sqlExpress;"
        //     + "Integrated security=true; "
        //     + "database=Dag10";


        //    SqlConnection con = new SqlConnection(connStr);
        //    con.Open();
        //    //------- Finder Person
        //    Console.WriteLine("Skriv CPR");
        //    string input = Console.ReadLine();
        //    string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@input", input);

        //    SqlTransaction tran = con.BeginTransaction(IsolationLevel.RepeatableRead);
        //    cmd.Transaction = tran;
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
        //        Console.WriteLine(line);

        //    }
        //    reader.Close();
        //    //------

        //    //------ Opdaterer Løn
        //    Console.WriteLine("Skriv løn");
        //    string input1 = Console.ReadLine();
        //    string sql1 = "UPDATE person SET loen += " + @input1 + " WHERE cpr = " + @input;
        //    SqlCommand cmd1 = new SqlCommand(sql1, con);
        //    cmd1.Parameters.AddWithValue(@input, input);
        //    cmd1.Parameters.AddWithValue(@input1, input1);
        //    cmd1.Transaction = tran;
        //    cmd1.ExecuteNonQuery();
        //    tran.Commit();
        //    Console.WriteLine("Løn ændret");
        //    Console.ReadLine();

        //    //------

        //    con.Close();
        //    E3();
        //}

        ////Transaktioner og optimistisk låsning
        //private static void E4()
        //{
        //    string connStr = @"Data Source=localhost\sqlExpress;"
        //     + "Integrated security=true; "
        //     + "database=Dag10";


        //    SqlConnection con = new SqlConnection(connStr);
        //    con.Open();
        //    //------- Finder Person
        //    Console.WriteLine("Skriv CPR");
        //    string input = Console.ReadLine();
        //    string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@input", input);

        //    SqlTransaction tran = con.BeginTransaction();
        //    cmd.Transaction = tran;
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
        //        Console.WriteLine(line);
        //    }
        //    reader.Close();
        //    //------

        //    //------ Opdaterer Løn
        //    Console.WriteLine("Skriv løn");
        //    string input1 = Console.ReadLine();
        //    string sql1 = "UPDATE person SET loen += " + @input1 + " WHERE cpr = " + @input;
        //    SqlCommand cmd1 = new SqlCommand(sql1, con);
        //    cmd1.Parameters.AddWithValue(@input, input);
        //    cmd1.Parameters.AddWithValue(@input1, input1);
        //    cmd1.Transaction = tran;
        //    cmd1.ExecuteNonQuery();
        //    tran.Commit();
        //    Console.WriteLine("Løn ændret");
        //    Console.ReadLine();

        //    //------

        //    con.Close();
        //    E4();
        //}

        ////Transaktioner og isolation level snapshot
        //private static void E5()
        //{
        //    string connStr = @"Data Source=localhost\sqlExpress;"
        //    + "Integrated security=true; "
        //    + "database=Dag10";


        //    SqlConnection con = new SqlConnection(connStr);
        //    //------- Finder Person
        //    Console.WriteLine("Skriv CPR");
        //    string input = Console.ReadLine();
        //    string sql = "SELECT navn, stilling, loen FROM person WHERE cpr = " + @input;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@input", input);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string line = "Navn: " + reader[0] + ", Stilling: " + reader[1] + ",Løn: " + reader[2];
        //        Console.WriteLine(line);

        //    }
        //    reader.Close();
        //    //------

        //    //------ Opdaterer Løn
        //    Console.WriteLine("Skriv løn");
        //    string input1 = Console.ReadLine();
        //    string sql1 = "UPDATE person SET loen += " + @input1 + " WHERE cpr = " + @input;
        //    SqlCommand cmd1 = new SqlCommand(sql1, con);
        //    cmd1.Parameters.AddWithValue(@input, input);
        //    cmd1.Parameters.AddWithValue(@input1, input1);
        //    cmd1.ExecuteNonQuery();
        //    Console.WriteLine("Løn ændret");
        //    Console.ReadLine();
        //    //------

        //    con.Close();
        //    E5();
        //}


    }
}
