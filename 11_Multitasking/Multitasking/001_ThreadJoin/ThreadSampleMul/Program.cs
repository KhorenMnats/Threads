using System;
using System.Threading;

namespace ThreadSampleMul
{
    class Program
    {
        // Общая переменная счетчик
        // [ThreadStatic] //TODO Снять комментарий // Использование TLS.
        public static int counter;

        // Рекурсивный запуск потоков
        public static void Method()
        {
           // int counter = 0;
            if (counter < 100)
            {
                counter++; // Увеличение счетчика вызваных методов
                Console.WriteLine(counter + " - START --- " + Thread.CurrentThread.GetHashCode());

                Thread thread = new Thread(Method);
                thread.Start();
                thread.Join(); // Закомментировать             
            }

            Console.WriteLine("Thread {0} ended.", Thread.CurrentThread.GetHashCode());
        }

        static void Main()
        {
            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join();

            Console.WriteLine("Primary Threade ended.");

            // Delay
            Console.ReadKey();
        }
    }
}
