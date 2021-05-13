using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreUI
{
    public class menu : IMenu
    {

        // private IMenu submenu;
        public void StartMenu()
        {
            Location Miami = new Location("Miami", "FL");
            Miami.Items = new List<Item>
            {
                new Item{
                    BikeBrand = "Giant",
                    BikeType = "MountainBike"
                },
            };
            LoginMenu LoginMenu = new LoginMenu();
            bool repeat = true;
            do{
            Console.WriteLine("Welcome to my Bike Shop");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] ENTER");
            Console.WriteLine("[1] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    LoginMenu.StartLogin();
                    break;
                case "1":
                    Console.WriteLine("Goodbye - Thank you for visiting my Bike Shop");
                    repeat = false;
                    break;
                default:
                    Console.WriteLine("Please input a valid option");
                    break;
            }
        } while (repeat);
    }
}
}
