using CarLotModels;
using CarLotBL;
using System.Collections.Generic;
using System;

namespace CarLotUI
{
    public class CustomerMenuTwo : IMenu
    {
        private ICustomerBL _customerBL;
        private IValidationService _validate;

        private ILocationBL _locationBL;
        public CustomerMenuTwo(ICustomerBL customerBL, IValidationService validate)
        {
            _customerBL = customerBL;
            _validate = validate;
        }
        public void Start(){
            bool repeat = true;
            Location reviewable = SearchLocation();
            // int reviewable = 1;
            if(reviewable != null)
            {   System.Console.WriteLine("Welcome to the customer profile menu");
                System.Console.WriteLine(("Please select an option"));
            do
            {
                System.Console.WriteLine($"Now viewing location: {reviewable.City}, {reviewable.State}, {reviewable.Country}");
                System.Console.WriteLine("[0] View Inventory");
                System.Console.WriteLine("[1] Select Location");
                System.Console.WriteLine("[2] View all current Locations");
                System.Console.WriteLine("[3] Go Back");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        System.Console.WriteLine("View Inventory");
                        break;
                    case "1":
                        System.Console.WriteLine("select location");
                        break;
                    case "2":
                        System.Console.WriteLine("View All Locations");
                        break;
                    case "3":
                        System.Console.WriteLine("Go back");
                        repeat = false;
                        break;
                }
            }while(repeat);
        }
    }

        public void GetLocation(Location reviewable)
        {

        }


        private Location SearchLocation()
        {
        Console.WriteLine("Enter the location you'd like to browse.");
        string city = _validate.ValidateString("Enter the city: ");
        string state = _validate.ValidateString("Enter the state: ");
        string country = _validate.ValidateString("Enter the country: ");
        try
        {
            Location foundLocation = _locationBL.GetLocation(new Location(city, state, country));
            Console.WriteLine("Location Found!");
            return foundLocation;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Location not found");
            return null;
        }
    }
    }
}