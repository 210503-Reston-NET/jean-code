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

        private const string filePath = "../StoreDL/Items.json";

        private string jsonString;
        public Item AddItem(Item item)
        {
            List<Item> itemsFromFile = GetAllItems();
            itemsFromFile.Add(item);
            jsonString = JsonSerializer.Serialize(itemsFromFile);
            File.WriteAllText(filePath, jsonString);
            return item;
        }

        public List<Item> GetAllItems()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
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
    }
}