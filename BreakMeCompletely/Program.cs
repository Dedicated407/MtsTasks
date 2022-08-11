using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch
        {
        }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        // Process.GetCurrentProcess().Kill(); // Первый способ - это убить процесс

        // while (true)
        // {
        //     StackOverflow(888888888); // Второй способ - это переполнить стек памяти
        // }
        //
        // int StackOverflow(int num)
        // {
        //     return num * StackOverflow(num);
        // }
        
        // BeCareful();
        
        Object locker = new Object();
        lock (locker)
        {
            while (true)
            {
                Thread.Sleep(50);
            }
        }
    }

    /// <summary>
    /// Это очень опасный метод.
    /// Проблемы с памятью - обеспеченны.
    /// Лучше не запускать.
    /// </summary>
    private static void BeCareful()
    {
        var items = new List<int>();
        var tasks = new List<Task>();
        while (true)
        {
            tasks.Add(Task.Run(() => {
                for (int k = 0; k < 10000; k++)
                {
                    items.Add(k);
                }
            }));
        }
    }
}