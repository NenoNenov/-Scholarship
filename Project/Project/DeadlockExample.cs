using System;
using System.Threading;

namespace Project
{
    class DeadlockExample
    {
    //    //1. Deadlock (Взаимно блокиране)
    //    Deadlock възниква, когато две или повече нишки чакат ресурси, заключени от другата, което води до вечна блокировка.
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                lock (lock1)
                {
                    Console.WriteLine("Thread 1: Locked lock1");
                    Thread.Sleep(100); // Симулира забавяне
                    lock (lock2)
                    {
                        Console.WriteLine("Thread 1: Locked lock2");
                    }
                }
            });

            Thread thread2 = new Thread(() =>
            {
                lock (lock2)
                {
                    Console.WriteLine("Thread 2: Locked lock2");
                    Thread.Sleep(100); // Симулира забавяне
                    lock (lock1)
                    {
                        Console.WriteLine("Thread 2: Locked lock1");
                    }
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Execution complete.");
        }
    }
}
//Обяснение:
//Thread 1 заключва lock1 и чака lock2.
//Thread 2 заключва lock2 и чака lock1.
//Нишките никога не могат да продължат, защото чакат ресурси, които няма да бъдат освободени.