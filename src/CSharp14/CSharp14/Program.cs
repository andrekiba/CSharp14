using System.Numerics;
using CSharp14;

#region Nullable assignment

var bike1 = Bike.GetIfInInventory("Spark", "Scott");
var bikeModel1 = bike1?.Model;
Console.WriteLine(bikeModel1 ?? "Bike not found in inventory.");

#region before C# 14
/*
if (bike1 is not null)
{
    bike1.PriceChanged += (decimal price, string model, out bool success) =>
    {
        Console.WriteLine($"The new price for {model} is {price}.");
        success = true;
    };
    bike1.Price = 3000;
}
*/
#endregion

#region with C# 14 nullable assignment
bike1?.PriceChanged += (decimal price, string model, out bool success) =>
{
    Console.WriteLine($"The new price for {model} is {price}.");
    success = true;
};
bike1?.Price = 3000;

#region Lambda without explicit types
// now support ref, in, out, scoped, and ref readonly parameter modifiers without needing to specify parameter types
// doesn't work with Action<>, Func<> and params
#endregion

#endregion

#endregion

#region Extension members

/*
var bikes = EnumerableExtensions.Range(1, 5, i => new Bike($"model{i}", $"brand{i}"));

var bike = bikes.FirstOrFallback(new Bike("FallbackModel", "FallbackBrand"));

var empty = bikes.IsEmpty;

bike.IsTestBike = true;
Console.WriteLine(bike.IsTestBike);
*/

#endregion

#region Span<T> implicit conversion

T CalculateMedian<T>(Span<T> values) where T : INumber<T>
{
    values.Sort();
    var mid = values.Length / 2;
    if (values.Length % 2 == 0)
    {
        return (values[mid - 1] + values[mid]) / T.CreateChecked(2);
    }

    return values[mid];
}

//Array is converted to Span using explicit type
var median = CalculateMedian<int>([5, 3, 8, 1, 4]);

#endregion

Console.ReadLine();