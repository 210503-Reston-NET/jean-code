using System;
using System.Collections.Generic;
using CarLotBL;
using CarLotModels;

namespace CarLotUI
{
    public class AdminMenu : IMenu
    {
        private ICarBL _carBL;
        private IValidationService _validate;
        private IDescriptionBL _descriptionBL;

        public AdminMenu(ICarBL carBL, IValidationService validate)
        {
            _carBL = carBL;
            _validate = validate;
        }

        public void Start(){
            bool repeat = true;
            Car reviewable = SearchCar();
            if(reviewable != null)
            {
                do
                {
                    Console.WriteLine($"Now editing: {reviewable.Make} {reviewable.Model} {reviewable.Year}! What would you like to do?");
                    Console.WriteLine("[0] Add a description");
                    Console.WriteLine("[1] View description");
                    Console.WriteLine("[2] Go back");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "0":
                            AddDescription(reviewable);
                            break;
                        case "1":
                            ViewDescriptions(reviewable);
                            break;
                        case "2": 
                            repeat = false;
                            break;
                        default:
                            System.Console.WriteLine("Invalid input");
                            break;
                    }
                } while(repeat);
            }
        }
        private void ViewDescriptions(Car reviewable)
        {
            Console.WriteLine($"Here are the details of the {reviewable.Year} {reviewable.Make} {reviewable.Model}");
            Tuple<List<Description>, int> descriptionResult = _descriptionBL.GetDescriptions(reviewable);
            descriptionResult.Item1.ForEach(description => Console.WriteLine(description.ToString()));
            Console.WriteLine($"Overall rating of the restaurant: {descriptionResult.Item2}");
        }

        private void ViewCars()
        {
            List<Car> cars = _carBL.GetAllCars();
            if (cars.Count == 0) Console.WriteLine("No cars!");
            else
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }

        private void AddDescription(Car reviewable)
        {
            int mpg = _validate.ValidateInt("Enter this vehicles MPG");
            string rating = _validate.ValidateString("Information of the vehicle: ");
            int price = _validate.ValidateInt("Price: ");
            _descriptionBL.AddDescription(reviewable, new Description(mpg, rating, price));
        }

         private Car SearchCar(){
            string make = _validate.ValidateString("Enter the car Make: ");
            string model = _validate.ValidateString("Enter the Model: ");
            int year = _validate.ValidateInt("Enter the year: ");
            try{
                Car foundCar = _carBL.GetCar(new Car(make, model, year));
                Console.WriteLine("Car Found!");
                return foundCar;
            }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Car was not found");
            return null;
        }
        }
    }
}