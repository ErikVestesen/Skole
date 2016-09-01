using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4
{
   public class Person {
        private DateTime birthday;
        private string cpr;

        public DateTime Birthday {
            get;
        }
        public string CPR {
            get {
                return cpr;
            }
            set {
                checkCpr(value);
                cpr = value;
            }
        }

        private void checkCpr(string input) {
            if (input.Length != 10) 
                throw new IllegalCPRException("Length of CPR is not 10");
            else {
                foreach (char x in input) {
                    if (!Char.IsDigit(x)) {
                        throw new IllegalCPRException("CPR may only contain numbers");
                    }
                }
            }
        }
    }
    
    public class IllegalCPRException : Exception {
        public IllegalCPRException() 
        { }
        public IllegalCPRException(string message) 
            : base(message)
        { }
        public IllegalCPRException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
