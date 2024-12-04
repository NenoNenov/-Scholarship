using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Name}, Price: {Price}, Quantity: {Quantity}");
        }

        public double TotalPrice()
        {
            return Price * Quantity;
        }
    }
}
