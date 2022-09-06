using System;
using System.Diagnostics;

namespace BreakMeCompletely;

internal static class Program
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

        FailProcess();// Второй способ - это переполнить стек памяти

        // BeCareful();
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