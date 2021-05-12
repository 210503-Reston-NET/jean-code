using System;

namespace PlayGround
{
    public class menu
    {
        public void StartMenu()
        {
            LoginMenu LoginMenu = new LoginMenu();
            bool repeat = true;
            do{
            Console.WriteLine("Menu");
            Console.WriteLine("Welcome to my Bike Shop");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] CRUD LOGIN");
            Console.WriteLine("[1] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Console.WriteLine("Case 0");
                    LoginMenu.StartLogin();
                    break;
                case "1":
                    Console.WriteLine("Thank you for visiting my Bike Shop");
                    repeat = false;
                    break;
                default:
                    //invalid input
                    Console.WriteLine("Please input a valid option");
                    break;
            }
        } while (repeat);
    }
}
}
