using CSharp14;

#region Nullable assignment

var bike1 = Bike.GetIfInInventory("Spark", "Scott");
var bikeModel1 = bike1?.Model;
Console.WriteLine(bikeModel1 ?? "Bike not found in inventory.");

bike1?.PriceChanged += (price, model) =>
{
    Console.WriteLine($"The new price for {model} is {price}.");
};
bike1?.Price = 3000;

var bike2 = Bike.GetIfInInventory("Addict", "Scott");
var bikeModel2 = bike2?.Model;
Console.WriteLine(bikeModel2 ?? "Bike not found in inventory.");

#endregion

#region Extension members

var bikes = EnumerableExtensions.Range(1, 5, i => new Bike($"model{i}", $"brand{i}"));

var bike = bikes.FirstOrFallback(new Bike("FallbackModel", "FallbackBrand"));

var empty = bikes.IsEmpty;

bike.IsTestBike = true;
Console.WriteLine(bike.IsTestBike);

Console.ReadLine();
#endregion

