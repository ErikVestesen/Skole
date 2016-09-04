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
  /// Interaction logic for WinCarImage.xaml
  /// </summary>
  public partial class WinCarImage : Window
  {
    string carId="";

    public WinCarImage()
    {
      InitializeComponent();

      this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - this.Width;
    }

    public void setCarId(string carId)
    {
      this.carId = carId;

      loadImage(carId);
    }

    private void loadImage(string carId)
    {
      lblId.Content = carId;

      BitmapImage src = new BitmapImage();
      src.BeginInit();
      src.UriSource = new Uri(carId+".jpg", UriKind.Relative);
      src.CacheOption = BitmapCacheOption.OnLoad;
      src.EndInit();
      image.Source = src;
    }
  }
}
