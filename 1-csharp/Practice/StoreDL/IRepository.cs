using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public interface IRepository
    {
        List<Bike> GetBike(Bike bikeBrand, Bike bikeType);
        Bike AddBike(Bike bikeBrand, Bike bikeType);
        // Bike GetBike(Bike bike);

        // Bike GetBike(Bike bike);
    }
}