using System.Collections.Generic;
using CarLotModels;

namespace CarLotBL
{
    public interface ICustomerBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);
        Customer DeleteCustomer(Customer customer);
    }
}