using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Clothing : Product
    {
        public string Size { get; set; }

        public Clothing(string name, double price, int quantity, string size)
            : base(name, price, quantity)
        {
            Size = size;
        }

        public override string ToString()
        {
            return $"Clothing: {Name}, Price: {Price}, Quantity: {Quantity}, Size: {Size}";
        }
    }

}
