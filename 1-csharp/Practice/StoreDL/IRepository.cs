using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public interface IRepository
    {
         List<Item> GetAllItems();

         Item AddItem(Item item);

         Item GetItem(Item item);
    }
}