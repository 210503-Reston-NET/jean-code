using System.Collections.Generic;
using CarLotModels;
using CarLotDL;
using System;

namespace CarLotBL
{
    public class LocationBL : ILocationBL
    {
        private IRepository _repo;
        public LocationBL(IRepository repo)
        {
            _repo = repo;
        }
        public Location AddLocation(Location location)
        {
            if(_repo.GetLocation(location) != null)
            {
                throw new Exception("Location already exists");
            }
            return _repo.AddLocation(location);
        }
        public List<Location> GetAllLocations()
        {
            return _repo.GetAllLocations();
        }

        public Location GetLocation(Location location)
        {
            return _repo.GetLocation(location);
        }
    }
}