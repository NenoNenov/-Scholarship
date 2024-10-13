using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.View
{
    public class ScholarshipView
    {
        private decimal GetValidatedIncome()
        {
            decimal income;
            do
            {
                Console.WriteLine("Enter your income (in BGN):");
                if (!decimal.TryParse(Console.ReadLine(), out income) || income < 0 || income > 6000)
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

        // Метод за въвеждане и валидация на среден успех
        private decimal GetValidatedAverageGrade()
        {
            decimal averageGrade;
            do
            {
                Console.WriteLine("Enter your average grade (between 2.00 and 6.00):");
                if (!decimal.TryParse(Console.ReadLine(), out averageGrade) || averageGrade < 2 || averageGrade > 6)
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

        // Метод за въвеждане и валидация на минимална заплата
        private decimal GetValidatedMinimumWage()
        {
            decimal minimumWage;
            do
            {
                Console.WriteLine("Enter the minimum wage (in BGN):");
                if (!decimal.TryParse(Console.ReadLine(), out minimumWage) || minimumWage < 0 || minimumWage > 1000)
                {
                    Console.WriteLine("Invalid input. Minimum wage should be a number between 0 and 1000.");
                }
                else
                {
                    break;
                }
            } while (true);

            return minimumWage;
        }

        // Основен метод за събиране на всички входни данни
        public ScholarshipViewModel GetInputData()
        {
            ScholarshipViewModel model = new ScholarshipViewModel
            {
                Income = GetValidatedIncome(),
                AverageGrade = GetValidatedAverageGrade(),
                MinimumWage = GetValidatedMinimumWage()
            };

            return model;
        }

        // Метод за показване на резултата
        public void DisplayResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
