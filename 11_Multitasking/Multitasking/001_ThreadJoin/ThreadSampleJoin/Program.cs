using System;
using System.Threading;

namespace ThreadSampleJoin
{
    class Program
    {
        static void WriteChar(char chr, int count, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(20);
                Console.Write(chr);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Метод выполняющийся в третичном потоке (Запуск из вторичного потока).
        public static void Method3()
        {
            Console.WriteLine("Tertiary Thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('3', 80, ConsoleColor.Yellow);
            Console.WriteLine("Tertiary Thread ended.");
        }

        // Метод выполняющийся во вторичном потоке (Запуск из первичного потока).
        public static void Method2()
        {
            Console.WriteLine("Secondary Thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('2', 80, ConsoleColor.Blue);

            // Создание третичного потока
            var thread = new Thread(Method3);
            thread.Start();
            thread.Join();

            WriteChar('2', 80, ConsoleColor.Blue);
            Console.WriteLine("Secondary Thread ended.");
        }

        static void Main()
        {
            Console.WriteLine("Primary Thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('1', 80, ConsoleColor.Green);

            // Создание вторичного потока
            Thread thread = new Thread(Method2);
            thread.Start();
            thread.Join();

            WriteChar('1', 80, ConsoleColor.Green);

            Console.WriteLine("Primary Thread ended.");

            // Delay
            Console.ReadKey();
        }
    }
}
