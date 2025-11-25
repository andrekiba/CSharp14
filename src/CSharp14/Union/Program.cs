// https://github.com/dotnet/csharplang/blob/main/meetings/working-groups/discriminated-unions/union-proposals-overview.md
// https://github.com/dotnet/csharplang/blob/main/proposals/unions.md

Bike bike = new Mtb("Spark");

#region var model = bike switch
var model = bike.Value switch
#endregion
{
    Mtb mtb => mtb.Model,
    Bdc bdc => bdc.Model,
    Gravel gravel => gravel.Model,
    //_ => "Unknown bike type"
};

#region public union Bike(Bike1, Bike2, Bike3)
public partial record struct Bike : IUnion
{
    public Bike(Mtb value) => Value = value;
    public Bike(Bdc value) => Value = value;
    public Bike(Gravel value) => Value = value;
        
    public object? Value { get; }
        
    public static implicit operator Bike(Mtb value) => new(value);
    public static implicit operator Bike(Bdc value) => new(value);
    public static implicit operator Bike(Gravel value) => new(value);
}
#endregion

#region IUnion interface
public interface IUnion
{
    object? Value { get; }
}
#endregion

#region cases

public class Mtb(string model)
{
    public string Model { get; set; } = model;
}
    
public class Bdc(string model)
{
    public string Model { get; set; } = model;
}

public class Gravel(string model)
{
    public string Model { get; set; } = model;
}

#endregion