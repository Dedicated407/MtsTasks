namespace IJustNeedToAsk;

internal static class Program
{
    private static void Main(string[] args)
    {
        const int tail = 2;
        var result = new[] {1, 2, 3, 4}.EnumerateFromTail(tail);

        foreach (var valueTuple in result.Reverse())
        {
            Console.Write($"({valueTuple.item}, {valueTuple.tail})");
            if (valueTuple.tail != 0)
            {
                Console.Write(", ");
            }
        }
    }

    /// <summary>
    /// <para> Отсчитать несколько элементов с конца</para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">Сколько элементов отсчитать с конца (у последнего элемента tail = 0)</param>
    /// <returns></returns>
    private static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(
        this IEnumerable<T> enumerable,
        int? tailLength
    )
    {
        int? count = 0;
        
        foreach (var num in enumerable.Reverse())
        {
            if (count == tailLength)
            {
                count = null;
            }
            
            yield return (num, count);
            count++;
        }
    }
}