using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public class StoreStorage
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item("Cannondale", "Hybrid")
        };
        public static List<Cust> Custs = new List<Cust>()
        {
            new Cust("John", "Doe", "Empty")
        };
    }
}