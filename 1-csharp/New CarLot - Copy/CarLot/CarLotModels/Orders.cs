using System;
namespace CarLotModels
{
    public class Orders
    {

        public Orders(){

        }
        public Orders(int orderId, int orderDate, int carId, int locationId, int customerId){
            this.CustomerId = customerId;
            this.LocationId = locationId;
            // this.CarId = carId;
            this.OrderDate = orderDate;
            this.OrderId = orderId;
        }
        public int OrderId{get;set;}
        public int OrderDate{get;set;}
        public int CustomerId{get;set;}
        public int LocationId{get;set;}
        public int InventoryId{get;set;}

        public override string ToString()
        {
            return $"\t OrderId: {OrderId} \n\t CustomerId: {CustomerId} \n\t LocationId: {LocationId} \n\t InventoryId: {InventoryId} \n\t Order Date: {OrderDate}";
        }
    }
}