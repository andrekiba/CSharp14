List<string> bikes = ["spark", "scale", "addict"];

#region before C# 14

/*
public static class EnumerableExtensions
{
    public static T FirstOrFallback<T>(this IEnumerable<T> source, T fallback)
       => source.FirstOrDefault() ?? fallback;

   public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
   {
       foreach (var item in source)
           yield return selector(item);
   }
}
*/

#endregion

#region with C# 14 extension members

public static class EnumerableExtensions
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

    extension<T>(IEnumerable<T> source)
    {
        public IEnumerable<T> Concat(IEnumerable<T> second)
        {
            foreach (var item in source)
                yield return item;
            foreach (var item in second)
                yield return item;
        }
    }
}

#endregion