namespace CSharp14;

#region Before C# 14

// only partial classes, methods, properties and indexers were supported
// BikeConfig.cs
public partial class BikeConfig
{
    public BikeConfig(string configPath)
    {
        Initialize(configPath);
    }
    
    private partial void Initialize(string configPath);
}

// BikeConfig.g.cs
public partial class BikeConfig
{
    private partial void Initialize(string configPath)
    {
        // Generated code
    }
}

#endregion

#region With C# 14
/*
// BikeConfig.cs
public partial class BikeConfig
{
    // Partial event
    public partial event EventHandler BikeConfigReloaded;
    
    // Partial constructor
    public partial BikeConfig(string configPath);
}

// BikeConfig.g.cs
public partial class BikeConfig
{
    // Implementation for partial event
    EventHandler? configReloaded;
    public partial event EventHandler BikeConfigReloaded
    {
        add =>
            // Generated code
            configReloaded += value;
        remove =>
            // Generated code
            configReloaded -= value;
    }
    
    // Implementation for partial constructor
    public partial BikeConfig(string configPath)
    {
        // Generated code
    }
}
*/
/*
 * Keep in mind that partial constructors cannot be static and must always have a declaration and an implementation specified.
 * Similarly, partial events don’t support auto-implemented accessors, so you must always include an implementation that has the add and remove accessor.
 * Source generators can fully manage event accessors to implement patterns like weak events.
 */

#endregion