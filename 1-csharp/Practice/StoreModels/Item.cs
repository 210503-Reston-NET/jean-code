using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreModels
{
    public class Item
    {
        public Item(string brand, string type)
        {
            this.BikeBrand = brand;
            this.BikeType = type;
        }
        public Item()
        {

        }
        public string BikeBrand{get;set;}
        public string BikeType{get;set;}

        public override string ToString()
        {
            return $" BikeBrand: {BikeBrand} \n\t BikeType: {BikeType}";
        }
        public bool Equals(Item item)
        {
            return this.BikeType.Equals(item.BikeType) && this.BikeBrand.Equals(item.BikeBrand);
        }
    }
}