using System;
using System.Collections.Generic;

namespace CarLotDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}