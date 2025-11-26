namespace CSharp14;

public class Bike(string model, string brand)
{
    static readonly HashSet<(string Model, string Brand)> Inventory =
    [
        ("Spark", "Scott"),
        ("Scale", "Scott"),
        ("Verticale", "Wilier"),
        ("Domane", "Trek"),
        ("Defy", "Giant")
    ];
    
    public string Model { get; } = model;
    public string Brand { get; } = brand;

    double price;
    public double Price
    {
        get => price;
        set
        {
            price = value;
            PriceChanged?.Invoke(price, Model, out _);
        }
    }

    //public IReadOnlyList<Bike> OtherBikes => field ??= []; 
    
    /*
     * The field keyword is contextual, meaning it's only available inside the get and set methods of your auto-implemented properties.
     * You won’t be able to access a property’s field from other properties, constructors, or methods.
     * Instead, you’ll have to use the property accessor itself.
     */

    public event PriceChangedEventHandler? PriceChanged;
    public delegate void PriceChangedEventHandler(double price, string model, out bool success);

    public static Bike? GetIfInInventory(string model, string brand)
    {
        return Inventory.Contains((model, brand)) ? new Bike(model, brand) : null;
    }
}