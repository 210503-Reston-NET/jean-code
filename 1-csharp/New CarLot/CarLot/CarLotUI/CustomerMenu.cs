using CarLotModels;
using CarLotBL;
using System.Collections.Generic;

using System;


namespace CarLotUI
{
    public class CustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;


        private IValidationService _validate;



        public CustomerMenu(ICustomerBL customerBL, IValidationService validate)
        {
            _customerBL = customerBL;
            _validate = validate;
        }
        public void Start(){
            bool repeat = true;
            // string Pin = "1111";
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
                        System.Console.WriteLine("Create new account");
                        break;
                    case "1":
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
            int phone = _validate.ValidateInt("Enter your phone number: ");
            try
            {
                Customer newCustomer = new Customer(firstName, lastName, phone);
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
