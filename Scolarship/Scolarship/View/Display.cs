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
        public decimal SocialScholarship { get; set; }
        public decimal ExcellenceScholarship { get; set; }

        // Въвеждане на входни данни
        public void Input()
        {
            Console.Write("Въведи доход: ");
            Income = double.Parse(Console.ReadLine());

            Console.Write("Въведи среден успех: ");
            AverageGrade = double.Parse(Console.ReadLine());

            Console.Write("Въведи минимална работна заплата: ");
            MinWage = double.Parse(Console.ReadLine());
        }

        // Показване на резултатите
        public void Output()
        {
            if (SocialScholarship == 0 && ExcellenceScholarship == 0)
            {
                Console.WriteLine("Не можете да получите стипендия!");
            }
            else if (SocialScholarship > ExcellenceScholarship)
            {
                Console.WriteLine($"Получавате социална стипендия в размер на {SocialScholarship} лв.");
            }
            else
            {
                Console.WriteLine($"Получавате стипендия за отличен успех в размер на {ExcellenceScholarship} лв.");
            }
        }
    }
}
