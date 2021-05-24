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
        private IDescriptionBL _descriptionBL;
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
                        Location currentLocation = SearchLocation();
                        System.Console.WriteLine($"Edit Location: {currentLocation.City}");
                        System.Console.WriteLine("[0] Add car");
                        System.Console.WriteLine("[1] go back");
                        string ayy = Console.ReadLine();
                        switch(ayy)
                        {
                            case "0": 
                                Car AddToLocation = AddACar();
                                // AddACar();
                                // string make = _validate.ValidateString("Enter the vehicle make: ");
                                // string model = _validate.ValidateString("Enter the vehicle model: ");
                                // int year = _validate.ValidateInt("Enter the vehicle year: ");
                                // Car newCar = new Car(make, model, year);
                                // Car createdCar = _carBL.AddCar(newCar);
                                // _carBL.AddCar(new Car(make, model, year));
                                // _locationBL.AddCar(make, model, year);
                                break;
                            case "1":
                                System.Console.WriteLine("Go back");
                                repeat = false;
                                break;
                            default:
                                System.Console.WriteLine("Invalid input");
                                break;
                        }
                        break;
                    case "1":
                        ViewCars();
                        break;
                    case "2":
                        Car foundCar = GetCar();
                        System.Console.WriteLine($"Edit Car: {foundCar.Make}, {foundCar.Model}, {foundCar.Year}");
                        System.Console.WriteLine("[0] Add description");
                        System.Console.WriteLine("[1] View description");
                        System.Console.WriteLine("[2] Go back");
                        string ello = Console.ReadLine();
                        switch(ello)
                        {
                            case "0":
                                int mpg = _validate.ValidateInt("Enter the vehicle mpg: ");
                                string rating = _validate.ValidateString("Enter the vehicle rating: ");
                                int price = _validate.ValidateInt("Enter the vehicle price: ");
                                _descriptionBL.AddDescription(foundCar, new Description(mpg, rating, price));
                                // AddADescription();
                                break;
                            case "1":
                                break;
                            case "2":
                                repeat = false;
                                break;
                        }
                        // AddADescription();
                        // submenu = MenuFactory.GetMenu("admin");
                        // submenu.Start();
                        break;
                    case "3":
                        AddALocation();
                        System.Console.WriteLine("Add Location");
                        break;
                    case "4":
                        ViewLocations();
                        break;
                    case "5":
                        Location foundLocation = SearchLocation();
                        System.Console.WriteLine($"Edit Location: {foundLocation.City}");
                        System.Console.WriteLine("[0] delete location");
                        System.Console.WriteLine("[1] delete car");
                        System.Console.WriteLine("[2] go back");
                        string ree = Console.ReadLine();
                        switch(ree)
                        {
                            case "0": 
                                DeleteALocation(foundLocation);
                                System.Console.WriteLine("delete Location");
                                break;
                            case "1":
                                System.Console.WriteLine("Delete a car");
                                break;
                            case "2":
                                System.Console.WriteLine("Go back");
                                repeat = false;
                                break;
                            default:
                                System.Console.WriteLine("Invalid input");
                                break;
                        }
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
        // private void AddADescription()
        // {
        //     int mpg = _validate.ValidateInt("Enter the vehicle MPG: ");
        //     string rating = _validate.ValidateString("Enter the vehicle description: ");
        //     int price = _validate.ValidateInt("Enter the vehicle price: ");  
        //     try
        //     {
        //         Description newDescription = new Description(mpg, rating, price);
        //         Description createdDescription = _descriptionBL.AddDescription(newDescription);
        //         Console.WriteLine("New Description Created!");
        //         Console.WriteLine(createdDescription.ToString());
        //     }       
        //     catch(Exception ex)
        //     {
        //         System.Console.WriteLine(ex.Message);
        //     }   
        // }
        // private void AddCar()
        // {
        //     string make = _validate.ValidateString("Enter the vehicle make: ");
        //     string model = _validate.ValidateString("Enter the vehicle model: ");
        //     int year = _validate.ValidateInt("Enter the vehicle year: ");

        //     _carBL.AddCar(currentLocation, new Car(make, model, year));
        // }
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
            if (cars.Count == 0) Console.WriteLine("No vehicles");
            else
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
        public void ViewLocations()
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
            System.Console.WriteLine("Please select an option");
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
        private Location DeleteALocation(Location location)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private Car GetCar()
        {
        Console.WriteLine("Enter the Car you'd like to Edit.");
        string make = _validate.ValidateString("Enter the make: ");
        string model = _validate.ValidateString("Enter the model: ");
        int year = _validate.ValidateInt("Enter the year: ");
        try
        {
            Car foundCar = _carBL.GetCar(new Car(make, model, year));
            Console.WriteLine("Car Found!");
            System.Console.WriteLine("Please select an option");
            return foundCar;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Car not found");
            return null;
        }
    }
        private Car AddACar()
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
                return newCar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
}
}

