using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Views
{
    public class View
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Calculate Total Price");
            Console.WriteLine("5. Exit");
        }

        public void ShowProducts(ShoppingList<Product> list)
        {
            Console.WriteLine("Products in the list:");
            list.ShowProducts();
        }

        public void ShowTotalPrice(double totalPrice)
        {
            Console.WriteLine($"Total price of products: {totalPrice}");
        }
    }
}
