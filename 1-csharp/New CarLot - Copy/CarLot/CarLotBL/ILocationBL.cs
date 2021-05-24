using System.Collections.Generic;
using CarLotModels;
namespace CarLotBL
{
    public interface ILocationBL
    {
        List<Location> GetAllLocations();
        Location AddLocation(Location location);
        Location GetLocation(Location location);
        Location DeleteLocation(Location location);

    }
}