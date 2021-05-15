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

        // public List<Item> ViewBike(Item item)
        // {
        //     return StoreStorage.Items;
        // }

        public List<Item> ViewBike()
        {
            return StoreStorage.Items;
        }


        public Item ViewBike(Item item)
        {
            return StoreStorage.Items.FirstOrDefault(resto => resto.Equals(item));
        }



        public Cust AddCust(Cust cust)
        {
            StoreStorage.Custs.Add(cust);
            return cust;
        }
        public List<Cust> GetAllCusts()
        {
            return StoreStorage.Custs;
        }

        public Cust GetCust(Cust cust)
        {
            return StoreStorage.Custs.FirstOrDefault(resto => resto.Equals(cust));
        }
    }
}