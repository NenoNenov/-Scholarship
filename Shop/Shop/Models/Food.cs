using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Food : Product
    {
        public string ExpiryDate { get; set; }

        public Food(string name, double price, int quantity, string expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return $"Food: {Name}, Price: {Price}, Quantity: {Quantity}, Expiry Date: {ExpiryDate}";
        }
    }

}
