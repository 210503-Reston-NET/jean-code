using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarLotDL.Entities
{
    public partial class Car
    {
        public Car()
        {
            Descriptions = new HashSet<Description>();
        }

        [Key]
        public int InventoryId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<Location> locations { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }
    }
}