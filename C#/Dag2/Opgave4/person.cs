using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CPRException;

namespace Opgave4
{
   public class Person {
        //public DateTime birthday { get; }

        private string cpr;
        public string CPR
        {
            get
            {
                return cpr;
            }
            set
            {
                try
                {
                    if (value.Length == 10) {
                        foreach (char i in value) {
                            if (Char.IsLetter(i)) {
                                throw new Exception("BOGSTAV");
                            }
                        }
                    } else {
                        throw new Exception("DER MÅ KUN VÆRE 10 TAL I, DIN HAT");
                    }
                }
                catch (Exception e) { System.Diagnostics.Debug.WriteLine(e); }
            }
        }
    }
}
