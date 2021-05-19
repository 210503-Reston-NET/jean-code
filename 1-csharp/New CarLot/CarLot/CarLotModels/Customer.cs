using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarLotModels
{
    public class Customer
    {
        // private string _lastName;

        public Customer(string firstName, string lastName, int phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone; 
        }
        public Customer()
        {

        }
        public Customer(int id, string firstName, string lastName, int phone) : this(firstName, lastName, phone)
        {
            this.Id = id;
        }
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public int Phone{get;set;}

        public override string ToString()
        {
            return  $" First Name: {FirstName} \n Last Name: {LastName} \n Phone: {Phone}";
        }
        public bool Equals(Customer customer)
        {
            return this.FirstName.Equals(customer.FirstName) && this.LastName.Equals(customer.LastName) && this.Phone.Equals(customer.Phone);
        }

    }
}