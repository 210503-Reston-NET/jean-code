using System;

namespace CarLotUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // MainMenu Menu = new MainMenu();
            // Menu.MainStart();
            MenuFactory.GetMenu("login").Start();
        }
    }
}
