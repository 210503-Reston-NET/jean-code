using System;
using StoreModels;
using System.Collections.Generic;


namespace StoreUI
{
    public class CustMenu
    {
        public void StartMenu(){

            menu LoginMenu = new menu();


            bool repeat = true;

            do{
            Console.WriteLine("[0] Browse Bikes");
            Console.WriteLine("[1] Go Back");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    // Console.WriteLine(Miami.ToString());
                    break;
                case "1":
                    LoginMenu.StartMenu();
                    break;
                default:
                    break;
            }
            }while(repeat);
        }
    }
}


                