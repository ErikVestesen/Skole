using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opg4_Classes
{
    public class EksamensData: INotifyPropertyChanged
    {
      public EksamensData()
      {
        eksAar = 2011;
        eksSnit = 8.2;
        studieAar = 2013;
        omregnetSnit = 0.0;

        OmregnSnit();
      }

      int eksAar;
      public int EksAar
      {
        get { return eksAar; }
        set {
          if (value == eksAar) return;

          eksAar = value; 
          if (PropertyChanged!=null)
            PropertyChanged(this,new PropertyChangedEventArgs("EksAar"));

          OmregnSnit();
        }
      }

      int studieAar;
      public int StudieAar
      {
        get { return studieAar; }
        set { 
          if (value == studieAar) return;

          studieAar = value; 
          if (PropertyChanged!=null)
            PropertyChanged(this,new PropertyChangedEventArgs("StudAar"));

          OmregnSnit();
        }
      }

      double eksSnit;
      public double EksSnit
      {
        get { return eksSnit; }
        set { 
          if (value == eksSnit) return;

          eksSnit = value; 
          if (PropertyChanged!=null)
            PropertyChanged(this,new PropertyChangedEventArgs("EksSnit"));

          OmregnSnit();
        }
      }

      double omregnetSnit;

      public double OmregnetSnit
      {
        get { return omregnetSnit; }
        set { 
          if (value == omregnetSnit) return;

          omregnetSnit = value; 
          if (PropertyChanged!=null)
            PropertyChanged(this,new PropertyChangedEventArgs("OmregnetSnit"));
        }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void OmregnSnit()
      {
        if (studieAar - eksAar <= 2 && eksSnit >= 8.0)
          OmregnetSnit = ((int)(eksSnit * 1.08 * 10) / 10.0);
        else
          OmregnetSnit = eksSnit;
      }

      public override string ToString()
      {
        return "Eksamen: "+eksAar + " " + eksSnit + ", Studie: " + studieAar + " " + omregnetSnit;
      }
    }
}
