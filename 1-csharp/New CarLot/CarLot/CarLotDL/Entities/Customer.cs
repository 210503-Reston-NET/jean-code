using System;
using System.Collections.Generic;

namespace CarLotDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            this.Id = Id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }
        // public virtual Customer customer{get;set;}
        

    }
}