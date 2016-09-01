using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4
{
    class Classes
    {
        private string []months = new string[13];
        public string this [int i]
        {
            get {
                return months[i];
            }
            set {
                months[i] = value;
            }
        }
    }
}
