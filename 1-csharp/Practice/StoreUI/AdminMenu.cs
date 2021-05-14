using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class AdminMenu
    {
        private IItemBL _itemBL;
        private IValidationService _validate;
        public void StartMenu(){

            menu LoginMenu = new menu();

            LoginMenu Menu = new LoginMenu();

            bool repeat = true;
            do{
                System.Console.WriteLine("[0] Add item to inventory");
                System.Console.WriteLine("[1] Remove item from inventory");
                System.Console.WriteLine("[2] Go Back");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "0":
                        System.Console.WriteLine("Add Item");
                        break;
                    case "1":
                        System.Console.WriteLine("Remove Item");
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        Menu.StartLogin();
                        break;
                    default:
                        break;
                }
            }while(repeat);
        }

        private void AddBike()
        {
            Console.WriteLine("Please enter the details of the bike you want to add");
            string bikeBrand = _validate.ValidateString("Enter the bike BRAND");
            string bikeType = _validate.ValidateString("Enter the bike TYPE");
            try
            {
                Item newBike = new Item(bikeBrand, bikeType);
                Item createdBike = _itemBL.AddItem(newBike);
                System.Console.WriteLine("New Item Created!");
                System.Console.WriteLine(createdBike.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}