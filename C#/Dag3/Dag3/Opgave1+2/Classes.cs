using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    public struct Time
    {
        private int minute;

        public int Hour
        {
            get { return minute / 60; }
            set
            {
                if (value > 23 || value < 0)
                    throw new Exception("nej nej nej");
                minute = minute % 60 + value * 60;
            }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
                throw new Exception("din hat");
            this.minute = minute + 60 * hour;
        }

        public Time(string str)
        {
            if (str.Length != 5)
            {
                throw new Exception("Fjols");
            }
            minute = Int32.Parse(str.Substring(3, 2))
                + Int32.Parse(str.Substring(0, 2)) * 60;
        }

        public override string ToString()
        {
            int hour = minute / 60;
            int m = minute % 60;
            return hour + ":" + m;
        }


        public static Time operator +(Time t1, Time t2)
        {


            return t1;
        }
    }
}
