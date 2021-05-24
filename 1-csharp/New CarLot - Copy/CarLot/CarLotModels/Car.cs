using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarLotModels
{
    public class Car
    {
        // private string _model;
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(int inventoryid, string make, string model, int year) : this(make, model, year)
        {
            this.InventoryId = inventoryid;
        }
        public Car(){}
        public string Make { get; set; }
        public string Model
        {
            get;set;
            // get { return _model; }
            // set
            // {
            //     if (!Regex.IsMatch(value, @"^[A-Za-z .]+$")) throw new Exception("City cannot have numbers!");
            //     _model = value;
            // }
        }
        public int LocationId{get;set;}
        public int Year { get; set; }
        public List<Description> Descriptions { get; set; }
        public override string ToString()
        {
            return $" Make: {Make} \n Model: {Model} \n Year: {Year}";
        }
        public bool Equals(Car car)
        {
            return this.Make.Equals(car.Make) && this.Model.Equals(car.Model) && this.Year.Equals(car.Year)&& this.LocationId.Equals(car.LocationId);
        }
        public int InventoryId { get; set; }

    }
}