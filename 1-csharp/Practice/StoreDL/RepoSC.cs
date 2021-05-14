using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class RepoSC : IRepository
    {
        public Item AddItem(Item item)
        {
            StoreStorage.Items.Add(item);
            return item;
        }
        public List<Item> GetAllItems()
        {
            return StoreStorage.Items;
        }

        public Item GetItem(Item item)
        {
            return StoreStorage.Items.FirstOrDefault(resto => resto.Equals(item));
        }
    }
}