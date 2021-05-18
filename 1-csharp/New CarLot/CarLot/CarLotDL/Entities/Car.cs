using System;
using System.Collections.Generic;

#nullable disable

namespace CarLotDL.Entities
{
    public partial class Car
    {
        public Car()
        {
            Descriptions = new HashSet<Description>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }
    }
}