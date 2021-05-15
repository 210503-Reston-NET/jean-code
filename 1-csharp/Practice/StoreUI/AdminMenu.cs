using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class AdminMenu : IMenu
    {
        private IItemBL _itemBL;

        private ICustBL _icustBL;

        private IValidationService _validate;

        // public AdminMenu(IItemBL itemBL, IValidationService validate)
        // {
        //     _itemBL = itemBL;
        //     _validate = validate;
        // }
        public void StartMenu(){

            // menu LoginMenu = new menu();

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
                        // AddItem();
                        break;
                    case "1":
                        System.Console.WriteLine("Remove Item");
                        break;
                    case "2":
                        ViewItems();
                        System.Console.WriteLine("View Inventory");
                        break;
                    case "3":
                        // GetAllCusts();
                        System.Console.WriteLine("View all customers");
                        break;
                    case "4":
                        System.Console.WriteLine("Go Back");
                        Menu.StartMenu();
                        break;
                    default:
                        break;
                }
            }while(repeat);
        }

        // private void AddItem()
        // {
        //     Console.WriteLine("Please enter the details of the bike you want to add");
        //     string bikeBrand = _validate.ValidateString("Enter the bike BRAND");
        //     string bikeType = _validate.ValidateString("Enter the bike TYPE");
        //     try
        //     {
        //         Item newItem = new Item(bikeBrand, bikeType);
        //         Item createdItem = _itemBL.AddItem(newItem);
        //         System.Console.WriteLine("New Item Created!");
        //         System.Console.WriteLine(createdItem.ToString());
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        // }
        private void ViewItems()
        {
            System.Console.WriteLine("Hi");
            List<Item> items = _itemBL.ViewBike();
            if(items.Count == 0) Console.WriteLine("No Items");
            else{
                foreach(Item item in items)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }
        // private void GetAllCusts()
        // {
        //     System.Console.WriteLine(ICustBL.GetAllCusts);
        // }
    }
}