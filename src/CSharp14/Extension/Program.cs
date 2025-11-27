using System.Numerics;

List<string> bikes = ["spark", "scale", "addict"];
var empty = bikes.IsEmpty;

var numbers = int.RangeFromZero(6) * 10;
foreach (var n in numbers)
    Console.WriteLine(n);

var vector = numbers.ToArray();
vector *= 2;

#region before C# 14

public static class EnumerableExtensions
{
    public static TSource FirstOrFallback<TSource>(this IEnumerable<TSource> source, TSource fallback)
        => source.FirstOrDefault() ?? fallback;

    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        foreach (var item in source)
            yield return selector(item);
    }
}

#endregion

#region with C# 14 extension members

internal static class MyEnumerableExtensions
{
    extension<T>(IEnumerable<T> source)
    {
        // Extension property
        public bool IsEmpty => !source.Any();

        // Extension method
        public T FirstOrFallback(T fallback)
            => source.FirstOrDefault() ?? fallback;

        // Extension static method
        public static IEnumerable<T> Range(int start, int count, Func<int, T> generator)
            => Enumerable.Range(start, count).Select((_, i) => generator(i));

        // Extension operator method
        public static IEnumerable<T> operator +(IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var item in first)
                yield return item;
            foreach (var item in second)
                yield return item;
        }

        // Extension indexer still missing
        //public T? this[int index] => source.ElementAtOrDefault(index);
    }

    // don't need to specify the receiver parameter for static methods
    extension(IEnumerable<int>)
    {
        public static IEnumerable<int> RangeFromZero(int count)
        {
            var start = 0;
            for (var i = 0; i < count; i++)
            {
                yield return start++;
            }
        }
    }

    // constraint on generic type parameter
    extension<T>(T) where T : INumber<T>
    {
        public static IEnumerable<T> RangeFromZero(int count)
        {
            var start = T.Zero;
            for (var i = 0; i < count; i++)
            {
                yield return start++;
            }
        }

        public static IEnumerable<T> operator *(IEnumerable<T> vector, T scalar) => vector.Select(v => v * scalar);
    }

    // improve performance with compound assignment operator
    // modifies the array in place
    extension<T>(T[] array) where T : INumber<T>
    {
        public void operator *= (T scalar)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] *= scalar;
            }
        }
    }
}

#endregion