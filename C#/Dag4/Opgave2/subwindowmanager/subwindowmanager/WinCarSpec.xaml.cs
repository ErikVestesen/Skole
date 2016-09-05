using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace subwindowmanager
{
  /// <summary>
  /// Interaction logic for WinCarSpec.xaml
  /// </summary>
  public partial class WinCarSpec : Window
  {
    string carId = "";
    public WinCarSpec()
    {
      InitializeComponent();

      this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - this.Width;
    }

    public void setCarId(string carId)
    {
      this.carId = carId;

      loadSpec(carId);
    }

    private void loadSpec(string carId)
    {
      lblId.Content = carId;
      tBlock.Text="";

      string line;
      System.IO.StreamReader file =
         new System.IO.StreamReader(carId+".txt");
      while ((line = file.ReadLine()) != null)
      {
        tBlock.Text += line + Environment.NewLine;
      }

      file.Close();
    }
  }
}
