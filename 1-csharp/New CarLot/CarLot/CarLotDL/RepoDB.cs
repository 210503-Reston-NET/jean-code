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
            _context.Cars.Add(
                new Entity.Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year
                }
            );
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
            Entity.Car found = _context.Cars.FirstOrDefault(resto => resto.Make == car.Make && resto.Model == car.Model && resto.Year == car.Year);
            if (found == null) return null;
            return new Model.Car(found.Id, found.Make, found.Model, found.Year);
        }
        public List<Description> GetDescriptions(Car car)
        {
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

        public Model.Customer AddCustomer(Model.Customer customer)
        {

            _context.Customers.Add(
                new Entity.Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone
                }
            );
            _context.SaveChanges();
            return customer;
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers
            .Select(
                customer => new Model.Customer(customer.Id, customer.FirstName, customer.LastName, customer.Phone)
            ).ToList();
        }

        public Model.Customer GetCustomer(Model.Customer customer)
        {
            //find me a restaurant from the db that is equal to the input restaurant
            Entity.Customer found = _context.Customers.FirstOrDefault(resto => resto.FirstName == customer.FirstName && resto.LastName == customer.LastName && resto.Phone == customer.Phone);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Customer(found.Id, found.FirstName, found.LastName, found.Phone);
        }

        public Customer DeleteCustomer(Customer customer)
        {
            Entity.Customer toBeDeleted = _context.Customers.First(resto => resto.Id == customer.Id);
            _context.Customers.Remove(toBeDeleted);
            _context.SaveChanges();
            return customer;
        }

    }
}