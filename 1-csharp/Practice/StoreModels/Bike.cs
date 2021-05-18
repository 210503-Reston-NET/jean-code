using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StoreModels
{
    public class Bike
    {
        private string _city;
        public Bike(string brand, string type)
        {
            this.BikeBrand = brand;
            this.BikeType = type;
        }
        public Bike()
        {

        }
        public int Id{get;set;}

        public string BikeBrand{get;set;}
        public string BikeType{get;set;}

        public override string ToString()
        {
            return $" Brand: {BikeBrand} \n Type: {BikeType}";
        }
    }
}