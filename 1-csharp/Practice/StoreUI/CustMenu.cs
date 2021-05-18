using System;
using StoreModels;
using System.Collections.Generic;
using StoreBL;

namespace StoreUI
{
    public class CustMenu : IMenu
    {
        // private ICustBL _custBL;

        // private IValidationService _validate;
        // public CustMenu(ICustBL custBL, IValidationService validate)
        // {
        //     _custBL = custBL;
        //     _validate = validate;
        // }
        public void StartMenu(){


            LoginMenu LoginMenu = new LoginMenu();
            bool repeat = true;
            do{
            Console.WriteLine("[0] Browse Bikes");
            Console.WriteLine("[1] Go Back");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    ViewBike();
                    break;
                case "1":
                    repeat = false;
                    break;
                default:
                System.Console.WriteLine("Invalid input");
                    break;
            }
            }while(repeat);
        }
        private void ViewBike(){
            Location Miami = new Location("Miami", "FL");
            Item NewBike = new Item("Canondale", "Hybrid");
            Miami.Items = new List<Item>();
            System.Console.WriteLine("Default location: ");
            System.Console.WriteLine(Miami.City + ", " + Miami.State);

        }
    }
}


                