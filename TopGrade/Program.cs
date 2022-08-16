namespace TopGrade;

internal static class Program
{
    private static void Main(string[] args)
    {
        var result = Sort(new[] {1, 4, 2, 4, 5, 7}, 2, 7);
        foreach (var i in result)
        {
            Console.Write($"{i} ");
        }
    }

    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел
    /// </summary>
    /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
    /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
    /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
    /// <returns>Отсортированный по возрастанию поток чисел.</returns>
    private static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var buffer = new Buffer(sortFactor, maxValue);

        foreach (int value in inputStream)
        {
            buffer.TryMoveBorder(value);
            
            foreach (var i in buffer.GetCurrentSequence())
            {
                yield return i;
            }

            buffer.AddValue(value);
        }

        buffer.TryMoveBorder();

        foreach (int i in buffer.GetCurrentSequence())
        {
            yield return i;
        }
    }
}