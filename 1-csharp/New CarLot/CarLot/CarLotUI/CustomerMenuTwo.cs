using CarLotModels;
using CarLotBL;
using System.Collections.Generic;
using System;

namespace CarLotUI
{
    public class CustomerMenuTwo : IMenu
    {
        private ICustomerBL _customerBL;
        private ICarBL _carBL;

        private IDescriptionBL _descriptionBL;
        private IValidationService _validate;
        private ILocationBL _locationBL;
        public CustomerMenuTwo(ICustomerBL customerBL, IValidationService validate, ILocationBL locationBL, ICarBL carBL)
        {
            _customerBL = customerBL;
            _validate = validate;
            _locationBL = locationBL;
            _carBL = carBL;
        }
        public void Start(){
            bool repeat = true;
            // Customer reviewable = CustomerLogin();
            // Location reviewable = SearchLocation();
            // int reviewable = 1;
            // if(reviewable != null)
            Customer reviewable = CustomerLogin();
            do
            {
                System.Console.WriteLine($"Hello : {reviewable.FirstName},");
                System.Console.WriteLine("Welcome to the customer profile menu");
                System.Console.WriteLine(("Please select an option"));
                System.Console.WriteLine("[0] View Inventory");
                System.Console.WriteLine("[1] Select Location");
                System.Console.WriteLine("[2] View all Locations");
                System.Console.WriteLine("[3] Make purchase");
                System.Console.WriteLine("[4] Go Back");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        ViewCar();
                        System.Console.WriteLine("View Inventory");
                        break;
                    case "1":
                        Location area = GetLocation();
                        // System.Console.WriteLine($"Now viewing inventory from : {area.City}, {area.State}");
                        break;
                    case "2":
                        // GetLocation();
                        System.Console.WriteLine("View All Locations");
                        break;
                    case "3":
                        PurchaseCar();
                        System.Console.WriteLine("Purchase Vehicle");
                        break;
                    case "4":
                        System.Console.WriteLine("Go back");
                        repeat = false;
                        break;
                }
            }while(repeat);
        }
        public Location GetLocation(){
            System.Console.WriteLine("Enter the location you'd like to browse.");
            string city = _validate.ValidateString("Enter the city: ");
            string state = _validate.ValidateString("Enter the state: ");
            string country = _validate.ValidateString("Enter the country: ");
            try
            {
                Location foundLocation = _locationBL.GetLocation(new Location(city, state, country));
                System.Console.WriteLine($"Now viewing location: {foundLocation.City}, {foundLocation.State}, {foundLocation.Country}");
                return foundLocation;
            }
                catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Location not found");
                return null;
            }
        }
        public Customer CustomerLogin(){
            System.Console.WriteLine("Please enter your login credentials");
            string firstName = _validate.ValidateString("Enter your first name");
            string lastName = _validate.ValidateString("Enter your last name: ");
            int pin = _validate.ValidateInt("Enter your pin");
            try
            {
                Customer foundCustomer = _customerBL.GetCustomer(new Customer(firstName, lastName, pin));
                Console.WriteLine("Customer Found");
                return foundCustomer;
            }
            catch(Exception)
            {
                // Console.WriteLine(ex.Message);
                Console.WriteLine("Account not found");
                return null;
            }
        }
        private void ViewCar()
        {
            List<Car> cars = _carBL.GetAllCars();
            if (cars.Count == 0) Console.WriteLine("No cars in this store");
            else
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
        private void PurchaseCar()
        {
            string make = _validate.ValidateString("Enter the vehicle make: ");
            string model = _validate.ValidateString("Enter the vehicle model: ");
            int year = _validate.ValidateInt("Enter the vehicle year: ");
            try
            {
                _carBL.DeleteCar(new Car(make, model, year));
                System.Console.WriteLine("Vehicle deleted");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}



