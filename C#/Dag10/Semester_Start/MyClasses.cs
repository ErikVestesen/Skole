using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_classes
{
  public class Semester
  {
    public string Init { get; set; }
    public string Desc { get; set; }

    public Semester(string init, string desc) 
    {
      this.Init = init;
      this.Desc = desc;
    }
  }

/*
  public class SemesterList
  {
    List<Semester> list = new List<Semester>();

    public List<Semester> List { get { return list; } }

    public void Generate()
    {
      for (int n = 7; n <= 20; n++)
      {
        string y2=(""+n).PadLeft(2,'0');

        list.Add(new Semester("F" + y2,"Forårssemester 20"+y2));
        list.Add(new Semester("E" + y2,"Efterårssemester 20"+y2));
      }
    }
  }

  public class GlobDecl 
  {
    public static int CurYear { get; set; }
    public static string CurSemesterInit { get; set; }
  }
*/

}
