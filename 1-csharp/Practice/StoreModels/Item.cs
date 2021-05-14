using System.Collections.Generic;

namespace StoreModels
{
    public class Item
    {
        public Item(string bikeBrand, string bikeType)
        {
            this.BikeBrand = bikeBrand;
            this.BikeType = bikeType;
        }
        public string BikeBrand{get;set;}

        public string BikeType{get;set;}

        public override string ToString()
        {
            return $" BikeBrand: {BikeBrand} \n\n BikeType: {BikeType}";
        }
        public bool Equals(Item item)
        {
            return this.BikeType.Equals(item.BikeType) && this.BikeBrand.Equals(item.BikeBrand);
        }
    }
}