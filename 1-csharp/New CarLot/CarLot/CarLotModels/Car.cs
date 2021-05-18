using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/// <summary>
/// Namespace for the models/custom data structures involved in Restaurant Reviews
/// </summary>
namespace CarLotModels
{
    /// <summary>
    /// Data structure used to define a restaurant 
    /// </summary>
    public class Car
    {
        // Class Members
        // 1. Constructor - use this to create an instance of the class
        // 2. Fields - defines the characteristics of a class
        // 3. Methods - defines the behavior of a class
        // 4. Properties - also known as smart fields, are accessor methods used to access private backing fields (private fields)
        // *Note that properties are analogous to Java getter and setter
        // * Property naming convention uses PascalCase (like methods)
        private string _model;
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(int id, string make, string model, int year) : this(make, model, year)
        {
            this.Id = id;
        }
        public Car()
        {

        }

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
        public int Year { get; set; }
        public List<Description> Descriptions { get; set; }
        public override string ToString()
        {
            return $" Make: {Make} \n Model: {Model} \n Year: {Year}";
        }
        public bool Equals(Car car)
        {
            return this.Make.Equals(car.Make) && this.Model.Equals(car.Model) && this.Year.Equals(car.Year);
        }
        public int Id { get; set; }

    }
}