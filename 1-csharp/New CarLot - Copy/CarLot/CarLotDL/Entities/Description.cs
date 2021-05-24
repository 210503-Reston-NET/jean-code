using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace CarLotDL.Entities
{
    public partial class Description
    {
        [Key]
        public int Id { get; set; }
        public string Rating { get; set; }
        public int Mpg { get; set; }
        public int Price { get; set; }
        public int InventoryId { get; set; }
        public virtual Car Car { get; set; }
    }
}