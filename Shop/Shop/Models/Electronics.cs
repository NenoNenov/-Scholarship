using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Electronics : Product
    {
        public int Warranty { get; set; }

        public Electronics(string name, double price, int quantity, int warranty)
            : base(name, price, quantity)
        {
            Warranty = warranty;
        }

        public override string ToString()
        {
            return $"Electronics: {Name}, Price: {Price}, Quantity: {Quantity}, Warranty: {Warranty} months";
        }
    }

}
