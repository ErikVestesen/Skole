using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subwindowmanager
{
  public class Car
  {
    public string Id { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Price { get; set; }

    public string Ident
    {
      get { return Manufacturer + " " + Model+ " " + Price; }
    }
  }

  public class Service
  {
    // singleton
    static Service instance = null;

    List<Car> carList = new List<Car>();
    public List<Car> CarList
    {
      get { return carList; }
    }

    private Service()
    {
      Car car = new Car
      {
        Id="001",
        Model = "320i",
        Manufacturer = "BMW",
      };
      carList.Add(car);

      car = new Car
      {
        Id="002",
        Model = "Xantia",
        Manufacturer = "Citroen",
      };
      carList.Add(car);

      car = new Car
      {
        Id="003",
        Model = "90",
        Manufacturer = "Audi",
      };
      carList.Add(car);
    }

    public static Service Instance
    {
      get
      {
        if (instance == null)
          instance = new Service();

        return instance;
      }
    }

  }
}
