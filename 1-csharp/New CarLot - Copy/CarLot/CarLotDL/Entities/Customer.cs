using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarLotDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            this.Id = Id;
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }
        // public virtual Customer customer{get;set;}
        

    }
}