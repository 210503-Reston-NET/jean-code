using System;
namespace CarLotUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuFactory.GetMenu("login").Start();
        }
    }
}
