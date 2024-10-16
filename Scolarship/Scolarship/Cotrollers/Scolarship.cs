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
        Display myDisp = new Display();
        ScolarshipView myScol = new ScolarshipView();

        public Scolarship()
        {
            // Вход на данни чрез дисплея
            myDisp.Input();

            // Попълване на модела със стойности от дисплея
            myScol.Income = myDisp.Income;
            myScol.AverageGrade = myDisp.AverageGrade;
            myScol.MinWage = myDisp.MinWage;

            // Изчисления
            myDisp.SocialScholarship = myScol.CalculateSocialScholarship();
            myDisp.ExcellenceScholarship = myScol.CalculateExcellenceScholarship();

            // Изход (показване на резултат)
            myDisp.Output();
        }
    }
}
