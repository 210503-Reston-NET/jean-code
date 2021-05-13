using System.Collections.Generic;

namespace StoreModels
{
    public class Item
    {
        public string BikeBrand{get;set;}

        public string BikeType{get;set;}

        public List<Item> Items {get;set;}

        public override string ToString()
        {
            return $" BikeType: {BikeBrand} \n\n TireType: {BikeType}";
        }
    }
}