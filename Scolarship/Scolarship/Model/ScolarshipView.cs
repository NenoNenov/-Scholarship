using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolarship.Model
{
    public class ScolarshipView
    {
        public double Income { get; set; }
        public double AverageGrade { get; set; }
        public double MinWage { get; set; }

        // Изчислява социалната стипендия
        public decimal CalculateSocialScholarship()
        {
            return (Income < MinWage && AverageGrade > 4.5) ? (decimal)(MinWage * 0.35) : 0;
        }

        // Изчислява стипендия за отличен успех
        public decimal CalculateExcellenceScholarship()
        {
            return (AverageGrade >= 5.5) ? (decimal)(AverageGrade * 25) : 0;
        }
    }
}
