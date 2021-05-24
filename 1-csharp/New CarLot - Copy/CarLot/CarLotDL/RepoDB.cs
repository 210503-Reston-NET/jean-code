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
                    Year = car.Year,
                    // LocationId = GetLocation(location).Id,
                    // LocationId = _context.Locations.FirstOrDefault(resto => resto.City == location.City && resto.State == location.State && resto.Country == location.Country).Id
                }
                
            );
            _context.SaveChanges();
            return car;
        }

        public Description AddDescription(Car car, Description description)
        {
            _context.Descriptions.Add(
                new Entity.Description
                {
                    Rating = description.Rating,
                    Mpg = description.Mpg,
                    Price = description.Price,

                }
            );
            _context.SaveChanges();
            return description;
        }

        public Car DeleteCar(Car car)
        {
            Entity.Car toBeDeleted = _context.Cars.First(resto => resto.InventoryId == car.InventoryId);
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
            return new Model.Car(found.InventoryId, found.Make, found.Model, found.Year);
        }
        public List<Description> GetDescriptions(Car car)
        {
            return _context.Descriptions.Where(
                description => description.InventoryId == GetCar(car).InventoryId
                ).Select(
                    description => new Model.Description
                    {
                        Rating = description.Rating,
                        Mpg = description.Mpg,
                        Price = description.Price
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
                    Pin = customer.Pin
                }
            );
            _context.SaveChanges();
            return customer;
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers
            .Select(
                customer => new Model.Customer(customer.FirstName, customer.LastName, customer.Pin)
            ).ToList();
        }

        public Model.Customer GetCustomer(Model.Customer customer)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(resto => resto.FirstName == customer.FirstName && resto.LastName == customer.LastName && resto.Pin == customer.Pin);
            if (found == null) return null;
            return new Model.Customer(found.FirstName, found.LastName, found.Pin);
        }

        public Customer DeleteCustomer(Customer customer)
        {
            Entity.Customer toBeDeleted = _context.Customers.First(resto => resto.Id == customer.Id);
            _context.Customers.Remove(toBeDeleted);
            _context.SaveChanges();
            return customer;
        }

        public Model.Location AddLocation(Model.Location location)
        {
            _context.Locations.Add(
                new Entity.Location
                {
                    City = location.City,
                    State = location.State,
                    Country = location.Country
                }
            );
            _context.SaveChanges();
            return location;
        }
        public Location DeleteLocation(Location location)
        {
            Entity.Location toBeDeleted = _context.Locations.First(resto => resto.Id == location.Id);
            _context.Locations.Remove(toBeDeleted);
            _context.SaveChanges();
            return location;
        }
        public List<Model.Location> GetAllLocations()
        {
            return _context.Locations
            .Select(
                location => new Model.Location(location.Id, location.City, location.State, location.Country)
            ).ToList();
        }
        public Model.Location GetLocation(Model.Location location)
        {
            Entity.Location found = _context.Locations.FirstOrDefault(resto => resto.City == location.City && resto.State == location.State && resto.Country == location.Country);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Location(found.Id, found.City, found.State, found.Country);
        }
        // public Model.Orders AddOrder(Model.Orders orders, Location location)
        // {
        //     _context.Orders.Add(
        //         new Entity.Orders
        //         {
        //             OrderId = orders.OrderId,
        //             LocationId = GetLocation(location).Id,
        //             CustomerId = GetCustomer(customer).Id
        //             CarId = GetCar(car).Id



        //         }
        //     );
        //     _context.SaveChanges();
        //     return orders;
        // }
    }
}