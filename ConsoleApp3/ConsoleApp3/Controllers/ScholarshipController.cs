using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Controllers
{
    public class ScholarshipController
    {
        public void CalculateScholarship(ScholarshipViewModel model)
        {
            // Изчисляване на социална стипендия
            decimal socialScholarship = 0;
            if (model.Income < model.MinimumWage && model.AverageGrade > 4.5m)
            {
                socialScholarship = Math.Floor(model.MinimumWage * 0.35m); // 35% от минималната заплата
            }

            // Изчисляване на стипендия за отличен успех
            decimal excellenceScholarship = 0;
            if (model.AverageGrade >= 5.5m)
            {
                excellenceScholarship = Math.Floor(model.AverageGrade * 25);
            }

            // Определяне на резултата
            if (socialScholarship == 0 && excellenceScholarship == 0)
            {
                model.Result = "You cannot get a scholarship!";
            }
            else if (socialScholarship > excellenceScholarship)
            {
                model.Result = $"You get a Social scholarship {socialScholarship} BGN";
            }
            else if (excellenceScholarship > socialScholarship)
            {
                model.Result = $"You get a scholarship for excellent results {excellenceScholarship} BGN";
            }
            else
            {
                model.Result = $"You get a scholarship for excellent results {excellenceScholarship} BGN";
            }
        }
    }
}
