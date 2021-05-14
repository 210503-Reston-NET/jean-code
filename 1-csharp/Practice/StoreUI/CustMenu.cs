using System;
using StoreModels;
using System.Collections.Generic;


namespace StoreUI
{
    public class CustMenu : IMenu
    {
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
                    LoginMenu.StartLogin();
                    break;
                default:
                    break;
            }
            }while(repeat);
        }
        private void ViewBike(){
            Location Miami = new Location("Miami", "FL");
            Miami.Items = new List<Item>();
            System.Console.WriteLine("Default location: ");
            // {
            //     new Item{
            //         BikeBrand = "Giant",
            //         BikeType = "MountainBike"
            //     };
            //     new Item{
            //         BikeBrand = "Specialized",
            //         BikeType = "RoadBike"
            //     };
            // }
            System.Console.WriteLine(Miami.City + ", " + Miami.State);
            // if(Item == 0)System.Console.WriteLine("No Items");
            // else
            // {
            //     foreach(Item item in Items)
            //     {
            //         System.Console.WriteLine(item.ToString());
            //     }
            // }
        }
    }
}


                