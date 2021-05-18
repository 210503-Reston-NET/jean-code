using CarLotModels;
using CarLotBL;
using System.Collections.Generic;

using System;

namespace CarLotUI
{
    public class MainMenu : IMenu
    {
        private ICarBL _carBL;
        private IValidationService _validate;

        
        public MainMenu(ICarBL carBL, IValidationService validate)
        {
            _carBL = carBL;
            _validate = validate;
        }

        public void Start(){
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Car Lot");
                Console.WriteLine("[0] Add Car");
                Console.WriteLine("[1] View Car");
                Console.WriteLine("[2] Exit");

                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        System.Console.WriteLine("Add");
                        AddACar();
                        break;
                    case "1":
                        System.Console.WriteLine("View");
                        ViewCars();
                        break;
                    case "2":
                        System.Console.WriteLine("Exit");
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Enter a valid response");
                        break;
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


    }

}