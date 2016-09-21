using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;

namespace dag8opg1start
{
    public class Person
    {
        string name;
        public string Name
        {
            get { return name; }
            set
            { name = value; }
        }

        double height;
        public double Height
        {
            get { return height; }
            set
            { height = value; }
        }

        int weight;
        public int Weight
        {
            get { return weight; }
            set
            { weight = value; }
        }

        public double BMI
        {
            get { return weight/height/height; }
        }

        public override string ToString()
        {
            string s=String.Format("{0}, h={1}, w={2}: BMI={3:##.#}", name, height, weight, BMI);
            return s;
        }

    }


}
