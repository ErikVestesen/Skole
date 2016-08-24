using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeryMuchDigit {
    public static class DigitMyStringBitch {
        public static bool IsNumeric(this string str){
            foreach(char x in str) {
                if (Char.IsDigit(x))
                    return true;
            }
            return false;
        }
    }
}
