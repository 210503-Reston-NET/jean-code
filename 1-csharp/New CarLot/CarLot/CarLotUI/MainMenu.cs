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

            string Pin = "1111";
            System.Console.WriteLine("Please Enter pin to continue");
            string pinInput = System.Console.ReadLine();
            do
            {
                if(Pin == pinInput){
                Console.WriteLine("[0] Add Car to inventory");
                Console.WriteLine("[1] View inventory");
                Console.WriteLine("[2] Go Back");

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

        public void AdminPin()
        {


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