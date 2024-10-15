using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolarship.View
{
    public class Display
    {
        public double Income { get; set; }
        public double AverageGrade { get; set; }
        public double MinWage { get; set; }

        public void Input()
        {
            Console.Write("Въведи доход: ");
            Income = double.Parse(Console.ReadLine());

            Console.Write("Въведи среден успех: ");
            AverageGrade = double.Parse(Console.ReadLine());

            Console.Write("Въведи минимална работна заплата: ");
            MinWage = double.Parse(Console.ReadLine());
        }

        public void DisplayResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
