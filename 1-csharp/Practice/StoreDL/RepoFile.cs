using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace StoreDL
{
    public class RepoFile : IRepository
    {

        private const string itemPath = "../StoreDL/Items.json";
        private const string custPath = "../StoreDL/custs.json";


        private string jsonString;
        public Item AddItem(Item item)
        {
            
            List<Item> itemsFromFile = GetAllItems();
            itemsFromFile.Add(item);
            jsonString = JsonSerializer.Serialize(itemsFromFile);
            File.WriteAllText(itemPath, jsonString);
            return item;
        }
        public Item ViewBike(Item item)
        {
            return item;
        }

        public List<Item> GetAllItems()
        {
            try
            {
                jsonString = File.ReadAllText(itemPath);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new List<Item>();
            }
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
        }

        public Item GetItem(Item item)
        {
            return GetAllItems().FirstOrDefault(resto => resto.Equals(item));
        }


        public Cust AddCust(Cust cust)
        {
            List<Cust> custsFromFile = GetAllCusts();
            custsFromFile.Add(cust);
            jsonString = JsonSerializer.Serialize(custsFromFile);
            File.WriteAllText(custPath, jsonString);
            return cust;
        }

        public List<Cust> GetAllCusts()
        {
            try
            {
                jsonString = File.ReadAllText(custPath);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new List<Cust>();
            }
            return JsonSerializer.Deserialize<List<Cust>>(jsonString);
        }

        public Cust GetCust(Cust cust)
        {
            return GetAllCusts().FirstOrDefault(resto => resto.Equals(cust));
        }
    }
}