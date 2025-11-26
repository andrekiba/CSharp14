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
