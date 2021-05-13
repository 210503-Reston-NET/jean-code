using System;

namespace StoreUI
{
    public class LoginMenu
    {
        public void StartLogin(){

            menu LoginMenu = new menu();

            AdminMenu admin = new AdminMenu();

            bool repeat = true;
            do{
                Console.WriteLine("[0] If you are a customer");
                Console.WriteLine("[1] If you are an admin");
                Console.WriteLine("[2] Go Back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine("You are a Customer");
                        break;
                    case "1":
                        admin.StartMenu();
                        Console.WriteLine("Admin");
                        break;
                    case "2":
                        LoginMenu.StartMenu();
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid response");
                        break;
                } 
            }while (repeat);
        }
    }
}