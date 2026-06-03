using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InventoryApp
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        private string filePath = "data.txt";

        public ProductService()
        {
            LoadData();
        }

        // CREATE
        public void AddProduct(Product p)
        {
            products.Add(p);
            SaveData();
        }

        // READ ALL
        public List<Product> GetAll()
        {
            return products;
        }

        // SEARCH BY NAME
        public List<Product> SearchByName(string name)
        {
            return products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        // UPDATE
        public bool UpdateProduct(int id, Product updated)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) return false;

            p.Name = updated.Name;
            p.Quantity = updated.Quantity;
            p.Price = updated.Price;

            SaveData();
            return true;
        }

        // DELETE
        public bool DeleteProduct(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) return false;

            products.Remove(p);
            SaveData();
            return true;
        }

        // SAVE FILE
        private void SaveData()
        {
            File.WriteAllLines(filePath, products.Select(p => p.ToString()));
        }

        // LOAD FILE
        private void LoadData()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    products = lines.Select(Product.FromString).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
        }
    }
}