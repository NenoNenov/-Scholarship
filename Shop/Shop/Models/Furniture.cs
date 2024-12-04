using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Furniture : Product
    {
        public string Material { get; set; }

        public Furniture(string name, double price, int quantity, string material)
            : base(name, price, quantity)
        {
            Material = material;
        }

        public override string ToString()
        {
            return $"Furniture: {Name}, Price: {Price}, Quantity: {Quantity}, Material: {Material}";
        }
    }

}
