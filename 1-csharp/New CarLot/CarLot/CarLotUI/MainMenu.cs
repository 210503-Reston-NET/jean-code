using CarLotModels;
using CarLotBL;
using System.Collections.Generic;

using System;

namespace CarLotUI
{
    public class MainMenu : IMenu
    {
        private IMenu submenu;
        private ICarBL _carBL;
        private IValidationService _validate;
        // private IDescriptionBL _descriptionBL;
        private ILocationBL _locationBL;

        public MainMenu(ICarBL carBL, IValidationService validate, ILocationBL locationBL)
        {
            _carBL = carBL;
            _validate = validate;
            _locationBL = locationBL;
        }
        public void Start(){
            bool repeat = true;
            string Pin = "1111";
            System.Console.WriteLine("Please Enter pin to continue");
            string pinInput = System.Console.ReadLine();
            do
            {
                if(Pin == pinInput){
                Console.WriteLine("[0] Add Car to inventory");
                Console.WriteLine("[1] View inventory");
                Console.WriteLine("[2] Edit inventory");
                Console.WriteLine("[3]      Add Locations");
                Console.WriteLine("[4]      View Locations");
                Console.WriteLine("[5]      Edit Locations");
                Console.WriteLine("[6] Go Back");

                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        AddACar();
                        break;
                    case "1":
                        ViewCars();
                        break;
                    case "2":
                        submenu = MenuFactory.GetMenu("admin");
                        submenu.Start();
                        break;
                    case "3":
                        AddALocation();
                        System.Console.WriteLine("Add Location");
                        break;
                    case "4":
                        ViewLocations();
                        break;
                    case "5":
                        SearchLocation();
                        System.Console.WriteLine("Edit Location");
                        break;
                    case "6":
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Enter a valid response");
                        break;
                }
                }else if(pinInput != Pin){
                    System.Console.WriteLine("Wrong Pin");
                    repeat = false;
                }
            }while(repeat);
        }

        private void AddACar()
        {
            string make = _validate.ValidateString("Enter the vehicle make: ");
            string model = _validate.ValidateString("Enter the vehicle model: ");
            int year = _validate.ValidateInt("Enter the vehicle year: ");
            try
            {
                Car newCar = new Car(make, model, year);
                Car createdCar = _carBL.AddCar(newCar);
                Console.WriteLine("New Vehicle Created!");
                Console.WriteLine(createdCar.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddALocation()
        {
            string city = _validate.ValidateString("City: ");
            string state = _validate.ValidateString("State: ");
            string country = _validate.ValidateString("Country: ");
            try
            {
                Location newLocation = new Location(city, state, country);
                Location createdLocation = _locationBL.AddLocation(newLocation);
                Console.WriteLine("New Location Created!");
                Console.WriteLine(createdLocation.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewCars()
        {
            List<Car> cars = _carBL.GetAllCars();
            if (cars.Count == 0) Console.WriteLine("No restaurants :< You should add some");
            else
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
        private void ViewLocations()
        {
            List<Location> locations = _locationBL.GetAllLocations();
            if (locations.Count == 0) Console.WriteLine("No locations yet");
            else
            {
                foreach (Location location in locations)
                {
                    Console.WriteLine(location.ToString());
                }
            }
        }
        private Location SearchLocation()
        {
        Console.WriteLine("Enter the location you'd like to Edit.");
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

        // private void AddDescription(Car reviewable)
        // {
        //     int mpg = _validate.ValidateInt("Enter this vehicles MPG");
        //     string rating = _validate.ValidateString("Information of the vehicle: ");
        //     int carId = _validate.ValidateInt("Enter this vehicles MPG");
        //     int price = _validate.ValidateInt("Price: ");
        //     _descriptionBL.AddDescription(reviewable, new Description(mpg, rating, price));
        // }

        // private Car SearchCar(){
        //     string make = _validate.ValidateString("Enter the car Make: ");
        //     string model = _validate.ValidateString("Enter the Model: ");
        //     int year = _validate.ValidateInt("Enter the year: ");
        //     try{
        //         Car foundCar = _carBL.GetCar(new Car(make, model, year));
        //         // Console.WriteLine("Car Found!");
        //         System.Console.WriteLine(make, model, year);
        //         return foundCar;
        //     }
        // catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     Console.WriteLine("Car was not found");
        //     return null;
        }
    }
}

