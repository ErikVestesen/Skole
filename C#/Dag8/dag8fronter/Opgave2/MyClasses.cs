using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    class Staff
    {
        string fullName;
        public String FullName { get; set; }
        string initials;
        public String Initials { get; set; }
        string fileName;
        public String FileName { get; set; }

        public Staff(string fullName, string initials, string fileName)
        {
            this.fullName = fullName;
            this.initials = initials;
            this.fileName = fileName;
        }

    }
}
