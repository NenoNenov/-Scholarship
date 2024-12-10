using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project
{

    //Race Condition възниква, когато две или повече нишки достъпват и променят едновременно един и същ ресурс, което води до непредвидено поведение.
    class RaceConditionExample
    {
        private static int counter = 0;

        static void IncrementCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                counter++;
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final counter value: {counter}");
        }
    }

}
//Обяснение:
//При липса на синхронизация, counter може да има непредсказуема стойност, защото операциите за четене и запис върху него не са атомарни.
