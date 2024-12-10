using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project
{
    //При Priority Inversion нископриоритетна нишка блокира
    //високоприоритетна, защото е заключила ресурс, който високоприоритетната нишка чака.

    class PriorityInversionExample
    {
        static readonly object lockObj = new object();

        static void HighPriorityTask()
        {
            lock (lockObj)
            {
                Console.WriteLine("High-priority thread waiting for resource...");
                Thread.Sleep(1000); // Изчаква освобождаване на ресурса
            }
        }

        static void LowPriorityTask()
        {
            lock (lockObj)
            {
                Console.WriteLine("Low-priority thread working...");
                Thread.Sleep(2000); // Държи ресурса дълго време
            }
        }

        static void MediumPriorityTask()
        {
            Console.WriteLine("Medium-priority thread working...");
            Thread.Sleep(1500);
        }

        static void Main(string[] args)
        {
            Thread highPriorityThread = new Thread(HighPriorityTask);
            Thread lowPriorityThread = new Thread(LowPriorityTask);
            Thread mediumPriorityThread = new Thread(MediumPriorityTask);

            lowPriorityThread.Priority = ThreadPriority.Lowest;
            highPriorityThread.Priority = ThreadPriority.Highest;

            lowPriorityThread.Start();
            Thread.Sleep(100); // Уверява се, че LowPriority започва първо
            highPriorityThread.Start();
            mediumPriorityThread.Start();

            lowPriorityThread.Join();
            highPriorityThread.Join();
            mediumPriorityThread.Join();
        }
    }

}
//Обяснение:
//Нископриоритетната нишка държи ресурса, блокирайки високоприоритетната нишка. Средноприоритетната нишка може да влоши проблема.
