using CarLotModels;
using CarLotBL;
using System.Collections.Generic;

using System;


namespace CarLotUI
{
    public class CustomerMenu : IMenu
    {

        private ICarBL _carBL;

        private IValidationService _validate;



        public CustomerMenu(ICarBL carBL, IValidationService validate)
        {
            _carBL = carBL;
            _validate = validate;
        }
        public void Start(){
            bool repeat = true;
            // string Pin = "1111";
            do
            {
                System.Console.WriteLine("[0] Create a new account");
                System.Console.WriteLine("[1] Login");
                System.Console.WriteLine("[2] Go Back");
                string input = System.Console.ReadLine();
                switch(input)
                {
                    case "0":
                        System.Console.WriteLine("Create new account");
                        break;
                    case "1":
                        System.Console.WriteLine("Login");
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }while(repeat);

        }
    }
}