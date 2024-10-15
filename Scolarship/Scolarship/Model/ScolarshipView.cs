using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolarship.Model
{
    public class ScolarshipView
    {
        private double income;
        public double Income
        {
            get { return this.income; }
            set { this.income = value; }
        }

        private double averageGrade;
        public double AverageGrade
        {
            get { return this.averageGrade; }
            set { this.averageGrade = value; }
        }

        private double minWage;
        public double MinWage
        {
            get { return this.minWage; }
            set { this.minWage = value; }
        }

        private string result;
        public string Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        public void CalculateScholarship()
        {
            decimal socialScholarship = 0;
            if (this.Income < this.MinWage && this.AverageGrade > 4.5)
            {
                socialScholarship = (decimal)Math.Floor(this.MinWage * 0.35);
            }

            decimal excellenceScholarship = 0;
            if (this.AverageGrade >= 5.5)
            {
                excellenceScholarship = (decimal)Math.Floor(this.AverageGrade * 25);
            }

            if (socialScholarship == 0 && excellenceScholarship == 0)
            {
                this.Result = $"You cannot get a scholarship!";
            }
            else if (socialScholarship > excellenceScholarship)
            {
                this.Result = $"You get a Social scholarship {socialScholarship} BGN";
            }
            else if (excellenceScholarship > socialScholarship)
            {
                this.Result = $"You get a scholarship for excellent results {excellenceScholarship} BGN";
            }
            else
            {
                this.Result = $"You get a scholarship for excellent results {excellenceScholarship} BGN";
            }
        }

        // Метод за валидиране на дохода
        public double GetValidatedIncome()
        {
            double income;
            do
            {
                Console.WriteLine("Enter your income (in BGN):");
                if (!double.TryParse(Console.ReadLine(), out income) || income < 0 || income > 6000)
                {
                    Console.WriteLine("Invalid input. Income should be a number between 0 and 6000.");
                }
                else
                {
                    break;
                }
            } while (true);

            return income;
        }

        // Метод за валидиране на средния успех
        public double GetValidatedAverageGrade()
        {
            double averageGrade;
            do
            {
                Console.WriteLine("Enter your average grade (between 2.00 and 6.00):");
                if (!double.TryParse(Console.ReadLine(), out averageGrade) || averageGrade < 2 || averageGrade > 6)
                {
                    Console.WriteLine("Invalid input. Grade should be a number between 2.00 and 6.00.");
                }
                else
                {
                    break;
                }
            } while (true);

            return averageGrade;
        }

        // Метод за валидиране на минималната работна заплата
        public double GetValidatedMinimumWage()
        {
            double minWage;
            do
            {
                Console.WriteLine("Enter the minimum wage (in BGN):");
                if (!double.TryParse(Console.ReadLine(), out minWage) || minWage < 0 || minWage > 1000)
                {
                    Console.WriteLine("Invalid input. Minimum wage should be a number between 0 and 1000.");
                }
                else
                {
                    break;
                }
            } while (true);

            return minWage;
        }
        public decimal GetSocialScolarship()
        {
            if (this.Income < this.MinWage && this.AverageGrade > 4.5)
            {
                return (decimal)Math.Floor(this.MinWage * 0.35);
            }
            return 0;
        }

        public decimal GetExcellentScolarship()
        {
            if (this.AverageGrade >= 5.5)
            {
                return (decimal)Math.Floor(this.AverageGrade * 25);
            }
            return 0;
        }

        // Вземане на входните данни с валидация
        public ScolarshipView GetInputData()
        {
            ScolarshipView model = new ScolarshipView();
            {
                model.Income = GetValidatedIncome();
                model.AverageGrade = GetValidatedAverageGrade();
                model.MinWage = GetValidatedMinimumWage();
            };

            return model;
        }
    }
}
