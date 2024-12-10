using System;
using System.Threading;
namespace Project
{
    class LivelockExample
    {
        //При livelock нишките не са блокирани, но не могат да продължат напред, защото са заети да отговарят на действията на другата.
        private class Resource
        {
            public bool IsLocked { get; set; }
        }

        static void Main(string[] args)
        {
            Resource resource1 = new Resource();
            Resource resource2 = new Resource();

            Thread thread1 = new Thread(() =>
            {
                while (true)
                {
                    if (!resource1.IsLocked)
                    {
                        resource1.IsLocked = true;
                        Console.WriteLine("Thread 1: Locked resource1");

                        if (resource2.IsLocked)
                        {
                            Console.WriteLine("Thread 1: Resource2 is locked, releasing resource1");
                            resource1.IsLocked = false;
                            Thread.Sleep(100); // Опитва отново
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Thread 1: Finished");
            });

            Thread thread2 = new Thread(() =>
            {
                while (true)
                {
                    if (!resource2.IsLocked)
                    {
                        resource2.IsLocked = true;
                        Console.WriteLine("Thread 2: Locked resource2");

                        if (resource1.IsLocked)
                        {
                            Console.WriteLine("Thread 2: Resource1 is locked, releasing resource2");
                            resource2.IsLocked = false;
                            Thread.Sleep(100); // Опитва отново
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Thread 2: Finished");
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
//Нишките постоянно освобождават и заключват ресурси, без да правят напредък