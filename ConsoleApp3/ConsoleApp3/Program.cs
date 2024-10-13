using ConsoleApp3.Controllers;
using ConsoleApp3.Models;
using ConsoleApp3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Създаваме изгледа и контролера
            ScholarshipView view = new ScholarshipView();
            ScholarshipController controller = new ScholarshipController();

            // Взимаме данни от потребителя чрез изгледа
            ScholarshipViewModel model = view.GetInputData();

            // Изчисляваме стипендията чрез контролера
            controller.CalculateScholarship(model);

            // Показваме резултата на потребителя
            view.DisplayResult(model.Result);

            // Добавяме пауза, за да задържим конзолата от затваряне
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
