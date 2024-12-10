using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project
{
    //Starvation възниква, когато дадена нишка никога не
    //получава достъп до ресурс, защото други нишки с по-висок
    //приоритет или по-добър достъп до ресурса постоянно я изпреварват.

    class StarvationExample
    {
        static readonly object lockObj = new object();

        static void HighPriorityTask()
        {
            while (true)
            {
                lock (lockObj)
                {
                    Console.WriteLine("High-priority thread working...");
                    Thread.Sleep(50); // Работи постоянно
                }
            }
        }

        static void LowPriorityTask()
        {
            while (true)
            {
                if (Monitor.TryEnter(lockObj))
                {
                    try
                    {
                        Console.WriteLine("Low-priority thread working...");
                    }
                    finally
                    {
                        Monitor.Exit(lockObj);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Low-priority thread waiting...");
                    Thread.Sleep(100); // Изчаква повече
                }
            }
        }

        static void Main(string[] args)
        {
            Thread highPriorityThread = new Thread(HighPriorityTask);
            Thread lowPriorityThread = new Thread(LowPriorityTask);

            highPriorityThread.Priority = ThreadPriority.Highest;
            lowPriorityThread.Priority = ThreadPriority.Lowest;

            highPriorityThread.Start();
            lowPriorityThread.Start();

            highPriorityThread.Join();
            lowPriorityThread.Join();
        }
    }

}
//Обяснение:
//Високоприоритетната нишка задържа ресурса прекалено дълго, оставяйки нишката с нисък приоритет да чака безкрайно.