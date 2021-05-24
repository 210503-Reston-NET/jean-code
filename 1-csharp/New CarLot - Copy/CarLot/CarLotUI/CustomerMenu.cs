using CarLotModels;
using CarLotBL;
using System.Collections.Generic;

using System;


namespace CarLotUI
{
    public class CustomerMenu : IMenu
    {
        private IMenu submenu;
        private ICustomerBL _customerBL;
        private ICarBL _carBL;
        private IValidationService _validate;
        public CustomerMenu(ICustomerBL customerBL, IValidationService validate)
        {
            _customerBL = customerBL;
            _validate = validate;
        }
        public void Start(){
            bool repeat = true;
            do
            {
                System.Console.WriteLine("[0] Create a new account");
                System.Console.WriteLine("[1] Login");
                System.Console.WriteLine("[2] Go Back");
                string input = System.Console.ReadLine();
                switch(input)
                {
                    case "0":
                        AddCustomer();
                        break;
                    case "1":
                        submenu = MenuFactory.GetMenu("customertwo");
                        submenu.Start();
                        System.Console.WriteLine("Login");
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }while(repeat);
        }
        private void AddCustomer()
        {
            string firstName = _validate.ValidateString("Enter your first name: ");
            string lastName = _validate.ValidateString("Enter your last name: ");
            int pin = _validate.ValidateInt("Enter your pin: ");
            try
            {
                Customer newCustomer = new Customer(firstName, lastName, pin);
                Customer createdCustomer = _customerBL.AddCustomer(newCustomer);
                Console.WriteLine("New customer created!");
                Console.WriteLine(createdCustomer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
