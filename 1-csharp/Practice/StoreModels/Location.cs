using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StoreModels
{
    public class Location
    {

        public Location(string city, string state){
            this.City = city;
            this.State = state;
        }
        public Location(){

        }
        public string City{get;set;}
        public string State{get;set;}
        public List<Item> Items {get;set;}


        public override string ToString()
        {
            return $"\t City: {City} \n\t State: {State}";
        }
    }
}