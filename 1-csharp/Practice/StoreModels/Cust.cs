using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StoreModels
{
    public class Cust
    {
        public string _name;

        public Cust(string firstName, string lastName, string cart)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Cart = cart;
        }
        public Cust()
        {

        }
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Cart{get;set;}

        public override string ToString()
        {
            return $" First Name: {FirstName} \n Last Name: {LastName} \n Cart: {Cart}";
        }

        public bool Equals(Cust cust)
        {
            return this.FirstName.Equals(cust.FirstName) && this.LastName.Equals(cust.LastName) && this.Cart.Equals(cust.Cart);
        }
    }
}