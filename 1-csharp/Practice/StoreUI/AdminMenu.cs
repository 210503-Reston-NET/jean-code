using System;

namespace StoreUI
{
    public class AdminMenu
    {
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
    }
}