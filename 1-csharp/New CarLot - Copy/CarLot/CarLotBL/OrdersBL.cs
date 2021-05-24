using System;
using System.Collections.Generic;
using CarLotModels;
using CarLotDL;

namespace CarLotBL
{
    public class OrdersBL : IOrdersBL
    {
        private IRepository _repo;
        public OrdersBL(IRepository repo)
        {
            _repo = repo;
        }
        // public Orders AddOrder(Orders orders, Car car, Location location, Customer customer)
        // {
        //     _repo.AddOrder(orders, car, location, customer);
        //     return orders;
        // }
    }
}