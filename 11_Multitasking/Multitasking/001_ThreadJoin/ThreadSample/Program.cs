using System;
using System.Threading;

namespace ThreadSample
{
    class Program
    {
        // Метод выполяняющийся во Вторичном потоке.
        static void Function()
        {
            Console.WriteLine("Secondary Thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < 160; i++ )
            {                
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Secondary Thread ended.");
        }

        static void Main() // Метод Main - выполняется в первичном потоке.
        {
            Console.WriteLine("Primary Thread ID : {0}", Thread.CurrentThread.GetHashCode());

            // Создание нового потока
            Thread thread = new Thread(new ThreadStart(Function));
            thread.Start();
            
            // Ожидание первичным потоком, завершения работы вторичного потока.
            thread.Join(); //TODO Снять или установить комментарий.

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 160; i++)
            {                
                Thread.Sleep(20);
                Console.Write("-");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nPrimary Thread ended.");

            // Delay
            Console.ReadKey();
        }
    }
}
