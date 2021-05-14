using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;

namespace StoreBL
{
    public class ItemBL : IItemBL
    {
        private IRepository _repo;

        public ItemBL(IRepository repo)
        {
            _repo = repo;
        }

        public Item AddItem(Item item)
        {
            if(_repo.GetItem(item)!=null)
            {
                throw new Exception("Bike already exists");
            }
            return _repo.AddItem(item);
        }
        public List<Item> GetAllItems()
        {
            //Note that this method isn't really dependent on any inputs/parameters, I can just directly call the 
            // DL method in charge of getting all restaurants
            return _repo.GetAllItems();
        }        
    }
}