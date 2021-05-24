using Entity = CarLotDL.Entities;
using Model = CarLotModels;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CarLotDL;
using System.Linq;

namespace CarLotTests
{
    public class RepoTest
    {
        private readonly DbContextOptions<Entity.PracticeContext> options;
        public RepoTest()
        {
            options = new DbContextOptionsBuilder<Entity.PracticeContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
        }
        [Fact]
        public void GetAllCarsShouldReturnAllCars()
        {
            using (var context = new Entity.PracticeContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var cars = _repo.GetAllCars();
                Assert.Equal(2, cars.Count);
            }
        }
        [Fact]
        public void AddRestaurantShouldAddRestaurant()
        {
            using (var context = new Entity.PracticeContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddCar
                (
                    new Model.Car("Who", "Samsung", 2222)
                );
            }
            using (var assertContext = new Entity.PracticeContext(options))
            {
                var result = assertContext.Cars.FirstOrDefault(car => car.Id == 3);
                Assert.NotNull(result);
                Assert.Equal("Honda", result.Model);
            }
        }
        private void Seed()
        {
            using (var context = new Entity.PracticeContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Cars.AddRange
                (
                    new Entity.Car
                    {
                        Id = 1,
                        Make = "Ford",
                        Model = "Hummer",
                        Year = 4342,
                        Descriptions = new List<Entity.Description>
                        {
                            new Entity.Description
                            {
                                Id = 1,
                                Rating = "great",
                                Mpg = 25,
                                Price = 25000
                            },
                            new Entity.Description
                            {
                                Id = 2,
                                Rating = "Not bad",
                                Mpg = 22,
                                Price = 30000
                            }
                        }
                    },
                    new Entity.Car
                    {
                        Id = 2,
                        Make = "Scion",
                        Model = "TC",
                        Year = 2000,
                        Descriptions = new List<Entity.Description>
                        {
                            new Entity.Description
                            {
                                Id = 2,
                                Rating = "awesome",
                                Mpg = 27,
                                Price = 31000
                            },
                            new Entity.Description
                            {
                                Id = 7,
                                Rating = "amazing",
                                Mpg = 27,
                                Price = 22000
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
