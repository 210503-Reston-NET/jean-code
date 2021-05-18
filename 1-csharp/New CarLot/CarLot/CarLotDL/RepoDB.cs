using System.Collections.Generic;
using Model = CarLotModels;
using Entity = CarLotDL.Entities;
using System.Linq;
using CarLotModels;
using Microsoft.EntityFrameworkCore;

namespace CarLotDL
{
    public class RepoDB : IRepository
    {
        private Entity.PracticeContext _context;
        public RepoDB(Entity.PracticeContext context)
        {
            _context = context;
        }
        public Model.Car AddCar(Model.Car car)
        {
            //This records a change in the context change tracker that we want to add this particular entity to the 
            // db
            _context.Cars.Add(
                new Entity.Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year
                }
            );
            //This persists the change to the db
            // Note: you can create a separate method that persists the changes so that you can execute repo commands in
            //the BL and save changes only when all the operations return no exceptions
            _context.SaveChanges();
            return car;
        }

        public Model.Description AddDescription(Car car, Description description)
        {
            _context.Descriptions.Add(
                new Entity.Description
                {
                    Rating = description.Rating,
                    Mpg = description.Mpg,
                    CarId = GetCar(car).Id
                }
            );
            _context.SaveChanges();
            return description;
        }

        public Car DeleteCar(Car car)
        {
            Entity.Car toBeDeleted = _context.Cars.First(resto => resto.Id == car.Id);
            _context.Cars.Remove(toBeDeleted);
            _context.SaveChanges();
            return car;
        }

        public List<Model.Car> GetAllCars()
        {
            return _context.Cars
            .Select(
                car => new Model.Car(car.Make, car.Model, car.Year)
            ).ToList();
        }

        public Model.Car GetCar(Model.Car car)
        {
            //find me a restaurant from the db that is equal to the input restaurant
            Entity.Car found = _context.Cars.FirstOrDefault(resto => resto.Make == car.Make && resto.Model == car.Model && resto.Year == car.Year);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Car(found.Id, found.Make, found.Model, found.Year);
        }

        public List<Description> GetDescriptions(Car car)
        {
            // We get the reviews such that, we find the restuarant that matches the restaurant being passed, 
            // we get the id of that specific restaurant, compare it to the FK references in the Reviews table
            // get the reviews that match the condition
            //  transform the entity type reviews to a model type review
            // Immediately execute the linq query by calling tolist, which takes the data from the db and puts it in 
            // a list

            //Finding the restaurant from the db, to be able to take advantage of the Id property the model doesn't have (well now it does)
            //Entity.Restaurant foundResto = _context.Restaurants.FirstOrDefault(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State);

            return _context.Descriptions.Where(
                description => description.Id == GetCar(car).Id
                ).Select(
                    description => new Model.Description
                    {
                        Rating = description.Rating,
                        Mpg = description.Mpg
                    }
                ).ToList();
        }
    }
}