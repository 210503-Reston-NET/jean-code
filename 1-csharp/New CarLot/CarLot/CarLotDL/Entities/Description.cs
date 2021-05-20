using System;
using System.Collections.Generic;

#nullable disable

namespace CarLotDL.Entities
{
    public partial class Description
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public int Mpg { get; set; }
        public int Price { get; set; }


        public virtual Car Car { get; set; }
    }
}