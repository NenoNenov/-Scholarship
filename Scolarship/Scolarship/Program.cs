using Scolarship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolarship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cotrollers.Scolarship scolarshipController = new Cotrollers.Scolarship();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
