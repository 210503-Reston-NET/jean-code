using System.Collections.Generic;
using CarLotModels;

namespace CarLotDL
{
    public interface IRepository
    {
        List<Car> GetAllCars();

        Car AddCar(Car car);
        Car GetCar(Car car);

        Car DeleteCar(Car car);

        Description AddDescription(Car car, Description description);
        List<Description> GetDescriptions(Car car);

    }
}