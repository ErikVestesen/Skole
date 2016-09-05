using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateEks3
{
    public delegate void goAlarm(int temp);
    public delegate void SendTemp(int newtemp);
    public delegate void Messures(int temp, int wind, int pressure);

    // vejrstation der måler temperatur og adviserer alle lyttere
    // svarer til Observable i Observer-pattern
    public class WeatherStation
    {
        // event variabel
        public event Messures messures;
        public event SendTemp sendEvent;
        public event goAlarm alarm;

        int temp = 20;
        int pressure = 940;
        int wind = 0;
        Random rnd = new Random();

        public void GetWeatherData() {
            temp += rnd.Next(11) - 5;
            pressure += rnd.Next(17) - 8;
            wind += rnd.Next(11) - 5;
            if (wind < 0)
                wind = 5;
            if (messures != null) messures(temp, wind, pressure);
        }
        // mål ny temperatur og adviser alle lytterer gennem delegate variablen tempChanged
        public void getNewTemp()
        {
            temp += 6;
            if (alarm != null) alarm(temp);
            if (sendEvent != null) sendEvent(temp);
        }
    }
    public class alarmHandler
    {
        public void display(int temp)
        {
            if (temp > 35)
                Console.WriteLine("----!!!!!HEAT ALARM!!!!----");
        }
    }
    // min-max måler som får nye temperaturer fra WetherStation og gennem aktuel samt min og max og udskriver
    // svarer til et Observer-objekt i Observar-pattern
    public class MinMaxDisplay
    {
        static int nr = 0;
        int displayNr;

        public MinMaxDisplay()
        {
            nr++;
            displayNr = nr;
        }

        int currentTemp = 0;
        int minTemp = int.MaxValue;
        int maxTemp = int.MinValue;

        // metoder der som parameter får ny temperatur og viser data
        public void Display(int temp)
        {
            currentTemp = temp;
            if (temp < minTemp) minTemp = temp;
            if (temp > maxTemp) maxTemp = temp;

            Console.Write("MinMax måler nr. " + displayNr + ":  ");
            Console.WriteLine("Temperatur= {0:D}, Min= {1:F1}, Max= {2:F1}", currentTemp, minTemp, maxTemp);
        }
    }

    public class DisplayAll
    {
        public void Display(int temp, int wind, int pressure)
        {
            Console.WriteLine("Temperatur = {0:D}, Wind = {1:F1}, Pressure ={2:F2})", temp, wind, pressure);
        }

    }

    public class MiddelDisplay
    {
        static int nr = 0;
        int displayNr;

        public MiddelDisplay()
        {
            nr++;
            displayNr = nr;
        }

        int currentTemp = 0;
        int antal = 0;
        int sum = 0;

        // metoder der som parameter får ny temperatur og viser data
        public void Display(int temp)
        {
            currentTemp = temp;
            antal++;
            sum += temp;

            Console.Write("Middel måler nr. " + displayNr + ":  ");
            Console.WriteLine("Temperatur= {0:D}, Middel= {1:F1}", currentTemp, (sum + 0.0) / antal);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // skab WeatherStation objekt
            WeatherStation weatherStation = new WeatherStation();

            Console.Write("Antal min-max målere: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n1; i++)
            {
                // nyt minmax display objekt
                MinMaxDisplay mm = new MinMaxDisplay();
                alarmHandler ah = new alarmHandler();
                // addér mm.Display-metoden til SendTemp delegaten i WeatherStation
                weatherStation.sendEvent += new SendTemp(mm.Display);
                weatherStation.alarm += new goAlarm(ah.display);
            }

            Console.Write("Antal middel målere: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n2; i++)
            {
                // nyt minmax display objekt
                MiddelDisplay mi = new MiddelDisplay();

                // addér mi.Display-metoden til SendTemp delegaten i WeatherStation
                weatherStation.sendEvent += new SendTemp(mi.Display);
            }

            weatherStation.getNewTemp(); Console.WriteLine();
            weatherStation.getNewTemp(); Console.WriteLine();
            weatherStation.getNewTemp(); Console.WriteLine();
            weatherStation.getNewTemp(); Console.WriteLine();

            DisplayAll da = new DisplayAll();
            weatherStation.messures += new Messures(da.Display);

            weatherStation.GetWeatherData(); Console.WriteLine();
            weatherStation.GetWeatherData(); Console.WriteLine();
            weatherStation.GetWeatherData(); Console.WriteLine();
            weatherStation.GetWeatherData(); Console.WriteLine();
            weatherStation.GetWeatherData(); Console.WriteLine();
            weatherStation.GetWeatherData(); Console.WriteLine();
            // vent Enter tryk
            Console.ReadLine();

            MiddelDisplay miNew = new MiddelDisplay();
            // næsten linie er ulovlig
            // weatherStation.sendEvent = new SendTemp(miNew.Display);
        }

    }
}
