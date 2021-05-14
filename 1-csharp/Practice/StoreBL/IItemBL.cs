using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IItemBL
    {
        List<Item> GetAllItems();

        Item AddItem(Item item);
    }
}