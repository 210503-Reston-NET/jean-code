using CarLotModels;
using CarLotBL;
using System.Collections.Generic;
using System;

namespace CarLotUI
{
    public class LoginMenu : IMenu
    {
        private IMenu submenu;
        private ICarBL _carBL;
        private IValidationService _validate;

        public LoginMenu(ICarBL carBL, IValidationService validate)
        {
            _carBL = carBL;
            _validate = validate;
        }
        public void Start(){
            bool repeat = true;
            do
            {
                System.Console.WriteLine("Welcome to my CarLot!");
                System.Console.WriteLine("[0] Customer Menu");
                System.Console.WriteLine("[1] Admin Menu");
                System.Console.WriteLine("[2] Exit");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        submenu = MenuFactory.GetMenu("customer");
                        submenu.Start();
                        break;
                    case "1":
                        submenu = MenuFactory.GetMenu("main");
                        submenu.Start();
                        break;
                    case "2":
                        System.Console.WriteLine("Thank you for visiting");
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Enter a valid response");
                        break;
                }
            }while(repeat);
        }
    }
}