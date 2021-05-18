using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;

namespace StoreBL
{
    public class BikeBL : IBikeBL
    {
        private IRepository _repo;

        public BikeBL(IRepository repo)
        {
            _repo = repo;
        }

        public Bike AddBike(Bike bikeBrand, Bike BikeType)
        {
            if(_repo.GetBike(bike) != null)
            {
                throw new Exception("Bike already exists");
            }
            return _repo.AddBike(bike);
        }
        // public Bike GetBike(Bike bike)
        public List<Bike> GetBike(Bike bikeBrand, Bike BikeType)
        {
            return _repo.GetBike();
        }
    }
}