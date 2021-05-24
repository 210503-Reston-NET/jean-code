using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarLotDL.Entities
{
    public partial class Orders
    {
        public Orders(){

        }
        public Orders(int orderId, int orderDate, int carId, int locationId, int customerId){
            this.CustomerId = customerId;
            this.LocationId = locationId;
            this.CarId = carId;
            this.OrderDate = orderDate;
            this.OrderId = orderId;
        }
        [Key]
        public int OrderId{get;set;}
        public int OrderDate{get;set;}
        public int CustomerId{get;set;}
        public int LocationId{get;set;}
        public int CarId{get;set;}
    }
}