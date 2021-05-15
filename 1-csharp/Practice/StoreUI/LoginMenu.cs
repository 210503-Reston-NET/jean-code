using System;
using StoreDL;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class LoginMenu : IMenu
    {
        // private IMenu submenu;
        // public AdminMenu admin;
        public void StartMenu(){

            menu LoginMenu = new menu();
        
            AdminMenu admin = new AdminMenu();

            // CustMenu cust = new CustMenu();

            bool repeat = true;
            do{
                Console.WriteLine("[0] If you are a customer");
                Console.WriteLine("[1] If you are an admin");
                Console.WriteLine("[2] Go Back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        // cust.StartMenu();
                        Console.WriteLine("You are a Customer");
                        break;
                    case "1":
                        admin.StartMenu();
                        Console.WriteLine("Admin");
                        break;
                    case "2":
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid response");
                        break;
                } 
            }while (repeat);
        }
    }
}