namespace CSharp14;

#region Before C# 14

// only partial classes, methods, properties and indexers were supported
// BikeConfig.cs
public partial class BikeConfig
{
    // No partial constructors
    public BikeConfig(string config)
    {
        Initialize(config);
    }
    
    // Partial method declaration needed, like a sort of interface
    private partial void Initialize(string config);
    
    // In case an event accessor has to call any generated code,
    // you must define the event accessor methods and call the generated method
    EventHandler? bikeConfigChanged;
    public event EventHandler BikeConfigChanged
    {
        add
        {
            // Call generated method
            OnConfigChangedAdded(value);
            bikeConfigChanged += value;
        }
        remove
        {
            // Call generated method
            OnConfigChangedRemoved(value);
            bikeConfigChanged -= value;
        }
    }
    
    private partial void OnConfigChangedAdded(EventHandler handler);
    private partial void OnConfigChangedRemoved(EventHandler handler);
}

// BikeConfig.g.cs
public partial class BikeConfig
{
    private partial void Initialize(string config)
    {
        // Generated code
    }
    
    private partial void OnConfigChangedAdded(EventHandler handler)
    {
        // Generated code
    }

    private partial void OnConfigChangedRemoved(EventHandler handler)
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
    public partial event EventHandler BikeConfigChanged;

    // Partial constructor
    public partial BikeConfig(string config);
}

// BikeConfig.g.cs
public partial class BikeConfig
{
    // Implementation for partial event
    EventHandler? bikeConfigChanged;
    public partial event EventHandler BikeConfigChanged
    {
        add =>
            // Generated code
            bikeConfigChanged += value;
        remove =>
            // Generated code
            bikeConfigChanged -= value;
    }

    // Implementation for partial constructor
    public partial BikeConfig(string config)
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