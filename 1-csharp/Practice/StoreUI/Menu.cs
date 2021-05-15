using System;
using StoreModels;
using StoreBL;
using StoreDL;

namespace StoreUI
{
    public class menu : IMenu
    {
        private IMenu submenu;
        public void StartMenu()
        {
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
                    submenu = UserFactory.GetMenu("login");
                    submenu.StartMenu();
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
