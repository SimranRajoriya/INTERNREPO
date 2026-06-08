using System;

namespace InventoryApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{Quantity},{Price}";
        }

        public static Product FromString(string data)
        {
            var parts = data.Split(',');
            return new Product
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Quantity = int.Parse(parts[2]),
                Price = double.Parse(parts[3])
            };
        }
    }
}