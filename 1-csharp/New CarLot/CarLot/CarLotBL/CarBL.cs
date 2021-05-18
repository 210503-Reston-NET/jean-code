using System.Collections.Generic;
using CarLotModels;
using CarLotDL;
using System;

namespace CarLotBL
{
    public class CarBL : ICarBL
    {
        private IRepository _repo;
        public CarBL(IRepository repo)
        {
            _repo = repo;
        }

        public Car AddCar(Car car)
        {
            // Todo: call a repo method that adds a restaurant
            if (_repo.GetCar(car) != null)
            {
                throw new Exception("Restaurant already exists :<");
            }
            return _repo.AddCar(car);
        }

        public Car DeleteCar(Car car)
        {
            Car toBeDeleted = _repo.GetCar(car);
            if (toBeDeleted != null) return _repo.DeleteCar(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public List<Car> GetAllCars()
        {
            //Note that this method isn't really dependent on any inputs/parameters, I can just directly call the 
            // DL method in charge of getting all restaurants
            return _repo.GetAllCars();
        }

        public Car GetCar(Car car)
        {
            return _repo.GetCar(car);
        }
    }
}