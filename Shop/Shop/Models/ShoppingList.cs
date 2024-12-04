using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShoppingList<T> where T : Product
    {
        private List<T> products = new List<T>();

        // Метод за добавяне на продукт
        public void AddProduct(T product)
        {
            products.Add(product);
            Console.WriteLine($"{product.Name} has been added to the shopping list.");
        }

        // Метод за премахване на продукт
        public void RemoveProduct(T product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
                Console.WriteLine($"{product.Name} has been removed from the shopping list.");
            }
            else
            {
                Console.WriteLine($"{product.Name} is not in the shopping list.");
            }
        }

        // Метод за получаване на продукт по име
        public T GetProductByName(string name)
        {
            return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Метод за показване на всички продукти
        public void ShowProducts()
        {
            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No products in the shopping list.");
            }
        }

        // Метод за изчисляване на общата цена
        public double TotalPrice()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }
        public IEnumerable<T> GetAllProducts()
        {
            return products;
        }
    }
}
