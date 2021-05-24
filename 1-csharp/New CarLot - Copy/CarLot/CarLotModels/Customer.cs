using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarLotModels
{
    public class Customer
    {
        // private string _lastName;

        public Customer(string firstName, string lastName, int pin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Pin = Pin; 
        }
        public Customer()
        {

        }
        public Customer(int id, string firstName, string lastName, int pin) : this(firstName, lastName, pin)
        {
            this.Id = id;
        }
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public int Pin{get;set;}

        public override string ToString()
        {
            return  $" First Name: {FirstName} \n Last Name: {LastName} \n Pin: ****";
        }
        public bool Equals(Customer customer)
        {
            return this.FirstName.Equals(customer.FirstName) && this.LastName.Equals(customer.LastName) && this.Pin.Equals(customer.Pin);
        }

    }
}