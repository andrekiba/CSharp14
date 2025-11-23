using System.Runtime.CompilerServices;

namespace CSharp14;

public static class BikeExtensions
{
    extension(Bike bike)
    {
        public void ApplyDiscount(int percentage)
        {
            var discountAmount = bike.Price * percentage / 100;
            bike.Price -= discountAmount;
        }
        
        public double DiscountedPrice => bike.Price * 0.8;
        
        // Extension properties are computed unless you deliberately provision storage.
        public bool IsTestBike
        {
            get => State.GetOrCreateValue(bike).IsTestBike;
            set => State.GetOrCreateValue(bike).IsTestBike = value;
        }
    }
    
    static readonly ConditionalWeakTable<Bike, BikeState> State = new();
    sealed class BikeState
    {
        public bool IsTestBike { get; set; }
    }
}

/*
public static class EnumerableExtensions
{
    public static T FirstOrFallback<T>(this IEnumerable<T> enumerable, T fallback)
        => enumerable.FirstOrDefault() ?? fallback;
}
*/

public static class EnumerableExtensions
{
    extension<T>(IEnumerable<T> enumerable)
    {
        // Extension property
        public bool IsEmpty => !enumerable.Any();

        // Extension method
        public T FirstOrFallback(T fallback)
            => enumerable.FirstOrDefault() ?? fallback;
        
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
    }
    
    extension<T>(IEnumerable<T> source)
    {
        public IEnumerable<T> Concat1(IEnumerable<T> second)
        {
            foreach (var item in source)
                yield return item;
            foreach (var item in second)
                yield return item;
        }
    }
}
