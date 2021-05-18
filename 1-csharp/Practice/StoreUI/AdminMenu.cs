using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class AdminMenu : IMenu
    {
        private IBikeBL _bikeBL;
        private IValidationService _validate;

        public void StartMenu(){

            LoginMenu Menu = new LoginMenu();

            bool repeat = true;
            do{
                System.Console.WriteLine("[0] Add item to store inventory");
                System.Console.WriteLine("[1] Remove item from store inventory");
                System.Console.WriteLine("[2] View store inventory");
                System.Console.WriteLine("[3] View all customers");
                System.Console.WriteLine("[4] Go Back");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        AddAItem();
                        break;
                    case "1":
                        System.Console.WriteLine("Remove Item");
                        break;
                    case "2":
                        GetABike();
                        System.Console.WriteLine("View Inventory");
                        break;
                    case "3":
                        System.Console.WriteLine("View all customers");
                        break;
                    case "4":
                        System.Console.WriteLine("Go Back");
                        repeat = false;
                        break;
                    default:
                        break;
                }
            }while(repeat);
        }
        private void AddAItem(){
            System.Console.WriteLine("Please enter the details of the bike");
            string brand = _validate.ValidateString("Enter the Bike Brand: ");
            string type = _validate.ValidateString("Enter the Bike Type");
            try
            {
                Bike newBike = new Bike(brand, type);
                Bike createdBike = _bikeBL.AddBike(newBike);
                Console.WriteLine("New bike created!");
                Console.WriteLine(createdBike.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetABike()
        {
            // List<Bike> bikes = _bikeBL.GetBike();
            // _bikeBL.GetBike();
            // Bike bikes = _bikeBL.GetBike();
            // if(bikes.Count == 0) Console.WriteLine("No Bikes");
            // else{
            //     foreach(Bike bike in bikes)
            //     {
            //         Console.WriteLine(bike.ToString());
            //     }
            // }
        }
        
    }
}