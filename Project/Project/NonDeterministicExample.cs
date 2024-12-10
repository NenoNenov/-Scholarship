using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    //Поради паралелното изпълнение, редът на изпълнение
    //на нишките не е гарантиран, което може да доведе до различни резултати при всяко стартиране. 
    class NonDeterministicExample
    {
        static void PrintNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(PrintNumbers) { Name = "Thread1" };
            Thread thread2 = new Thread(PrintNumbers) { Name = "Thread2" };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
    }

}
//Обяснение:
//Редът на изпълнение между нишките Thread1 и Thread2 е случаен при всяко стартиране.