using System.Collections.Generic;
using CarLotModels;
namespace CarLotBL
{
    public interface ICarBL
    {
        List<Car> GetAllCars();
        Car AddCar(Car car);
        Car GetCar(Car car);
        Car DeleteCar(Car car);
    }
}