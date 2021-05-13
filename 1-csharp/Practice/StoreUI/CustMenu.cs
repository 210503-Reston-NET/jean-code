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
            List<Item> items = new List<Item>();
            {
                new Item{
                    BikeBrand = "Giant",
                    BikeType = "MountainBike"
                };
            }
            if(items.Count == 0)System.Console.WriteLine("No Items");
            else
            {
                foreach(Item item in items)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }
    }
}


                