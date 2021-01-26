using System;
using System.Threading;

// AutoResetEvent - Уведомляет ожидающий поток о том, что произошло событие. 

namespace EventWaitHandleNs
{
    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            // Set method sent the signal to the waiting thread to proceed its work.
            Thread thread = new Thread(Function);
            thread.Start();
            Thread.Sleep(500); // Дадим время запуститься вторичному потоку.

            Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            auto.Set(); // Продолжение выполнения вторичного потока.

            Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            auto.Set(); // Продолжение выполнения вторичного потока.

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            // WaitOne method blocks the current thread and wait for the signal by other thread.
            // WaitOne method puts the current thread into a Sleep thread state.
            // WaitOne method returns true if it receives the signal else returns false.

            Console.WriteLine("Красный свет");
            auto.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Желтый");
            auto.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Зеленый");

            // СПРАВКА:
            // После завершения метода WaitOne() - AutoResetEvent автоматически переходит в несигнальное состояние.
        }
    }
}
