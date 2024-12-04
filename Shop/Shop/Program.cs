using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Controllers;
using Shop.Views;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Създаване на MVC компонентите
            View view = new View();
            ShoppingList<Product> list = new ShoppingList<Product>();
            Controller controller = new Controller(view, list);

            // Добавяне на продукти
            Product foodProduct = new Food("Apple", 1.20, 5, "01/2025");
            Product electronicsProduct = new Electronics("Laptop", 1000.00, 1, 24);
            Product clothingProduct = new Clothing("T-shirt", 15.99, 3, "M");
            Product furnitureProduct = new Furniture("Chair", 75.50, 2, "Wood");

            list.AddProduct(foodProduct);
            list.AddProduct(electronicsProduct);
            list.AddProduct(clothingProduct);
            list.AddProduct(furnitureProduct);

            // Стартиране на програмата
            controller.Run();
        }
    }
}
