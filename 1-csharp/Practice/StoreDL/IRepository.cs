using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public interface IRepository
    {
        List<Item> GetAllItems();

        Item AddItem(Item item);

        Item ViewBike(Item item);

        // List<Cust> GetAllCusts();

        // Cust AddCust(Cust cust);

        Cust GetCust(Cust cust);
    }
}