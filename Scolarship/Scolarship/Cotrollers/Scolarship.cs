using Scolarship.Model;
using Scolarship.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolarship.Cotrollers
{
    public class Scolarship
    {
        Display disp = new Display();
        ScolarshipView myScol = new ScolarshipView();
        public Scolarship()
        {
            disp.Input();

            myScol.Income = disp.Income;
            myScol.AverageGrade = disp.AverageGrade;
            myScol.MinWage = disp.MinWage;

            decimal socialScholarship = myScol.GetSocialScolarship();
            decimal excellentScholarship = myScol.GetExcellentScolarship();

            if (socialScholarship == 0 && excellentScholarship == 0)
            {
                disp.DisplayResult("You cannot get a scholarship!");
            }
            else if (socialScholarship > excellentScholarship)
            {
                disp.DisplayResult($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                disp.DisplayResult($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
        }
    }
}
