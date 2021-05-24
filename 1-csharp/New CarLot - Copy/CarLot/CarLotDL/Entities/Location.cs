using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarLotDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Cars = new HashSet<Car>();
        }
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}