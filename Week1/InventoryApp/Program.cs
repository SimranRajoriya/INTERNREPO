

using System;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService();

            while (true)
            {
                Console.WriteLine("\n===== INVENTORY MENU =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Id: ");
                            int id = int.TryParse(Console.ReadLine(), out id) ? id : 0;

                            Console.Write("Name: ");
                            string name = Console.ReadLine() ?? "";

                            Console.Write("Quantity: ");
                            int qty = int.TryParse(Console.ReadLine(), out qty) ? qty : 0;

                            Console.Write("Price: ");
                            double price = double.TryParse(Console.ReadLine(), out price) ? price : 0;

                            service.AddProduct(new Product
                            {
                                Id = id,
                                Name = name,
                                Quantity = qty,
                                Price = price
                            });

                            Console.WriteLine("Product Added!");
                            break;

                        case 2:
                            var products = service.GetAll();
                            if (products.Count == 0)
                            {
                                Console.WriteLine("No products found.");
                            }
                            else
                            {
                                foreach (var p in products)
                                    Console.WriteLine(p);
                            }
                            break;

                        case 3:
                            Console.Write("Enter Name: ");
                            string search = Console.ReadLine() ?? "";

                            var results = service.SearchByName(search);
                            if (results.Count == 0)
                                Console.WriteLine("No match found.");
                            else
                                foreach (var p in results)
                                    Console.WriteLine(p);
                            break;

                        case 4:
                            Console.Write("Enter ID to update: ");
                            int uid = int.TryParse(Console.ReadLine(), out uid) ? uid : 0;

                            Console.Write("New Name: ");
                            string n = Console.ReadLine() ?? "";

                            Console.Write("New Quantity: ");
                            int q = int.TryParse(Console.ReadLine(), out q) ? q : 0;

                            Console.Write("New Price: ");
                            double pr = double.TryParse(Console.ReadLine(), out pr) ? pr : 0;

                            bool updated = service.UpdateProduct(uid, new Product
                            {
                                Id = uid,
                                Name = n,
                                Quantity = q,
                                Price = pr
                            });

                            Console.WriteLine(updated ? "Updated!" : "Not Found!");
                            break;

                        case 5:
                            Console.Write("Enter ID to delete: ");
                            int did = int.TryParse(Console.ReadLine(), out did) ? did : 0;

                            bool deleted = service.DeleteProduct(did);
                            Console.WriteLine(deleted ? "Deleted!" : "Not Found!");
                            break;

                        case 6:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
