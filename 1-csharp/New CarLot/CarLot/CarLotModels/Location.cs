using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarLotModels
{
    public class Location
    {
        public Location(string city, string state, string country)
        {
            this.City = city;
            this.State = state;
            this.Country = country;
        }

        public Location(int id, string city, string state, string country): this(city, state, country){
            this.Id = id;
        }
        public Location(){}
        public string City{get;set;}
        public string State{get;set;}
        public string Country{get;set;}
        public int Id { get; set; }

        public List<Description> Descriptions { get; set; }

        public override string ToString()
        {
            return $" City: {City} \n State: {State} \n Country: {Country}";
        }
        public bool Equals(Location location)
        {
            return this.City.Equals(location.City) && this.State.Equals(location.State) && this.Country.Equals(location.Country);
        }

    }
}