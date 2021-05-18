using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IBikeBL
    {
        List<Bike> GetBike(Bike bikeBrand, Bike BikeType);
            Bike AddBike(Bike bikeBrand, Bike BikeType);
    }
}