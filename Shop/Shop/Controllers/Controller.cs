using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Controllers;
using Shop.Views;
namespace Shop.Controllers
{
    public class Controller
    {
        private View _view;
        private ShoppingList<Product> _list;

        public Controller(View view, ShoppingList<Product> list)
        {
            _view = view;
            _list = list;
        }

        public void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                _view.ShowMainMenu();
                string selectedOption = Console.ReadLine();

                switch (selectedOption)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        _view.ShowProducts(_list);
                        break;
                    case "4":
                        double totalPrice = _list.TotalPrice();
                        _view.ShowTotalPrice(totalPrice);
                        break;
                    case "5":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            // Въвеждане на данни за нов продукт
            Console.WriteLine("Enter product type (Food, Electronics, Clothing, Furniture):");
            string productType = Console.ReadLine().ToLower();

            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter product price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter product quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (productType == "food")
            {
                Console.WriteLine("Enter expiry date (MM/YYYY):");
                string expiryDate = Console.ReadLine();
                Product product = new Food(name, price, quantity, expiryDate);
                _list.AddProduct(product);   // Добавяне на продукта към списъка
            }
            else if (productType == "electronics")
            {
                Console.WriteLine("Enter warranty (months):");
                int warranty = Convert.ToInt32(Console.ReadLine());
                Product product = new Electronics(name, price, quantity, warranty);
                _list.AddProduct(product);
            }
            else if (productType == "clothing")
            {
                Console.WriteLine("Enter size:");
                string size = Console.ReadLine();
                Product product = new Clothing(name, price, quantity, size);
                _list.AddProduct(product);
            }
            else if (productType == "furniture")
            {
                Console.WriteLine("Enter material:");
                string material = Console.ReadLine();
                Product product = new Furniture(name, price, quantity, material);
                _list.AddProduct(product);
            }
            else
            {
                Console.WriteLine("Invalid product type.");
            }
        }

        private void RemoveProduct()
        {
            Console.WriteLine("Enter the name of the product to remove:");
            string nameToRemove = Console.ReadLine();

            // Търсене на продукта в списъка
            Product productToRemove = _list.GetProductByName(nameToRemove);
            if (productToRemove != null)
            {
                _list.RemoveProduct(productToRemove);  // Премахване на продукта
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}

