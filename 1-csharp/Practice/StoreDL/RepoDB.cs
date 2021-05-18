using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using StoreModels;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class RepoDB
    {
        private Entity.PracticeContext _context;

        public RepoDB(Entity.PracticeContext context)
        {
            _context = context;
        }
        // public Model.Bike AddBike(Bike bikeBrand, Bike bikeType)
        // {
        //     _context.Bikes.Add(
        //         new Entity.Bike
        //         {
        //             brand = bike.BikeBrand,
        //             type = bike.BikeType,
        //         }
        //     );
        //     _context.SaveChanges();
        //     return bike;
        // }

        public List<Model.Bike> GetBike(Bike bikeBrand, Bike bikeType)
        {
            return _context.Bikes
            .Select(
                bike => new Model.Bike(bike.BikeBrand, bike.BikeType)
            ).ToList();
        }
    }
}