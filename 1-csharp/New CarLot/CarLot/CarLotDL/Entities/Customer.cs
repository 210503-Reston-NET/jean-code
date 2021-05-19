using System;
using System.Collections.Generic;

namespace CarLotDL.Entities
{
    public class Customer
    {
        public Customer()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public virtual Customer customer{get;set;}
        

    }
}