using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project
{

    //Този проблем възниква, когато две нишки работят върху споделен ресурс
    //и операциите им се смесват поради липса на синхронизация.
    class ThreadInterferenceExample
    {
        static int sharedValue = 0;

        static void Increment()
        {
            for (int i = 0; i < 1000; i++)
            {
                sharedValue++;
            }
        }

        static void Decrement()
        {
            for (int i = 0; i < 1000; i++)
            {
                sharedValue--;
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Increment);
            Thread thread2 = new Thread(Decrement);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final value of sharedValue: {sharedValue}");
        }
    }

}
//Обяснение:
//Без подходяща синхронизация, резултатът от sharedValue няма да бъде 0, защото операциите за четене, увеличаване и запис не са атомарни.